using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Markup.Localizer;
using XrmToolBox.Extensibility;

namespace Audit_History_Editor
{
    public partial class MyPluginControl : PluginControlBase
    {
        private Settings mySettings;
        private string selectedGUID = string.Empty;
        private string selectedEntity = string.Empty;

        public MyPluginControl()
        {
            InitializeComponent();

        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            btRetrieveAudit.Enabled = false;
            btRollback.Enabled = false;
            btRollbackAll.Enabled = false;

            btRetrieveAudit.BackColor = Constants.ButtonColor.Disabled;
            btRollback.BackColor = Constants.ButtonColor.Disabled;
            btRollbackAll.BackColor = Constants.ButtonColor.Disabled;


            if (Service == null)
            {
                
            }
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);
            
            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }

            selectedGUID = string.Empty;
            selectedEntity = string.Empty;
        }

        private void btLoadEntities_Click(object sender, EventArgs e)
        {
            if (Service == null)
            {
                MessageBox.Show(Constants.MESSAGES.NoConnectionError, Constants.MESSAGES.CAPTION_ERROR, MessageBoxButtons.OK);
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving entity list...",
                Work = (work, args) =>
                {
                    args.Result = RetrieveEntityList();
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                        return;
                    }
                    var entityList = args.Result as DataTable;
                    cbEntities.DataSource = entityList;
                    cbEntities.DisplayMember = "SchemaName";
                    cbEntities.ValueMember = "SchemaName";
                    cbEntities.Refresh();

                    btRetrieveAudit.Enabled = true;
                    btRollback.Enabled = true;
                    btRetrieveAudit.BackColor = Constants.ButtonColor.RetrieveAudit_Fill;
                    btRollback.BackColor = Constants.ButtonColor.Rollback_Fill;
                }
            });


        }

        private DataTable RetrieveEntityList()
        {
            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };

            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)Service.Execute(request);

            DataTable dtEntities = new DataTable();
            //dtEntities.Columns.Add("DisplayName", typeof(string));
            dtEntities.Columns.Add("SchemaName", typeof(string));

            foreach (EntityMetadata entity in response.EntityMetadata)
            {
                if (entity.IsAuditEnabled.Value == true)
                {
                    string schemaName = entity.LogicalName;
                    string displayName = entity.DisplayName?.UserLocalizedLabel?.Label;
                    dtEntities.Rows.Add(schemaName);
                }

            }

            return dtEntities;
        }

        private void cbEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEntity = cbEntities.SelectedValue.ToString();
        }

        private void btRetrieveAudit_Click(object sender, EventArgs e)
        {
            List<string> guids = new List<string>();
            
            selectedGUID = txtGUID.Text.Trim().Replace("{","").Replace("}",""); 
            selectedEntity = cbEntities.SelectedValue?.ToString().Trim();
            if (string.IsNullOrEmpty(selectedGUID) || string.IsNullOrEmpty(selectedEntity))
            {
                MessageBox.Show("Please select entity and enter record GUID.", Constants.MESSAGES.CAPTION_ERROR);
                return;
            }
            if (Guid.TryParse(selectedGUID, out Guid result) == false)
            {
                MessageBox.Show(Constants.MESSAGES.InvalidGUID, Constants.MESSAGES.CAPTION_ERROR);
                return;
            }

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving Audit History...",
                Work = (work, args) =>
                {
                    DataTable dtLogs = Logic.RetrieveAuditLog(Service, selectedGUID, selectedEntity);
                    args.Result = dtLogs;
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                        return;
                    }
                    var auditLogs = args.Result as DataTable;
                    lstAuditRecords.DisplayMember = "Date_Change";
                    lstAuditRecords.ValueMember = "Id";
                    lstAuditRecords.DataSource = auditLogs;
                    lstAuditRecords.Refresh();

                    if (auditLogs.Rows.Count == 0)
                    {
                        MessageBox.Show(Constants.MESSAGES.NoAuditLog, Constants.MESSAGES.CAPTION_INFO);
                    }
                }
            });
        }

        private void lstAuditRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selected = (DataRowView)lstAuditRecords.SelectedItem;

            DataTable changeDetails = Logic.GetChangeDetail(selected["OldEntity"] as Entity, selected["NewEntity"] as Entity);
            gvAuditDetail.AutoGenerateColumns = false;

            gvAuditDetail.DataSource = changeDetails;
            gvAuditDetail.Refresh();

        }


        #region CUSTOM METHODS
        
        private void RollbackChange(string entityName, string recordId, DataTable changeDetail, bool showMessage = true)
        {
            Entity updateRecord = new Entity(entityName, Guid.Parse(recordId));
            updateRecord.Id = Guid.Parse(recordId);

            foreach (DataRow row in changeDetail.Rows)
            {
                string attrName = row["AttributeName"].ToString();
                updateRecord.Attributes.Add(attrName, (row["OldObject"] == DBNull.Value) ? null : row["OldObject"]);
                //updateRecord[attrName] = (row["OldObject"] == DBNull.Value) ? null : row["OldObject"];
            }
            if (changeDetail.Rows.Count > 0)
            {
                UpdateRequest updateReq = new UpdateRequest()
                {
                    Target = updateRecord
                };
                updateReq.Parameters.Add("BypassCustomPluginExecution", chkBypassPlugins.Checked);
                updateReq.Parameters.Add("SuppressCallbackRegistrationExpanderJob", chkBypassFlows.Checked);
                Service.Execute(updateReq);

                if (showMessage)
                {
                    DialogResult res = MessageBox.Show("Audit history rollback successfully", "Confirmation", MessageBoxButtons.OK);
                    if (res == DialogResult.OK)
                    {
                        btRetrieveAudit.PerformClick();
                    }
                }
            }
            else
            {
                if (showMessage)
                {
                    MessageBox.Show("There is no attribute change to update.", "Confirmation");
                }
            }

        }

        #endregion

        private void btRollback_Click(object sender, EventArgs e)
        {
            if (lstAuditRecords.SelectedIndex >= 0)
            {
                DataRowView selected = (DataRowView)lstAuditRecords.SelectedItem;

                if (selected.Row["Operation"].ToString() == "Create")
                {
                    MessageBox.Show(Constants.MESSAGES.CannotRollback_Create, Constants.MESSAGES.CAPTION_INFO, MessageBoxButtons.OK);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure want to rollback to this version?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DataTable changeDetail = gvAuditDetail.DataSource as DataTable;
                    Entity afterChange = selected["NewEntity"] as Entity;
                    
                    RollbackChange(afterChange.LogicalName, selectedGUID, changeDetail);

                }
            }
            else
            {
                MessageBox.Show("Please select a version to rollback", Constants.MESSAGES.CAPTION_INFO);
            }
        }

        private void btExecuteFetchXML_Click(object sender, EventArgs e)
        {
            string fetchXml = txtFetchXML.Text;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving Data and Audit History...",
                Work = (work, args) =>
                {
                    EntityCollection data = Logic.ExecuteFetchXml(Service, fetchXml);
                    //lbRecordCount.Text = data.Entities.Count.ToString();

                    if (data != null)
                    {
                        DataTable allAuditHistory = new DataTable();
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(string),
                            ColumnName = "AuditID"
                        });
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(DateTime),
                            ColumnName = "Date_Change"
                        });
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(string),
                            ColumnName = "RecordID"
                        });
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(string),
                            ColumnName = "AttributeName"
                        });
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(string),
                            ColumnName = "OldValue_Formatted"
                        });
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(string),
                            ColumnName = "NewValue_Formatted"
                        });
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(object),
                            ColumnName = "OldValue"
                        });
                        allAuditHistory.Columns.Add(new DataColumn()
                        {
                            DataType = typeof(object),
                            ColumnName = "NewValue"
                        });


                        foreach (Entity ent in data.Entities)
                        {
                            // Only get latest Audit Log per record
                            //DataTable auditLog = Logic.RetrieveAuditLog(Service, ent.Id.ToString(), ent.LogicalName, false);

                            //if (auditLog != null && auditLog.Rows.Count > 0)
                            //{
                            //    DataRow dataRow = auditLog.Rows[0];
                            //    DataTable changeDetails = Logic.GetChangeDetail(dataRow["OldEntity"] as Entity, dataRow["NewEntity"] as Entity);
                            //    foreach (DataRow row in changeDetails.Rows)
                            //    {
                            //        DataRow dr = allAuditHistory.NewRow();
                            //        dr["AuditID"] = dataRow["Id"];
                            //        dr["Date_Change"] = dataRow["Date_Change"];
                            //        dr["RecordID"] = ent.Id.ToString();
                            //        dr["AttributeName"] = row["AttributeName"];
                            //        dr["OldValue_Formatted"] = row["OldValue"];
                            //        dr["NewValue_Formatted"] = row["NewValue"];
                            //        dr["OldValue"] = row["OldObject"];
                            //        dr["NewValue"] = row["NewObject"];

                            //        allAuditHistory.Rows.Add(dr);
                            //    }
                            //}
                        }

                        args.Result = new { 
                            AuditData = allAuditHistory,
                            FetchXMLResult = data,
                            RecordCount = data.Entities.Count
                        };
                    }
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                        return;
                    }
                    Type objectType = args.Result.GetType();

                    // Bind FetchXML result to gridview
                    if (args.Result != null)
                    {
                        PropertyInfo propInfo_FetchXml = objectType.GetProperty("FetchXMLResult");
                        EntityCollection rows = propInfo_FetchXml.GetValue(args.Result) as EntityCollection;

                        // Convert to DataTable
                        DataTable fetchData = new DataTable();
                        fetchData.Columns.Add("EntityName");
                        fetchData.Columns.Add("RecordID");
                        fetchData.Columns.Add("RecordName");

                        foreach (Entity rec in rows.Entities)
                        {
                            var dataRow = fetchData.NewRow();
                            dataRow["EntityName"] = rec.LogicalName;
                            dataRow["RecordID"] = rec.Id.ToString();
                            dataRow["RecordName"] = rec.ToEntityReference().Name;

                            fetchData.Rows.Add(dataRow);
                        }

                        gvFetchXMLResult.DataSource = fetchData;
                        gvFetchXMLResult.Refresh();
                    }

                    // Bind Audit History to gridview
                    PropertyInfo propertyInfo = objectType.GetProperty("RecordCount");
                    int recordCount = (int)propertyInfo.GetValue(args.Result);
                    lbRecordCount.Text = recordCount.ToString();
                }
            });
        }
        private void btRollbackAll_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(string.Format(Constants.MESSAGES.Confirm_RollbackAll, lbRecordCount.Text), Constants.MESSAGES.CAPTION_INFO, MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                WorkAsync(new WorkAsyncInfo() { 
                    Message = $"Processing {lbRecordCount.Text} record(s)...",
                    Work = (work, args) => 
                    {
                        int total = 0;
                        
                        // Rollback all records
                        DataTable data = gvFetchXMLResult.DataSource as DataTable;
                        foreach (DataRow row in data.Rows)
                        {
                            string entityName = row["EntityName"].ToString();
                            string recordId = row["RecordID"].ToString();

                            DataTable audit = Logic.RetrieveAuditLog(Service, recordId, entityName, false);
                            if (audit.Rows.Count > 0)
                            {
                                DataTable changeDetails = Logic.GetChangeDetail(audit.Rows[0]["OldEntity"] as Entity, audit.Rows[0]["NewEntity"] as Entity);
                                RollbackChange(entityName, recordId, changeDetails, false);

                                total++;
                            }
                              
                        }

                        args.Result = new
                        {
                            Total = total
                        };
                    },
                    PostWorkCallBack = args =>
                    {
                        if (args.Error != null)
                        {
                            ShowErrorDialog(args.Error);
                            return;
                        }

                        Type objectType = args.Result.GetType();
                        PropertyInfo propInfo_FetchXml = objectType.GetProperty("Total");
                        int total = (int)propInfo_FetchXml.GetValue(args.Result);
                        DialogResult result = MessageBox.Show($"{total} out of {lbRecordCount.Text} record(s) have been rolled back to previous version.", Constants.MESSAGES.CAPTION_INFO, MessageBoxButtons.OK);

                        if (result == DialogResult.OK)
                        {
                            gvFetchXMLResult.DataSource = null;
                            gvFetchXMLResult.Refresh();

                            lbRecordCount.Text = "";
                        }
                    }
                });
            }

        }

        private void MyPluginControl_Resize(object sender, EventArgs e)
        {
            tabControl1.Width = this.Size.Width - 150;
            //tabControl1.Refresh();
            this.Refresh();
        }

        
    }
}