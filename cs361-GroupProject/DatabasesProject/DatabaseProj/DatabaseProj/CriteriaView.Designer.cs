namespace DatabaseProj
{
    partial class CriteriaView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvAssessments = new System.Windows.Forms.DataGridView();
            this.moonn52DataSet1 = new DatabaseProj.moonn52DataSet1();
            this.criteriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.criteriaTableAdapter = new DatabaseProj.moonn52DataSet1TableAdapters.CriteriaTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxScoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moonn52DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAssessments
            // 
            this.dgvAssessments.AllowUserToAddRows = false;
            this.dgvAssessments.AutoGenerateColumns = false;
            this.dgvAssessments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssessments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssessments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.maxScoreDataGridViewTextBoxColumn});
            this.dgvAssessments.DataSource = this.criteriaBindingSource;
            this.dgvAssessments.Location = new System.Drawing.Point(12, 12);
            this.dgvAssessments.Name = "dgvAssessments";
            this.dgvAssessments.Size = new System.Drawing.Size(1022, 801);
            this.dgvAssessments.TabIndex = 1;
            this.dgvAssessments.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssessments_RowLeave);
            this.dgvAssessments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAssessments_UserDeletingRow);
            // 
            // moonn52DataSet1
            // 
            this.moonn52DataSet1.DataSetName = "moonn52DataSet1";
            this.moonn52DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // criteriaBindingSource
            // 
            this.criteriaBindingSource.DataMember = "Criteria";
            this.criteriaBindingSource.DataSource = this.moonn52DataSet1;
            // 
            // criteriaTableAdapter
            // 
            this.criteriaTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // maxScoreDataGridViewTextBoxColumn
            // 
            this.maxScoreDataGridViewTextBoxColumn.DataPropertyName = "MaxScore";
            this.maxScoreDataGridViewTextBoxColumn.HeaderText = "MaxScore";
            this.maxScoreDataGridViewTextBoxColumn.Name = "maxScoreDataGridViewTextBoxColumn";
            // 
            // CriteriaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 822);
            this.Controls.Add(this.dgvAssessments);
            this.Name = "CriteriaView";
            this.Text = "Criteria";
            this.Load += new System.EventHandler(this.CriteriaView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moonn52DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.criteriaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssessments;
        private moonn52DataSet1 moonn52DataSet1;
        private System.Windows.Forms.BindingSource criteriaBindingSource;
        private moonn52DataSet1TableAdapters.CriteriaTableAdapter criteriaTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxScoreDataGridViewTextBoxColumn;
    }
}