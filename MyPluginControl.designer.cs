namespace Audit_History_Editor
{
    partial class MyPluginControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gvAuditDetail = new System.Windows.Forms.DataGridView();
            this.AttributeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btLoadEntities = new System.Windows.Forms.Button();
            this.cbEntities = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstAuditRecords = new System.Windows.Forms.ListBox();
            this.btRollback = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFetchXML = new System.Windows.Forms.RichTextBox();
            this.btRetrieveAudit = new System.Windows.Forms.Button();
            this.txtGUID = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRollback = new System.Windows.Forms.TabPage();
            this.tabExtract = new System.Windows.Forms.TabPage();
            this.gvFetchXMLResult = new System.Windows.Forms.DataGridView();
            this.colFetch_EntityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFetch_RecordID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFetch_RecordName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btRollbackAll = new System.Windows.Forms.Button();
            this.lbRecordCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btExecuteFetchXML = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBypassFlows = new System.Windows.Forms.CheckBox();
            this.chkBypassPlugins = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvAuditDetail)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRollback.SuspendLayout();
            this.tabExtract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFetchXMLResult)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvAuditDetail
            // 
            this.gvAuditDetail.AllowUserToAddRows = false;
            this.gvAuditDetail.AllowUserToDeleteRows = false;
            this.gvAuditDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAuditDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAuditDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AttributeName,
            this.OldValue,
            this.NewValue});
            this.gvAuditDetail.Location = new System.Drawing.Point(232, 65);
            this.gvAuditDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gvAuditDetail.Name = "gvAuditDetail";
            this.gvAuditDetail.RowHeadersWidth = 51;
            this.gvAuditDetail.RowTemplate.Height = 24;
            this.gvAuditDetail.Size = new System.Drawing.Size(866, 326);
            this.gvAuditDetail.TabIndex = 0;
            // 
            // AttributeName
            // 
            this.AttributeName.DataPropertyName = "AttributeName";
            this.AttributeName.HeaderText = "Attribute Name";
            this.AttributeName.MinimumWidth = 6;
            this.AttributeName.Name = "AttributeName";
            this.AttributeName.ReadOnly = true;
            // 
            // OldValue
            // 
            this.OldValue.DataPropertyName = "OldValue";
            this.OldValue.HeaderText = "Old Value";
            this.OldValue.MinimumWidth = 6;
            this.OldValue.Name = "OldValue";
            this.OldValue.ReadOnly = true;
            // 
            // NewValue
            // 
            this.NewValue.DataPropertyName = "NewValue";
            this.NewValue.HeaderText = "New Value";
            this.NewValue.MinimumWidth = 6;
            this.NewValue.Name = "NewValue";
            this.NewValue.ReadOnly = true;
            // 
            // btLoadEntities
            // 
            this.btLoadEntities.Location = new System.Drawing.Point(22, 25);
            this.btLoadEntities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLoadEntities.Name = "btLoadEntities";
            this.btLoadEntities.Size = new System.Drawing.Size(115, 34);
            this.btLoadEntities.TabIndex = 5;
            this.btLoadEntities.Text = "Load Entities";
            this.btLoadEntities.UseVisualStyleBackColor = true;
            this.btLoadEntities.Click += new System.EventHandler(this.btLoadEntities_Click);
            // 
            // cbEntities
            // 
            this.cbEntities.DropDownHeight = 120;
            this.cbEntities.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbEntities.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEntities.FormattingEnabled = true;
            this.cbEntities.IntegralHeight = false;
            this.cbEntities.ItemHeight = 18;
            this.cbEntities.Location = new System.Drawing.Point(142, 28);
            this.cbEntities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEntities.Name = "cbEntities";
            this.cbEntities.Size = new System.Drawing.Size(292, 26);
            this.cbEntities.TabIndex = 6;
            this.cbEntities.SelectedIndexChanged += new System.EventHandler(this.cbEntities_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.lstAuditRecords);
            this.groupBox2.Controls.Add(this.gvAuditDetail);
            this.groupBox2.Location = new System.Drawing.Point(22, 127);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1104, 398);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audit History";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Khaki;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(232, 28);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(869, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "Audit History Detail";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Change Date";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lstAuditRecords
            // 
            this.lstAuditRecords.FormattingEnabled = true;
            this.lstAuditRecords.ItemHeight = 18;
            this.lstAuditRecords.Location = new System.Drawing.Point(13, 63);
            this.lstAuditRecords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstAuditRecords.Name = "lstAuditRecords";
            this.lstAuditRecords.Size = new System.Drawing.Size(212, 328);
            this.lstAuditRecords.TabIndex = 1;
            this.lstAuditRecords.SelectedIndexChanged += new System.EventHandler(this.lstAuditRecords_SelectedIndexChanged);
            // 
            // btRollback
            // 
            this.btRollback.BackColor = System.Drawing.Color.OrangeRed;
            this.btRollback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRollback.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btRollback.Location = new System.Drawing.Point(587, 27);
            this.btRollback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRollback.Name = "btRollback";
            this.btRollback.Size = new System.Drawing.Size(157, 71);
            this.btRollback.TabIndex = 8;
            this.btRollback.Text = "Rollback";
            this.btRollback.UseVisualStyleBackColor = false;
            this.btRollback.Click += new System.EventHandler(this.btRollback_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Record ID";
            // 
            // txtFetchXML
            // 
            this.txtFetchXML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFetchXML.Location = new System.Drawing.Point(21, 47);
            this.txtFetchXML.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFetchXML.Name = "txtFetchXML";
            this.txtFetchXML.Size = new System.Drawing.Size(458, 473);
            this.txtFetchXML.TabIndex = 3;
            this.txtFetchXML.Text = "";
            // 
            // btRetrieveAudit
            // 
            this.btRetrieveAudit.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btRetrieveAudit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetrieveAudit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btRetrieveAudit.Location = new System.Drawing.Point(440, 25);
            this.btRetrieveAudit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRetrieveAudit.Name = "btRetrieveAudit";
            this.btRetrieveAudit.Size = new System.Drawing.Size(116, 74);
            this.btRetrieveAudit.TabIndex = 4;
            this.btRetrieveAudit.Text = "Retrieve Audit";
            this.btRetrieveAudit.UseVisualStyleBackColor = false;
            this.btRetrieveAudit.Click += new System.EventHandler(this.btRetrieveAudit_Click);
            // 
            // txtGUID
            // 
            this.txtGUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGUID.Location = new System.Drawing.Point(142, 75);
            this.txtGUID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGUID.MaxLength = 40;
            this.txtGUID.Name = "txtGUID";
            this.txtGUID.Size = new System.Drawing.Size(292, 24);
            this.txtGUID.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRollback);
            this.tabControl1.Controls.Add(this.tabExtract);
            this.tabControl1.Location = new System.Drawing.Point(0, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1140, 606);
            this.tabControl1.TabIndex = 8;
            // 
            // tabRollback
            // 
            this.tabRollback.BackColor = System.Drawing.Color.Silver;
            this.tabRollback.Controls.Add(this.groupBox2);
            this.tabRollback.Controls.Add(this.btLoadEntities);
            this.tabRollback.Controls.Add(this.btRollback);
            this.tabRollback.Controls.Add(this.cbEntities);
            this.tabRollback.Controls.Add(this.label1);
            this.tabRollback.Controls.Add(this.txtGUID);
            this.tabRollback.Controls.Add(this.btRetrieveAudit);
            this.tabRollback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRollback.Location = new System.Drawing.Point(4, 25);
            this.tabRollback.Name = "tabRollback";
            this.tabRollback.Padding = new System.Windows.Forms.Padding(3);
            this.tabRollback.Size = new System.Drawing.Size(1132, 577);
            this.tabRollback.TabIndex = 0;
            this.tabRollback.Text = "Single Rollback ";
            // 
            // tabExtract
            // 
            this.tabExtract.Controls.Add(this.gvFetchXMLResult);
            this.tabExtract.Controls.Add(this.btRollbackAll);
            this.tabExtract.Controls.Add(this.lbRecordCount);
            this.tabExtract.Controls.Add(this.label3);
            this.tabExtract.Controls.Add(this.btExecuteFetchXML);
            this.tabExtract.Controls.Add(this.label2);
            this.tabExtract.Controls.Add(this.txtFetchXML);
            this.tabExtract.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabExtract.Location = new System.Drawing.Point(4, 25);
            this.tabExtract.Name = "tabExtract";
            this.tabExtract.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtract.Size = new System.Drawing.Size(1132, 577);
            this.tabExtract.TabIndex = 1;
            this.tabExtract.Text = "Revert multiple records";
            // 
            // gvFetchXMLResult
            // 
            this.gvFetchXMLResult.AllowUserToAddRows = false;
            this.gvFetchXMLResult.AllowUserToDeleteRows = false;
            this.gvFetchXMLResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvFetchXMLResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFetch_EntityName,
            this.colFetch_RecordID,
            this.colFetch_RecordName});
            this.gvFetchXMLResult.Location = new System.Drawing.Point(512, 132);
            this.gvFetchXMLResult.Name = "gvFetchXMLResult";
            this.gvFetchXMLResult.RowHeadersWidth = 51;
            this.gvFetchXMLResult.RowTemplate.Height = 24;
            this.gvFetchXMLResult.Size = new System.Drawing.Size(416, 388);
            this.gvFetchXMLResult.TabIndex = 10;
            // 
            // colFetch_EntityName
            // 
            this.colFetch_EntityName.DataPropertyName = "EntityName";
            this.colFetch_EntityName.HeaderText = "Entity Name";
            this.colFetch_EntityName.MinimumWidth = 6;
            this.colFetch_EntityName.Name = "colFetch_EntityName";
            this.colFetch_EntityName.ReadOnly = true;
            this.colFetch_EntityName.Visible = false;
            this.colFetch_EntityName.Width = 125;
            // 
            // colFetch_RecordID
            // 
            this.colFetch_RecordID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFetch_RecordID.DataPropertyName = "RecordID";
            this.colFetch_RecordID.HeaderText = "ID";
            this.colFetch_RecordID.MinimumWidth = 150;
            this.colFetch_RecordID.Name = "colFetch_RecordID";
            this.colFetch_RecordID.ReadOnly = true;
            // 
            // colFetch_RecordName
            // 
            this.colFetch_RecordName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFetch_RecordName.DataPropertyName = "RecordName";
            this.colFetch_RecordName.HeaderText = "Name";
            this.colFetch_RecordName.MinimumWidth = 6;
            this.colFetch_RecordName.Name = "colFetch_RecordName";
            this.colFetch_RecordName.ReadOnly = true;
            this.colFetch_RecordName.Visible = false;
            // 
            // btRollbackAll
            // 
            this.btRollbackAll.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btRollbackAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRollbackAll.Location = new System.Drawing.Point(512, 47);
            this.btRollbackAll.Name = "btRollbackAll";
            this.btRollbackAll.Size = new System.Drawing.Size(193, 62);
            this.btRollbackAll.TabIndex = 8;
            this.btRollbackAll.Text = "Rollback All Records (To Previous version)";
            this.btRollbackAll.UseVisualStyleBackColor = false;
            this.btRollbackAll.Click += new System.EventHandler(this.btRollbackAll_Click);
            // 
            // lbRecordCount
            // 
            this.lbRecordCount.AutoSize = true;
            this.lbRecordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecordCount.Location = new System.Drawing.Point(620, 16);
            this.lbRecordCount.Name = "lbRecordCount";
            this.lbRecordCount.Size = new System.Drawing.Size(17, 18);
            this.lbRecordCount.TabIndex = 7;
            this.lbRecordCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Record Count:";
            // 
            // btExecuteFetchXML
            // 
            this.btExecuteFetchXML.BackColor = System.Drawing.Color.Tomato;
            this.btExecuteFetchXML.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExecuteFetchXML.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btExecuteFetchXML.Location = new System.Drawing.Point(21, 525);
            this.btExecuteFetchXML.Name = "btExecuteFetchXML";
            this.btExecuteFetchXML.Size = new System.Drawing.Size(458, 45);
            this.btExecuteFetchXML.TabIndex = 5;
            this.btExecuteFetchXML.Text = "Execute";
            this.btExecuteFetchXML.UseVisualStyleBackColor = false;
            this.btExecuteFetchXML.Click += new System.EventHandler(this.btExecuteFetchXML_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "FetchXML Query";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBypassFlows);
            this.groupBox1.Controls.Add(this.chkBypassPlugins);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 68);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rollback Configurations";
            // 
            // chkBypassFlows
            // 
            this.chkBypassFlows.AutoSize = true;
            this.chkBypassFlows.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBypassFlows.Location = new System.Drawing.Point(340, 31);
            this.chkBypassFlows.Name = "chkBypassFlows";
            this.chkBypassFlows.Size = new System.Drawing.Size(214, 20);
            this.chkBypassFlows.TabIndex = 1;
            this.chkBypassFlows.Text = "Bypass Power Automate Flows";
            this.chkBypassFlows.UseVisualStyleBackColor = true;
            // 
            // chkBypassPlugins
            // 
            this.chkBypassPlugins.AutoSize = true;
            this.chkBypassPlugins.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBypassPlugins.Location = new System.Drawing.Point(6, 31);
            this.chkBypassPlugins.Name = "chkBypassPlugins";
            this.chkBypassPlugins.Size = new System.Drawing.Size(260, 20);
            this.chkBypassPlugins.TabIndex = 0;
            this.chkBypassPlugins.Text = "Bypass Custom plug-ins (synchronous)";
            this.toolTip1.SetToolTip(this.chkBypassPlugins, "Current user must have must have the prvBypassCustomPlugins privilege");
            this.chkBypassPlugins.UseVisualStyleBackColor = true;
            // 
            // MyPluginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MyPluginControl";
            this.Size = new System.Drawing.Size(1146, 700);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.Resize += new System.EventHandler(this.MyPluginControl_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.gvAuditDetail)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabRollback.ResumeLayout(false);
            this.tabRollback.PerformLayout();
            this.tabExtract.ResumeLayout(false);
            this.tabExtract.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFetchXMLResult)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btLoadEntities;
        private System.Windows.Forms.ComboBox cbEntities;
        private System.Windows.Forms.TextBox txtGUID;
        private System.Windows.Forms.RichTextBox txtFetchXML;
        private System.Windows.Forms.Button btRetrieveAudit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstAuditRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvAuditDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewValue;
        private System.Windows.Forms.Button btRollback;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRollback;
        private System.Windows.Forms.TabPage tabExtract;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btExecuteFetchXML;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbRecordCount;
        private System.Windows.Forms.Button btRollbackAll;
        private System.Windows.Forms.DataGridView gvFetchXMLResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFetch_EntityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFetch_RecordID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFetch_RecordName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkBypassFlows;
        private System.Windows.Forms.CheckBox chkBypassPlugins;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
