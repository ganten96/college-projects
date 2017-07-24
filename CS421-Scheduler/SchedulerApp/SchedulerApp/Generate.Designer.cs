namespace SchedulerApp
{
	partial class Generate
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
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fCFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundRobinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortestJobFirstNPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortestJobFirstPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstBoxStats = new System.Windows.Forms.ListBox();
            this.rtbProcesses = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fCFSToolStripMenuItem,
            this.roundRobinToolStripMenuItem,
            this.shortestJobFirstNPToolStripMenuItem,
            this.shortestJobFirstPToolStripMenuItem,
            this.feedbackAlgorithmToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // fCFSToolStripMenuItem
            // 
            this.fCFSToolStripMenuItem.Name = "fCFSToolStripMenuItem";
            this.fCFSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.fCFSToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.fCFSToolStripMenuItem.Text = "FCFS";
            this.fCFSToolStripMenuItem.Click += new System.EventHandler(this.fCFSToolStripMenuItem_Click);
            // 
            // roundRobinToolStripMenuItem
            // 
            this.roundRobinToolStripMenuItem.Name = "roundRobinToolStripMenuItem";
            this.roundRobinToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.roundRobinToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.roundRobinToolStripMenuItem.Text = "Round Robin";
            this.roundRobinToolStripMenuItem.Click += new System.EventHandler(this.roundRobinToolStripMenuItem_Click);
            // 
            // shortestJobFirstNPToolStripMenuItem
            // 
            this.shortestJobFirstNPToolStripMenuItem.Name = "shortestJobFirstNPToolStripMenuItem";
            this.shortestJobFirstNPToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.shortestJobFirstNPToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.shortestJobFirstNPToolStripMenuItem.Text = "Shortest Job First (NP)";
            this.shortestJobFirstNPToolStripMenuItem.Click += new System.EventHandler(this.shortestJobFirstNPToolStripMenuItem_Click);
            // 
            // shortestJobFirstPToolStripMenuItem
            // 
            this.shortestJobFirstPToolStripMenuItem.Name = "shortestJobFirstPToolStripMenuItem";
            this.shortestJobFirstPToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.shortestJobFirstPToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.shortestJobFirstPToolStripMenuItem.Text = "Shortest Remaining Time (P)";
            this.shortestJobFirstPToolStripMenuItem.Click += new System.EventHandler(this.shortestJobFirstPToolStripMenuItem_Click);
            // 
            // feedbackAlgorithmToolStripMenuItem
            // 
            this.feedbackAlgorithmToolStripMenuItem.Name = "feedbackAlgorithmToolStripMenuItem";
            this.feedbackAlgorithmToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.feedbackAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.feedbackAlgorithmToolStripMenuItem.Text = "Feedback Algorithm";
            this.feedbackAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.feedbackAlgorithmToolStripMenuItem_Click);
            // 
            // lstBoxStats
            // 
            this.lstBoxStats.FormattingEnabled = true;
            this.lstBoxStats.Location = new System.Drawing.Point(12, 132);
            this.lstBoxStats.Name = "lstBoxStats";
            this.lstBoxStats.Size = new System.Drawing.Size(328, 82);
            this.lstBoxStats.TabIndex = 7;
            // 
            // rtbProcesses
            // 
            this.rtbProcesses.Location = new System.Drawing.Point(346, 132);
            this.rtbProcesses.Name = "rtbProcesses";
            this.rtbProcesses.Size = new System.Drawing.Size(328, 82);
            this.rtbProcesses.TabIndex = 8;
            this.rtbProcesses.Text = "";
            this.rtbProcesses.WordWrap = false;
            // 
            // Generate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(684, 362);
            this.Controls.Add(this.rtbProcesses);
            this.Controls.Add(this.lstBoxStats);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Generate";
            this.Text = "Generate";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fCFSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundRobinToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shortestJobFirstNPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shortestJobFirstPToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem feedbackAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ListBox lstBoxStats;
        private System.Windows.Forms.RichTextBox rtbProcesses;
	}
}