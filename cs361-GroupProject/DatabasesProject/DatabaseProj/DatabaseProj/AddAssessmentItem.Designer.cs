namespace DatabaseProj
{
	partial class FrmAddAssessmentItem
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lstAvailableCriteria = new System.Windows.Forms.ListBox();
            this.lstSelectedCriteria = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(152, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 23);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 227);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 23);
            this.btnSave.TabIndex = 29;
            this.btnSave.Text = "Sa&ve";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(198, 20);
            this.txtName.TabIndex = 28;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(-6, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(84, 17);
            this.lblName.TabIndex = 26;
            this.lblName.Text = "&Name:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lstAvailableCriteria
            // 
            this.lstAvailableCriteria.FormattingEnabled = true;
            this.lstAvailableCriteria.Location = new System.Drawing.Point(12, 32);
            this.lstAvailableCriteria.Name = "lstAvailableCriteria";
            this.lstAvailableCriteria.Size = new System.Drawing.Size(134, 186);
            this.lstAvailableCriteria.TabIndex = 31;
            this.lstAvailableCriteria.DoubleClick += new System.EventHandler(this.lstAvailableCriteria_DoubleClick);
            // 
            // lstSelectedCriteria
            // 
            this.lstSelectedCriteria.FormattingEnabled = true;
            this.lstSelectedCriteria.Location = new System.Drawing.Point(153, 32);
            this.lstSelectedCriteria.Name = "lstSelectedCriteria";
            this.lstSelectedCriteria.Size = new System.Drawing.Size(134, 186);
            this.lstSelectedCriteria.TabIndex = 32;
            // 
            // FrmAddAssessmentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 262);
            this.Controls.Add(this.lstSelectedCriteria);
            this.Controls.Add(this.lstAvailableCriteria);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "FrmAddAssessmentItem";
            this.Text = "Add Assesment Item";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.ListBox lstAvailableCriteria;
		private System.Windows.Forms.ListBox lstSelectedCriteria;
	}
}