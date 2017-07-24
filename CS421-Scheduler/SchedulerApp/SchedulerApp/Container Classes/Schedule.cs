using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SchedulerApp.Container_Classes
{
    public class Schedule
    {
        public List<CPUTask> CPUTasks { get; set; }
        public List<IOTask> IOTasks { get; set; }
        public List<Process> Processes { get; set; }

        private decimal CPUUtilization
        {
            get 
            { 
                int m = CPUTasks.Max(x => x.End);
                return decimal.Round((decimal)((m - CPUWaitingTime)/(double)m), 2);
            }
        }

        public string IOPercentage
        {
            get { return IOUtilization + "%"; }
        }

        private double IOUtilization
        {
            get 
            { int m = IOTasks.Max(x => x.End);
                return (m - IOWaitingTime)/(double)m;
            }
        }

        public string CPUPercentage
        {
            get { return CPUUtilization * 100 + "%"; }
        }

        public int CPUWaitingTime 
        {
            get { return CPUTasks.Where(x => x.Wait).Sum(x => (x.End - x.Start)); }
        }

        public string CPUWaitingTimeString
        {
            get { return CPUWaitingTime.ToString(CultureInfo.InvariantCulture); }
        }

        public double AverageCPUWaitingTime
        {
            get { return CPUWaitingTime / (double) Processes.Count; }
        }

        public string AverageCPUWaitingTimeString
        {
            get { return AverageCPUWaitingTime.ToString("F2"); }
        }

        public int IOWaitingTime
        {
            get { return IOTasks.Where(x => x.Wait).Sum(x => (x.End - x.Start)); }
        }

        public double TurnaroundTime
        {
            get
            {
                int tt = 0;
                foreach (var process in Processes)
                {
                    Process process1 = process;
                    tt += CPUTasks.Where(x => x.ProcessId == process1.ProcessId).Max(x => x.End) - process.OriginalArrivalTime;
                }

                //int tt = (from process in Processes let process1 = process select CPUTasks.Where(x => x.ProcessId == process1.ProcessId).Max(x => x.End) - process.ArrivalTime).Sum();

                return tt/(double) Processes.Count;
            }
        }

        public int ProcessFinishTime(Process p)
        {
            return CPUTasks.Where(x => x.ProcessId == p.ProcessId).Max(x => x.End);
        }

        public string ProcessFinishTimeString (Process p)
        {
                return ProcessFinishTime(p).ToString("F0");
        }

        public int ProcessTurnaroundTime(Process p)
        {
            return ProcessFinishTime(p) - p.ArrivalTime;
        }

        public string ProcessTurnaroundTimeString(Process p)
        {
            return ProcessTurnaroundTime(p).ToString("F0");
        }

        public double ProcessNormalizedTurnaroundTime(Process p)
        {
            return ProcessTurnaroundTime(p) / ( (double)(TotalTime - CPUWaitingTime) );
        }

        public string ProcessNormalizedTurnaroundTimeString(Process p)
        {
            return ProcessNormalizedTurnaroundTime(p).ToString("F2");
        }

        public List<string> ProcessInfo(Process p)
        {
            List<string> data = new List<string>();
            data.Add("Process " + p.ProcessId);
            data.Add("Finish Time: " + ProcessFinishTimeString(p));
            data.Add("Turnaround Time: " + ProcessTurnaroundTimeString(p));
            data.Add("Normalized Turnaround Time: " + ProcessNormalizedTurnaroundTimeString(p));

            return data;
        }

        public double TotalNormalizedTurnaroundTime
        {
            get
            {
                return TurnaroundTime / ((double)(TotalTime - CPUWaitingTime));
            }
        }

        public string TotalNormalizedTurnaroundTimeString
        {
            get
            {
                return TotalNormalizedTurnaroundTime.ToString("F2");
            }
        }

        public string TurnaroundTimeString
        {
            get
            {
                return TurnaroundTime.ToString("F2");
            }
        }

	    public int TotalTime
	    {
			get { return CPUTasks.Count > 0 ? CPUTasks.Max( x => x.End ) : 0; }
	    }

        public Schedule()
        {
            CPUTasks = new List<CPUTask>();
            IOTasks = new List<IOTask>();
        }

        public override string ToString()
        {
            return "CPU Tasks: {\n" + CPUTasks.Select(x => x.ToString()).Aggregate((x, y) => x + "\n" + y) +
                   "}\nIO Tasks: {\n"
                   + IOTasks.Select(x => x.ToString()).Aggregate((x, y) => x + "\n" + y) + "}\n"
                   + "CPU WAIT TIME OVERALL: " + CPUWaitingTime + "\nIO WAIT TIME OVERALL: " + IOWaitingTime + "\n" 
                   + "CPU Utilization: " + CPUPercentage + "\n"
                   + "Process Turnaround Time: " + TurnaroundTime;
        }

        
    }
}
