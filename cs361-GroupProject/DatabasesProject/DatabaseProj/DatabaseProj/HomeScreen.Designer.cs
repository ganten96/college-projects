namespace DatabaseProj
{
    partial class HomeScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddCriteria = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddAssessmentItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCustom = new System.Windows.Forms.ToolStripMenuItem();
            this.assessmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criteriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StudentSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblEmphasis = new System.Windows.Forms.Label();
            this.cbEmphasis = new System.Windows.Forms.ComboBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.dgStudentSearchResults = new System.Windows.Forms.DataGridView();
            this.UniversityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiddleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmphasisId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emphasis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.semesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.StudentSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1081, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(92, 22);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStudent,
            this.tsmiAddCriteria,
            this.tsmiAddAssessmentItem,
            this.semesterToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "&Add";
            // 
            // tsmiStudent
            // 
            this.tsmiStudent.Name = "tsmiStudent";
            this.tsmiStudent.Size = new System.Drawing.Size(163, 22);
            this.tsmiStudent.Text = "&Student";
            this.tsmiStudent.Click += new System.EventHandler(this.tsmiStudent_Click);
            // 
            // tsmiAddCriteria
            // 
            this.tsmiAddCriteria.Name = "tsmiAddCriteria";
            this.tsmiAddCriteria.Size = new System.Drawing.Size(163, 22);
            this.tsmiAddCriteria.Text = "&Criteria";
            this.tsmiAddCriteria.Click += new System.EventHandler(this.tsmiAddCriteria_Click);
            // 
            // tsmiAddAssessmentItem
            // 
            this.tsmiAddAssessmentItem.Name = "tsmiAddAssessmentItem";
            this.tsmiAddAssessmentItem.Size = new System.Drawing.Size(163, 22);
            this.tsmiAddAssessmentItem.Text = "&Assessment Item";
            this.tsmiAddAssessmentItem.Click += new System.EventHandler(this.tsmiAddAssessmentItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCustom,
            this.assessmentsToolStripMenuItem,
            this.criteriaToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // tsmiCustom
            // 
            this.tsmiCustom.Name = "tsmiCustom";
            this.tsmiCustom.Size = new System.Drawing.Size(151, 22);
            this.tsmiCustom.Text = "&Custom Query";
            this.tsmiCustom.Click += new System.EventHandler(this.tsmiCustom_Click);
            // 
            // assessmentsToolStripMenuItem
            // 
            this.assessmentsToolStripMenuItem.Name = "assessmentsToolStripMenuItem";
            this.assessmentsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.assessmentsToolStripMenuItem.Text = "&Assessments";
            this.assessmentsToolStripMenuItem.Click += new System.EventHandler(this.assessmentsToolStripMenuItem_Click);
            // 
            // criteriaToolStripMenuItem
            // 
            this.criteriaToolStripMenuItem.Name = "criteriaToolStripMenuItem";
            this.criteriaToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.criteriaToolStripMenuItem.Text = "C&riteria";
            this.criteriaToolStripMenuItem.Click += new System.EventHandler(this.criteriaToolStripMenuItem_Click);
            // 
            // StudentSearch
            // 
            this.StudentSearch.Controls.Add(this.btnSearch);
            this.StudentSearch.Controls.Add(this.btnClear);
            this.StudentSearch.Controls.Add(this.lblEmphasis);
            this.StudentSearch.Controls.Add(this.cbEmphasis);
            this.StudentSearch.Controls.Add(this.txtLastName);
            this.StudentSearch.Controls.Add(this.lblLastName);
            this.StudentSearch.Controls.Add(this.txtFirstName);
            this.StudentSearch.Controls.Add(this.lblFirstName);
            this.StudentSearch.Location = new System.Drawing.Point(12, 27);
            this.StudentSearch.Name = "StudentSearch";
            this.StudentSearch.Size = new System.Drawing.Size(238, 535);
            this.StudentSearch.TabIndex = 1;
            this.StudentSearch.TabStop = false;
            this.StudentSearch.Text = "Search Options";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(76, 506);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(157, 506);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblEmphasis
            // 
            this.lblEmphasis.AutoSize = true;
            this.lblEmphasis.Location = new System.Drawing.Point(11, 103);
            this.lblEmphasis.Name = "lblEmphasis";
            this.lblEmphasis.Size = new System.Drawing.Size(55, 13);
            this.lblEmphasis.TabIndex = 5;
            this.lblEmphasis.Text = "Emphasis:";
            // 
            // cbEmphasis
            // 
            this.cbEmphasis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmphasis.FormattingEnabled = true;
            this.cbEmphasis.Items.AddRange(new object[] {
            "All",
            "Computer Information Systems",
            "Computer Science",
            "Software Engineering",
            "Undecided"});
            this.cbEmphasis.Location = new System.Drawing.Point(68, 100);
            this.cbEmphasis.Name = "cbEmphasis";
            this.cbEmphasis.Size = new System.Drawing.Size(164, 21);
            this.cbEmphasis.TabIndex = 4;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(68, 71);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(164, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(5, 74);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(68, 37);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(164, 20);
            this.txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(6, 40);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(63, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name: ";
            // 
            // dgStudentSearchResults
            // 
            this.dgStudentSearchResults.AllowUserToAddRows = false;
            this.dgStudentSearchResults.AllowUserToDeleteRows = false;
            this.dgStudentSearchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgStudentSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStudentSearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UniversityId,
            this.FirstName,
            this.MiddleName,
            this.LastName,
            this.Status,
            this.EmphasisId,
            this.Emphasis,
            this.Edit,
            this.View});
            this.dgStudentSearchResults.Location = new System.Drawing.Point(277, 47);
            this.dgStudentSearchResults.Name = "dgStudentSearchResults";
            this.dgStudentSearchResults.Size = new System.Drawing.Size(718, 492);
            this.dgStudentSearchResults.TabIndex = 7;
            // 
            // UniversityId
            // 
            this.UniversityId.HeaderText = "UniversityId";
            this.UniversityId.Name = "UniversityId";
            this.UniversityId.ReadOnly = true;
            this.UniversityId.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // MiddleName
            // 
            this.MiddleName.HeaderText = "Middle Name";
            this.MiddleName.Name = "MiddleName";
            this.MiddleName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // EmphasisId
            // 
            this.EmphasisId.HeaderText = "EmphasisId";
            this.EmphasisId.Name = "EmphasisId";
            this.EmphasisId.ReadOnly = true;
            this.EmphasisId.Visible = false;
            // 
            // Emphasis
            // 
            this.Emphasis.HeaderText = "Emphasis";
            this.Emphasis.Name = "Emphasis";
            this.Emphasis.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.Text = "Edit";
            this.Edit.ToolTipText = "Edit Student";
            // 
            // View
            // 
            this.View.HeaderText = "";
            this.View.Name = "View";
            // 
            // semesterToolStripMenuItem
            // 
            this.semesterToolStripMenuItem.Name = "semesterToolStripMenuItem";
            this.semesterToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.semesterToolStripMenuItem.Text = "S&emester";
            this.semesterToolStripMenuItem.Click += new System.EventHandler(this.semesterToolStripMenuItem_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 574);
            this.Controls.Add(this.dgStudentSearchResults);
            this.Controls.Add(this.StudentSearch);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomeScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home (Students)";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.StudentSearch.ResumeLayout(false);
            this.StudentSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStudentSearchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiStudent;
        private System.Windows.Forms.GroupBox StudentSearch;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblEmphasis;
        private System.Windows.Forms.ComboBox cbEmphasis;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgStudentSearchResults;
		private System.Windows.Forms.ToolStripMenuItem tsmiAddCriteria;
		private System.Windows.Forms.ToolStripMenuItem tsmiAddAssessmentItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tsmiCustom;
        private System.Windows.Forms.DataGridViewTextBoxColumn UniversityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiddleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmphasisId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emphasis;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn View;
        private System.Windows.Forms.ToolStripMenuItem assessmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criteriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semesterToolStripMenuItem;

    }
}