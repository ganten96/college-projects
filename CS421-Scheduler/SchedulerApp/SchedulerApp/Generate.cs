using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using SchedulerApp.Container_Classes;

namespace SchedulerApp
{
	public partial class Generate : Form
	{
		private static List<Process> _processes;

		public Generate()
		{
			InitializeComponent();
		}

		public static void Open ( List<Process> p )
		{
			Generate g = new Generate();
			_processes = p;

			g.ShowDialog();
		}

		private void fCFSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FCFS f = new FCFS
			{
				Processes = new Queue<Process>(_processes.Select( x => x.Clone() ).ToList()),
			};

            

			Schedule s = f.Generate();

            DoStats(s, _processes, f);
            Dictionary<int, Color> colors = DrawSchedule(s);
            DoProcess(s, colors, _processes);
		}

        private void DoStats(Schedule s, List<Process> p, Scheduler r)
        {
            lstBoxStats.Items.Clear();
            lstBoxStats.Items.Add("CPU Utilzation: " + s.CPUPercentage);
            lstBoxStats.Items.Add("Average Turnaround Time: " + s.TurnaroundTimeString);
            lstBoxStats.Items.Add("Normalized Turnaround Time: " + s.TotalNormalizedTurnaroundTimeString);
            lstBoxStats.Items.Add("Total Wait Time: " + s.CPUWaitingTimeString);
            lstBoxStats.Items.Add("Average Wait Time: " + s.AverageCPUWaitingTimeString);

            if (r.Quantum.HasValue)
            {
                lstBoxStats.Items.Add("Time Quantum: " + r.Quantum.ToString());
            }
        }

        private void DoProcess(Schedule s, Dictionary<int, Color> color, List<Process> p)
        {
            rtbProcesses.Clear();
            AppendText(rtbProcesses, "Idle (Wait) Time\n\n", Color.Yellow, true, Color.Black);

            foreach (Process pro in p)
            {
                List<string> output = s.ProcessInfo(pro);
                bool first = true;
                foreach (String o in output)
                {
                    AppendText(rtbProcesses, o + "\n", color[pro.ProcessId], first, Color.White);
                    first = false;
                }
                AppendText(rtbProcesses, "\n", color[pro.ProcessId], first, Color.White);
            }
        }

        private void AppendText(RichTextBox rtb, string text, Color color, bool bold, Color bg)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionColor = color;
            rtb.SelectionFont = new Font(rtb.Font, bold ? FontStyle.Bold : FontStyle.Regular);
            rtb.SelectionBackColor = bg;
            rtb.SelectedText = text;
        }

		private Dictionary<int, Color> DrawSchedule (Schedule s)
		{
			const int cpuYBase = 25;
			const int cpuXBase = 25;
			
			const int ioYBase = 225;
			const int ioXBase = 25;

			const int height = 100;

			Graphics formGraphics = CreateGraphics();

            formGraphics.Clear(SystemColors.Control);

			Random rand = new Random();
			Color wait = Color.Yellow;
			Dictionary<int, Color> colors = new Dictionary<int, Color>
			{
				{ 0,  wait },
			};
			HashSet<Color> used = new HashSet<Color>
			{
				wait,
			};

			foreach ( var proc in s.Processes )
			{
				Color temp;
				do
				{
					temp = Color.FromArgb( 255, rand.Next( 256 ), rand.Next( 256 ), rand.Next( 256 ) );
				} while ( used.Contains( temp ) );

				colors.Add( proc.ProcessId, temp );
				used.Add( temp );
			}

			int totalTime = s.TotalTime;

			int currentPosition = cpuXBase;

			foreach ( var entry in s.CPUTasks )
			{
				SolidBrush myBrush = new SolidBrush(colors[entry.ProcessId]);
				double percent = ( entry.End - entry.Start ) / (double) totalTime;
				int width = (int) (percent * ( 650 ) );
				formGraphics.FillRectangle(myBrush, new Rectangle(currentPosition, cpuYBase, width, height));
				currentPosition += width;
				myBrush.Dispose();
			}

			currentPosition = ioXBase;

			foreach (var entry in s.IOTasks)
			{
				SolidBrush myBrush = new SolidBrush(colors[entry.ProcessId]);
				double percent = (entry.End - entry.Start) / (double)totalTime;
				int width = (int)(percent * ( 650 ) );
				formGraphics.FillRectangle(myBrush, new Rectangle(currentPosition, ioYBase, width, height));
				currentPosition += width;
				myBrush.Dispose();
			}

			formGraphics.Dispose();

            return colors;
		}

		private void roundRobinToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RoundRobin f = new RoundRobin
			{
				Processes = new Queue<Process>(_processes.Select(x => x.Clone()).ToList()),
			};

			Schedule s = f.Generate();

            DoStats(s, _processes, f);
            Dictionary<int, Color> colors = DrawSchedule(s);
            DoProcess(s, colors, _processes);
		}

		private void shortestJobFirstNPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SJFNonPreemptive f = new SJFNonPreemptive
			{
				Processes = new Queue<Process>(_processes.Select(x => x.Clone()).ToList()),
			};

			Schedule s = f.Generate();

            DoStats(s, _processes, f);
            Dictionary<int, Color> colors = DrawSchedule(s);
            DoProcess(s, colors, _processes);
		}

		private void shortestJobFirstPToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SJFPreemptive f = new SJFPreemptive
			{
				Processes = new Queue<Process>(_processes.Select(x => x.Clone()).ToList()),
			};

			Schedule s = f.Generate();

            DoStats(s, _processes, f);
            Dictionary<int, Color> colors = DrawSchedule(s);
            DoProcess(s, colors, _processes);
		}

		private void feedbackAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
		{
            MultilevelFeedback f = new MultilevelFeedback
			{
				Processes = _processes.Select(x => x.Clone()).ToList(),
			};

			Schedule s = f.Generate();

            DoStats(s, _processes, f);
            Dictionary<int, Color> colors = DrawSchedule(s);
            DoProcess(s, colors, _processes);
		}
	}
}
