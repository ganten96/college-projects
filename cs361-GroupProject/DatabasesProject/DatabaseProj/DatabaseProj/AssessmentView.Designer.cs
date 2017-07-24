namespace DatabaseProj
{
    partial class frmAssessmentView
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
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assessmentItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moonn52DataSet = new DatabaseProj.moonn52DataSet();
            this.assessmentItemTableAdapter = new DatabaseProj.moonn52DataSetTableAdapters.AssessmentItemTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assessmentItemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moonn52DataSet)).BeginInit();
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
            this.nameDataGridViewTextBoxColumn});
            this.dgvAssessments.DataSource = this.assessmentItemBindingSource;
            this.dgvAssessments.Location = new System.Drawing.Point(13, 13);
            this.dgvAssessments.Name = "dgvAssessments";
            this.dgvAssessments.Size = new System.Drawing.Size(1022, 801);
            this.dgvAssessments.TabIndex = 0;
            this.dgvAssessments.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAssessments_RowLeave);
            this.dgvAssessments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAssessments_UserDeletingRow);
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
            // assessmentItemBindingSource
            // 
            this.assessmentItemBindingSource.DataMember = "AssessmentItem";
            this.assessmentItemBindingSource.DataSource = this.moonn52DataSet;
            // 
            // moonn52DataSet
            // 
            this.moonn52DataSet.DataSetName = "moonn52DataSet";
            this.moonn52DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // assessmentItemTableAdapter
            // 
            this.assessmentItemTableAdapter.ClearBeforeFill = true;
            // 
            // frmAssessmentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 825);
            this.Controls.Add(this.dgvAssessments);
            this.Name = "frmAssessmentView";
            this.Text = "Assessment Item";
            this.Load += new System.EventHandler(this.frmAssessmentView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assessmentItemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moonn52DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAssessments;
        private moonn52DataSet moonn52DataSet;
        private System.Windows.Forms.BindingSource assessmentItemBindingSource;
        private moonn52DataSetTableAdapters.AssessmentItemTableAdapter assessmentItemTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
    }
}