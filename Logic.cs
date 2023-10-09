using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System.Data;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace Audit_History_Editor
{
    public static class Logic
    {
        public static DataTable RetrieveAuditLog(IOrganizationService service, string recordId, string entityName, bool returnAllAudits = true)
        {
            DataTable audits = new DataTable();
            audits.Columns.Add("Id", typeof(string));
            audits.Columns.Add("Date_Change", typeof(DateTime));
            audits.Columns.Add("Operation", typeof(string));
            audits.Columns.Add("NewEntity", typeof(Entity));
            audits.Columns.Add("OldEntity", typeof(Entity));
            //audits.Columns.Add("ChangeDetails", typeof(DataTable));

            Guid recordGUID = Guid.Parse(recordId);
            RetrieveRecordChangeHistoryRequest request = new RetrieveRecordChangeHistoryRequest
            {
                Target = new EntityReference(entityName, recordGUID)
            };
            if (returnAllAudits == false)
            {
                // Return only the last audit history
                request.PagingInfo = new PagingInfo()
                {
                    Count = 1
                };
            }

            RetrieveRecordChangeHistoryResponse response = (RetrieveRecordChangeHistoryResponse)service.Execute(request);

            DataCollection<AuditDetail> allAudits = response.AuditDetailCollection.AuditDetails;
            List<AuditDetail> listAuditData = allAudits.Where(a => a.GetType().Name == "AttributeAuditDetail").ToList().OrderByDescending(a => a.AuditRecord.GetAttributeValue<DateTime>("createdon")).ToList();
            // There are 3 types:
            //      RelationshipAuditDetail
            //      AttributeAuditDetail
            //      AuditDetail

            if (returnAllAudits)
            {
                foreach (AuditDetail auditDetail in listAuditData)
                {
                    Entity audit = auditDetail.AuditRecord;
                    //if (audit.FormattedValues["operation"] != "Update")
                    //{
                    //    continue;
                    //}

                    Console.WriteLine("Audit ID: " + audit.Id.ToString());
                    Console.WriteLine("Date Change: " + audit.GetAttributeValue<DateTime>("createdon").ToLocalTime().ToString());
                    //Console.WriteLine("User: " + audit.UserId?.Name);
                    Console.WriteLine("Action: " + audit.FormattedValues["action"]);
                    Entity before = ((AttributeAuditDetail)auditDetail).OldValue;
                    Entity after = ((AttributeAuditDetail)auditDetail).NewValue;

                    audits.Rows.Add(
                        audit.Id.ToString(),
                        audit.GetAttributeValue<DateTime>("createdon").ToLocalTime(),
                        audit.FormattedValues["operation"],
                        after,
                        before
                        );
                }
            }
            else
            {
                if (listAuditData.Count > 0)
                {
                    Entity audit = listAuditData[0].AuditRecord;
                    if (audit.FormattedValues["operation"] == "Update")
                    {

                        Entity before = ((AttributeAuditDetail)listAuditData[0]).OldValue;
                        Entity after = ((AttributeAuditDetail)listAuditData[0]).NewValue;

                        audits.Rows.Add(
                            audit.Id.ToString(),
                            audit.GetAttributeValue<DateTime>("createdon").ToLocalTime(),
                            audit.FormattedValues["operation"],
                            after,
                            before
                            );
                    }
                }
            }

            return audits;
        }

        public static DataTable GetChangeDetail(Entity oldRecord, Entity newRecord)
        {
            List<string> changedAttrs = new List<string>();
            changedAttrs.AddRange(oldRecord.Attributes.Select(a => a.Key));
            changedAttrs.AddRange(newRecord.Attributes.Select(b => b.Key));
            changedAttrs = changedAttrs.Distinct().ToList();

            DataTable dtResult = new DataTable();
            //dtResult.Columns.Add(new DataColumn() { 
            //    ColumnName = "AttributeName",
            //    DataType = typeof(string),
            //    ReadOnly = true                
            //});
            dtResult.Columns.Add("AttributeName", typeof(string));
            dtResult.Columns.Add("OldValue", typeof(string));
            dtResult.Columns.Add("NewValue", typeof(string));
            dtResult.Columns.Add("OldObject", typeof(object));
            dtResult.Columns.Add("NewObject", typeof(object));

            foreach (var attr in changedAttrs)
            {
                DataRow dr = dtResult.NewRow();
                dr["AttributeName"] = attr;
                dr["OldValue"] = GetAttributeValue(oldRecord, attr);
                dr["NewValue"] = GetAttributeValue(newRecord, attr);

                dr["OldObject"] = (oldRecord.Contains(attr) ? oldRecord[attr] : null);
                dr["NewObject"] = (newRecord.Contains(attr) ? newRecord[attr] : null);

                dtResult.Rows.Add(dr);
            }

            return dtResult;
        }

        private static string GetAttributeValue(Entity record, string attributeName)
        {
            string value = string.Empty;
            if (!record.Contains(attributeName))
            {
                return null;
            }

            var obj = record[attributeName];

            switch (obj.GetType().Name.Trim())
            {
                case FieldTypes.OptionSetValue:
                    value = $"{record.FormattedValues[attributeName]} ({((OptionSetValue)obj).Value})";
                    break;
                case FieldTypes.MultiOptionSetValue:
                    value = $"{record.FormattedValues[attributeName]}";
                    break;
                case FieldTypes.DateTime:
                    value = obj.ToString();
                    break;
                case FieldTypes.Money:
                    value = (obj as Money).Value.ToString();
                    break;
                case FieldTypes.EntityReference:
                    EntityReference entRef = (obj as EntityReference);
                    if (string.IsNullOrEmpty(entRef.Name))
                        value = entRef.Id.ToString();
                    else
                        value = $"{(obj as EntityReference).Name} ({(obj as EntityReference).Id})";
                    break;
                case FieldTypes.String:
                case FieldTypes.Decimal:
                case FieldTypes.FloatingPointNumber:
                case FieldTypes.Int32:
                    value = obj.ToString();
                    break;
                default:
                    value = obj.ToString();
                    break;
            }

            return value;
        }

        public static EntityCollection ExecuteFetchXml(IOrganizationService service, string fetchXml)
        {
            try
            {
                EntityCollection entities = new EntityCollection();
                // Validate FetchXML request
                //ValidateSavedQueryRequest validateReq = new ValidateSavedQueryRequest();
                //validateReq.FetchXml = fetchXml;
                //ValidateSavedQueryResponse validateRes = (ValidateSavedQueryResponse)Service.Execute(validateReq);

                entities = service.RetrieveMultiple(new FetchExpression(fetchXml));

                return entities;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot execute FetchXML. Error Details: " + ex.Message, Constants.MESSAGES.CAPTION_ERROR);
                return null;
            }
        }
    }

    
}
