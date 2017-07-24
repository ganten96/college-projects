namespace DatabaseProj
{
    partial class ViewStudent
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
            this.AssessmentInfoGroup = new System.Windows.Forms.GroupBox();
            this.AssessmentTree = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEmphasis = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblEmphasis = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AddAssessmentGroupBox = new System.Windows.Forms.GroupBox();
            this.txtFaculty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSemester = new System.Windows.Forms.Label();
            this.SemesterComboBox = new System.Windows.Forms.ComboBox();
            this.AddAssessment = new System.Windows.Forms.Button();
            this.ScoreDomainUpDown = new System.Windows.Forms.DomainUpDown();
            this.CriteraComboBox = new System.Windows.Forms.ComboBox();
            this.AssessmentCombo = new System.Windows.Forms.ComboBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblCriteria = new System.Windows.Forms.Label();
            this.lblAssessment = new System.Windows.Forms.Label();
            this.rtbStats = new System.Windows.Forms.RichTextBox();
            this.AssessmentInfoGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.AddAssessmentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AssessmentInfoGroup
            // 
            this.AssessmentInfoGroup.Controls.Add(this.rtbStats);
            this.AssessmentInfoGroup.Controls.Add(this.AssessmentTree);
            this.AssessmentInfoGroup.Location = new System.Drawing.Point(285, 12);
            this.AssessmentInfoGroup.Name = "AssessmentInfoGroup";
            this.AssessmentInfoGroup.Size = new System.Drawing.Size(365, 459);
            this.AssessmentInfoGroup.TabIndex = 0;
            this.AssessmentInfoGroup.TabStop = false;
            this.AssessmentInfoGroup.Text = "Assessment Information";
            // 
            // AssessmentTree
            // 
            this.AssessmentTree.Location = new System.Drawing.Point(19, 19);
            this.AssessmentTree.Name = "AssessmentTree";
            this.AssessmentTree.Size = new System.Drawing.Size(326, 308);
            this.AssessmentTree.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(897, 448);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEmphasis);
            this.groupBox1.Controls.Add(this.txtStatus);
            this.groupBox1.Controls.Add(this.txtMiddleName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtLastName);
            this.groupBox1.Controls.Add(this.txtFirstName);
            this.groupBox1.Controls.Add(this.lblEmphasis);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.lblLastName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 459);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Information";
            // 
            // txtEmphasis
            // 
            this.txtEmphasis.Location = new System.Drawing.Point(82, 142);
            this.txtEmphasis.Name = "txtEmphasis";
            this.txtEmphasis.ReadOnly = true;
            this.txtEmphasis.Size = new System.Drawing.Size(159, 20);
            this.txtEmphasis.TabIndex = 9;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(82, 116);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(159, 20);
            this.txtStatus.TabIndex = 8;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(82, 63);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.ReadOnly = true;
            this.txtMiddleName.Size = new System.Drawing.Size(159, 20);
            this.txtMiddleName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "First Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(82, 90);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.ReadOnly = true;
            this.txtLastName.Size = new System.Drawing.Size(159, 20);
            this.txtLastName.TabIndex = 7;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(82, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.ReadOnly = true;
            this.txtFirstName.Size = new System.Drawing.Size(159, 20);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblEmphasis
            // 
            this.lblEmphasis.AutoSize = true;
            this.lblEmphasis.Location = new System.Drawing.Point(26, 145);
            this.lblEmphasis.Name = "lblEmphasis";
            this.lblEmphasis.Size = new System.Drawing.Size(55, 13);
            this.lblEmphasis.TabIndex = 4;
            this.lblEmphasis.Text = "Emphasis:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(41, 119);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 93);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "Last Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Middle Name:";
            // 
            // AddAssessmentGroupBox
            // 
            this.AddAssessmentGroupBox.Controls.Add(this.txtFaculty);
            this.AddAssessmentGroupBox.Controls.Add(this.label1);
            this.AddAssessmentGroupBox.Controls.Add(this.lblSemester);
            this.AddAssessmentGroupBox.Controls.Add(this.SemesterComboBox);
            this.AddAssessmentGroupBox.Controls.Add(this.AddAssessment);
            this.AddAssessmentGroupBox.Controls.Add(this.ScoreDomainUpDown);
            this.AddAssessmentGroupBox.Controls.Add(this.CriteraComboBox);
            this.AddAssessmentGroupBox.Controls.Add(this.AssessmentCombo);
            this.AddAssessmentGroupBox.Controls.Add(this.lblScore);
            this.AddAssessmentGroupBox.Controls.Add(this.lblCriteria);
            this.AddAssessmentGroupBox.Controls.Add(this.lblAssessment);
            this.AddAssessmentGroupBox.Location = new System.Drawing.Point(656, 12);
            this.AddAssessmentGroupBox.Name = "AddAssessmentGroupBox";
            this.AddAssessmentGroupBox.Size = new System.Drawing.Size(316, 214);
            this.AddAssessmentGroupBox.TabIndex = 4;
            this.AddAssessmentGroupBox.TabStop = false;
            this.AddAssessmentGroupBox.Text = "Add Assessment";
            // 
            // txtFaculty
            // 
            this.txtFaculty.Location = new System.Drawing.Point(145, 139);
            this.txtFaculty.Name = "txtFaculty";
            this.txtFaculty.Size = new System.Drawing.Size(154, 20);
            this.txtFaculty.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Faculty Member:";
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(85, 116);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(54, 13);
            this.lblSemester.TabIndex = 7;
            this.lblSemester.Text = "Semester:";
            // 
            // SemesterComboBox
            // 
            this.SemesterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SemesterComboBox.FormattingEnabled = true;
            this.SemesterComboBox.Location = new System.Drawing.Point(145, 111);
            this.SemesterComboBox.Name = "SemesterComboBox";
            this.SemesterComboBox.Size = new System.Drawing.Size(154, 21);
            this.SemesterComboBox.TabIndex = 6;
            // 
            // AddAssessment
            // 
            this.AddAssessment.Location = new System.Drawing.Point(224, 172);
            this.AddAssessment.Name = "AddAssessment";
            this.AddAssessment.Size = new System.Drawing.Size(75, 23);
            this.AddAssessment.TabIndex = 5;
            this.AddAssessment.Text = "&Add";
            this.AddAssessment.UseVisualStyleBackColor = true;
            this.AddAssessment.Click += new System.EventHandler(this.AddAssessment_Click);
            // 
            // ScoreDomainUpDown
            // 
            this.ScoreDomainUpDown.Location = new System.Drawing.Point(145, 85);
            this.ScoreDomainUpDown.Name = "ScoreDomainUpDown";
            this.ScoreDomainUpDown.Size = new System.Drawing.Size(154, 20);
            this.ScoreDomainUpDown.TabIndex = 5;
            this.ScoreDomainUpDown.Text = "0";
            this.ScoreDomainUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CriteraComboBox
            // 
            this.CriteraComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CriteraComboBox.FormattingEnabled = true;
            this.CriteraComboBox.Location = new System.Drawing.Point(145, 58);
            this.CriteraComboBox.Name = "CriteraComboBox";
            this.CriteraComboBox.Size = new System.Drawing.Size(154, 21);
            this.CriteraComboBox.TabIndex = 4;
            // 
            // AssessmentCombo
            // 
            this.AssessmentCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AssessmentCombo.FormattingEnabled = true;
            this.AssessmentCombo.Location = new System.Drawing.Point(146, 34);
            this.AssessmentCombo.Name = "AssessmentCombo";
            this.AssessmentCombo.Size = new System.Drawing.Size(153, 21);
            this.AssessmentCombo.TabIndex = 3;
            this.AssessmentCombo.SelectionChangeCommitted += new System.EventHandler(this.AssessmentCombo_SelectionChangeCommitted);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(101, 90);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(38, 13);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Score:";
            // 
            // lblCriteria
            // 
            this.lblCriteria.AutoSize = true;
            this.lblCriteria.Location = new System.Drawing.Point(97, 63);
            this.lblCriteria.Name = "lblCriteria";
            this.lblCriteria.Size = new System.Drawing.Size(45, 13);
            this.lblCriteria.TabIndex = 1;
            this.lblCriteria.Text = "Criteria: ";
            // 
            // lblAssessment
            // 
            this.lblAssessment.AutoSize = true;
            this.lblAssessment.Location = new System.Drawing.Point(73, 37);
            this.lblAssessment.Name = "lblAssessment";
            this.lblAssessment.Size = new System.Drawing.Size(69, 13);
            this.lblAssessment.TabIndex = 0;
            this.lblAssessment.Text = "Assessment: ";
            // 
            // rtbStats
            // 
            this.rtbStats.Location = new System.Drawing.Point(19, 334);
            this.rtbStats.Name = "rtbStats";
            this.rtbStats.Size = new System.Drawing.Size(326, 119);
            this.rtbStats.TabIndex = 1;
            this.rtbStats.Text = "";
            // 
            // ViewStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 483);
            this.Controls.Add(this.AddAssessmentGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.AssessmentInfoGroup);
            this.Name = "ViewStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View Student";
            this.TopMost = true;
            this.AssessmentInfoGroup.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AddAssessmentGroupBox.ResumeLayout(false);
            this.AddAssessmentGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AssessmentInfoGroup;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEmphasis;
        private System.Windows.Forms.TextBox txtEmphasis;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TreeView AssessmentTree;
        private System.Windows.Forms.GroupBox AddAssessmentGroupBox;
        private System.Windows.Forms.Label lblAssessment;
        private System.Windows.Forms.Label lblCriteria;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.ComboBox CriteraComboBox;
        private System.Windows.Forms.ComboBox AssessmentCombo;
        private System.Windows.Forms.DomainUpDown ScoreDomainUpDown;
        private System.Windows.Forms.Button AddAssessment;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox SemesterComboBox;
        private System.Windows.Forms.TextBox txtFaculty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbStats;
    }
}