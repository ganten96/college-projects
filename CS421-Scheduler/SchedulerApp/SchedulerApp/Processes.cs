using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchedulerApp.Container_Classes;
namespace SchedulerApp
{
    public partial class frmSchedule : Form
    {
		public List<Process> processes;

	    private ListBox.ObjectCollection procs;
	    private int pId = 1;

        public frmSchedule()
        {
            InitializeComponent();
        }

		private void Form1_Load(object sender, EventArgs e)
		{
			procs = new ListBox.ObjectCollection(lstProcess);
			processes = new List<Process>();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			Random rand = new Random();
			int number = rand.Next( 3 ) + 2;

			Queue<int> cpu = new Queue<int>();
			for ( int i = 0; i <= number; i++ )
			{
				cpu.Enqueue( rand.Next(10) + 5 );
			}

			Queue<int> io = new Queue<int>();
			for ( int i = 0; i < number; i++ )
			{
				io.Enqueue( rand.Next(5) + 5 );
			}

			Process p = new Process { ProcessId = pId++, CpuTime = cpu, IOTime = io, ArrivalTime = rand.Next( 10 ) };

            procs.Add(p);
			processes.Add(p);
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			int sel = lstProcess.SelectedIndex;
			procs.RemoveAt( sel );
			processes.RemoveAt( sel );
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			Process p = FrmAdd.ShowAndReturnObject(pId++);
			if ( p != null )
			{
				procs.Add( p );
				processes.Add( p );
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Generate.Open( processes );
		}
    }
}
