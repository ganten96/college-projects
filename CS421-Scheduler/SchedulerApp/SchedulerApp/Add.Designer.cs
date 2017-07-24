namespace SchedulerApp
{
	partial class FrmAdd
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
			this.lblArrival = new System.Windows.Forms.Label();
			this.lblCPU = new System.Windows.Forms.Label();
			this.lblIO = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.nudArrival = new System.Windows.Forms.NumericUpDown();
			this.dgvCPU = new System.Windows.Forms.DataGridView();
			this.dgvIO = new System.Windows.Forms.DataGridView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.IOBurstTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CPUBurstTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.nudArrival)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCPU)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvIO)).BeginInit();
			this.SuspendLayout();
			// 
			// lblArrival
			// 
			this.lblArrival.AutoSize = true;
			this.lblArrival.Location = new System.Drawing.Point(13, 13);
			this.lblArrival.Name = "lblArrival";
			this.lblArrival.Size = new System.Drawing.Size(68, 13);
			this.lblArrival.TabIndex = 0;
			this.lblArrival.Text = "Arrival Time: ";
			// 
			// lblCPU
			// 
			this.lblCPU.AutoSize = true;
			this.lblCPU.Location = new System.Drawing.Point(13, 37);
			this.lblCPU.Name = "lblCPU";
			this.lblCPU.Size = new System.Drawing.Size(63, 13);
			this.lblCPU.TabIndex = 1;
			this.lblCPU.Text = "CPU Times:";
			// 
			// lblIO
			// 
			this.lblIO.AutoSize = true;
			this.lblIO.Location = new System.Drawing.Point(14, 193);
			this.lblIO.Name = "lblIO";
			this.lblIO.Size = new System.Drawing.Size(52, 13);
			this.lblIO.TabIndex = 2;
			this.lblIO.Text = "IO Times:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 352);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(60, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Process Id:";
			// 
			// nudArrival
			// 
			this.nudArrival.Location = new System.Drawing.Point(81, 11);
			this.nudArrival.Name = "nudArrival";
			this.nudArrival.Size = new System.Drawing.Size(120, 20);
			this.nudArrival.TabIndex = 5;
			// 
			// dgvCPU
			// 
			this.dgvCPU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCPU.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CPUBurstTime});
			this.dgvCPU.Location = new System.Drawing.Point(81, 37);
			this.dgvCPU.Name = "dgvCPU";
			this.dgvCPU.Size = new System.Drawing.Size(145, 150);
			this.dgvCPU.TabIndex = 6;
			// 
			// dgvIO
			// 
			this.dgvIO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IOBurstTime});
			this.dgvIO.Location = new System.Drawing.Point(81, 193);
			this.dgvIO.Name = "dgvIO";
			this.dgvIO.Size = new System.Drawing.Size(145, 150);
			this.dgvIO.TabIndex = 7;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(34, 375);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 9;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(115, 375);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(81, 349);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 11;
			// 
			// IOBurstTime
			// 
			this.IOBurstTime.HeaderText = "Burst Time";
			this.IOBurstTime.Name = "IOBurstTime";
			// 
			// CPUBurstTime
			// 
			this.CPUBurstTime.HeaderText = "BurstTime";
			this.CPUBurstTime.Name = "CPUBurstTime";
			// 
			// frmAdd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(243, 411);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgvIO);
			this.Controls.Add(this.dgvCPU);
			this.Controls.Add(this.nudArrival);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblIO);
			this.Controls.Add(this.lblCPU);
			this.Controls.Add(this.lblArrival);
			this.Name = "FrmAdd";
			this.Text = "Add";
			this.Load += new System.EventHandler(this.Add_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudArrival)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCPU)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvIO)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblArrival;
		private System.Windows.Forms.Label lblCPU;
		private System.Windows.Forms.Label lblIO;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nudArrival;
		private System.Windows.Forms.DataGridView dgvCPU;
		private System.Windows.Forms.DataGridView dgvIO;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.DataGridViewTextBoxColumn CPUBurstTime;
		private System.Windows.Forms.DataGridViewTextBoxColumn IOBurstTime;
	}
}