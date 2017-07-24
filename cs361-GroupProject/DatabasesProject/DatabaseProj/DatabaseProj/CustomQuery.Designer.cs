namespace DatabaseProj
{
	partial class CustomQuery
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
            this.dgvQuery = new System.Windows.Forms.DataGridView();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assessmentItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semestersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCriterionAverage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCriterionAverageAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCriterionAverageOne = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAssessmentAverage = new System.Windows.Forms.ToolStripMenuItem();
            this.topFiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bottomFiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuery
            // 
            this.dgvQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuery.Location = new System.Drawing.Point(12, 59);
            this.dgvQuery.Name = "dgvQuery";
            this.dgvQuery.Size = new System.Drawing.Size(871, 620);
            this.dgvQuery.TabIndex = 0;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 27);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(790, 20);
            this.txtQuery.TabIndex = 1;
            this.txtQuery.Text = "SELECT * FROM AssessmentItem;";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(808, 24);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 2;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.queryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(895, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiQuit
            // 
            this.tsmiQuit.Name = "tsmiQuit";
            this.tsmiQuit.Size = new System.Drawing.Size(97, 22);
            this.tsmiQuit.Text = "&Quit";
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectToolStripMenuItem,
            this.tsmiCriterionAverage,
            this.tsmiAssessmentAverage});
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.queryToolStripMenuItem.Text = "&Query";
            // 
            // selectToolStripMenuItem
            // 
            this.selectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assessmentItemToolStripMenuItem,
            this.criteriaToolStripMenuItem,
            this.semestersToolStripMenuItem,
            this.studentsToolStripMenuItem});
            this.selectToolStripMenuItem.Name = "selectToolStripMenuItem";
            this.selectToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.selectToolStripMenuItem.Text = "Select";
            // 
            // assessmentItemToolStripMenuItem
            // 
            this.assessmentItemToolStripMenuItem.Name = "assessmentItemToolStripMenuItem";
            this.assessmentItemToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.assessmentItemToolStripMenuItem.Text = "Assessment Item";
            this.assessmentItemToolStripMenuItem.Click += new System.EventHandler(this.assessmentItemToolStripMenuItem_Click);
            // 
            // criteriaToolStripMenuItem
            // 
            this.criteriaToolStripMenuItem.Name = "criteriaToolStripMenuItem";
            this.criteriaToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.criteriaToolStripMenuItem.Text = "Criteria";
            this.criteriaToolStripMenuItem.Click += new System.EventHandler(this.criteriaToolStripMenuItem_Click);
            // 
            // semestersToolStripMenuItem
            // 
            this.semestersToolStripMenuItem.Name = "semestersToolStripMenuItem";
            this.semestersToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.semestersToolStripMenuItem.Text = "Semesters";
            this.semestersToolStripMenuItem.Click += new System.EventHandler(this.semestersToolStripMenuItem_Click);
            // 
            // studentsToolStripMenuItem
            // 
            this.studentsToolStripMenuItem.Name = "studentsToolStripMenuItem";
            this.studentsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.studentsToolStripMenuItem.Text = "Students";
            this.studentsToolStripMenuItem.Click += new System.EventHandler(this.studentsToolStripMenuItem_Click);
            // 
            // tsmiCriterionAverage
            // 
            this.tsmiCriterionAverage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCriterionAverageAll,
            this.tsmiCriterionAverageOne});
            this.tsmiCriterionAverage.Name = "tsmiCriterionAverage";
            this.tsmiCriterionAverage.Size = new System.Drawing.Size(182, 22);
            this.tsmiCriterionAverage.Text = "&Criterion Average";
            this.tsmiCriterionAverage.Click += new System.EventHandler(this.tsmiCriterionAverage_Click);
            // 
            // tsmiCriterionAverageAll
            // 
            this.tsmiCriterionAverageAll.Name = "tsmiCriterionAverageAll";
            this.tsmiCriterionAverageAll.Size = new System.Drawing.Size(110, 22);
            this.tsmiCriterionAverageAll.Text = "&All AI";
            this.tsmiCriterionAverageAll.Click += new System.EventHandler(this.tsmiCriterionAverageAll_Click);
            // 
            // tsmiCriterionAverageOne
            // 
            this.tsmiCriterionAverageOne.Name = "tsmiCriterionAverageOne";
            this.tsmiCriterionAverageOne.Size = new System.Drawing.Size(110, 22);
            this.tsmiCriterionAverageOne.Text = "&One AI";
            this.tsmiCriterionAverageOne.Click += new System.EventHandler(this.tsmiCriterionAverageOne_Click);
            // 
            // tsmiAssessmentAverage
            // 
            this.tsmiAssessmentAverage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topFiveToolStripMenuItem,
            this.bottomFiveToolStripMenuItem});
            this.tsmiAssessmentAverage.Name = "tsmiAssessmentAverage";
            this.tsmiAssessmentAverage.Size = new System.Drawing.Size(182, 22);
            this.tsmiAssessmentAverage.Text = "Assessment Average";
            this.tsmiAssessmentAverage.Click += new System.EventHandler(this.tsmiAssessmentAverage_Click);
            // 
            // topFiveToolStripMenuItem
            // 
            this.topFiveToolStripMenuItem.Name = "topFiveToolStripMenuItem";
            this.topFiveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.topFiveToolStripMenuItem.Text = "Top Five";
            this.topFiveToolStripMenuItem.Click += new System.EventHandler(this.topFiveToolStripMenuItem_Click);
            // 
            // bottomFiveToolStripMenuItem
            // 
            this.bottomFiveToolStripMenuItem.Name = "bottomFiveToolStripMenuItem";
            this.bottomFiveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.bottomFiveToolStripMenuItem.Text = "Bottom Five";
            this.bottomFiveToolStripMenuItem.Click += new System.EventHandler(this.bottomFiveToolStripMenuItem_Click);
            // 
            // CustomQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 691);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.dgvQuery);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CustomQuery";
            this.Text = "Custom Query / Reports";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuery)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvQuery;
		private System.Windows.Forms.TextBox txtQuery;
		private System.Windows.Forms.Button btnQuery;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem tsmiFile;
		private System.Windows.Forms.ToolStripMenuItem tsmiQuit;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCriterionAverage;
        private System.Windows.Forms.ToolStripMenuItem tsmiCriterionAverageAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiCriterionAverageOne;
        private System.Windows.Forms.ToolStripMenuItem tsmiAssessmentAverage;
        private System.Windows.Forms.ToolStripMenuItem selectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assessmentItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criteriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semestersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topFiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bottomFiveToolStripMenuItem;
	}
}