using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using SchedulerApp.Container_Classes;
using SchedulerApp.Properties;

namespace SchedulerApp
{
	public partial class FrmAdd : Form
	{
		public FrmAdd()
		{
			InitializeComponent();
		}

		private void Add_Load(object sender, EventArgs e)
		{

		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		public static Process ShowAndReturnObject (int pId)
		{
			var dlg = new FrmAdd
			{
				textBox1 =
				{
					Text = pId.ToString( CultureInfo.InvariantCulture )
				}
			};

			while(true)
			{
				DialogResult ans = dlg.ShowDialog();
				Queue<int> cpu = new Queue<int>();
				foreach (DataGridViewRow dgvr in dlg.dgvCPU.Rows)
				{
					int result;
					if (dgvr == null || dgvr.Cells[0] == null || dgvr.Cells[0].Value == null)
					{
						continue;
					}
					bool parse = Int32.TryParse(dgvr.Cells[0].Value.ToString(), out result);
					if (parse)
					{
						cpu.Enqueue(result);
					}
				}

				Queue<int> io = new Queue<int>();
				foreach (DataGridViewRow dgvr in dlg.dgvIO.Rows)
				{
					int result;
					if (dgvr == null || dgvr.Cells[0] == null || dgvr.Cells[0].Value == null)
					{
						continue;
					}
					bool parse = Int32.TryParse(dgvr.Cells[0].Value.ToString(), out result);
					if (parse)
					{
						io.Enqueue(result);
					}
				}

				if (ans == DialogResult.OK && (cpu.Count - io.Count) == 1)
				{
					var obj = new Process
					{
						ArrivalTime = Int32.Parse(dlg.nudArrival.Text),
						CpuTime = cpu,
						IOTime = io,
						ProcessId = pId,
					};

					return obj;
				}

				if (ans == DialogResult.OK)
				{
					MessageBox.Show(Resources.frmAdd_ShowAndReturnObject_Invalid_ratio_of_CPU_Tasks_and_IO_Tasks_, Resources.frmAdd_ShowAndReturnObject_Error);
					continue;
				}

				return null;
			}
			
			
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
