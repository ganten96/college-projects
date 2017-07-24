using System.Collections.Generic;
using System.Linq;

namespace SchedulerApp.Container_Classes
{
    public class SJFNonPreemptive : Scheduler
    {
        public Queue<Process> Processes { get; set; }
        public override Schedule Generate()
        {
            List<Process> CPUTasks = new List<Process>();
            Queue<Process> iOQueue = new Queue<Process>();
            Schedule s = new Schedule
            {
                Processes = Processes.ToList()
            };

            int cpuTime = 0;
            int ioTime = 0;

            foreach(Process p in Processes)
            {
                CPUTasks.Add(p);
            }

            while(CPUTasks.Any() || iOQueue.Any())
            {
                if(cpuTime < ioTime || !iOQueue.Any())
                {
	                int time = cpuTime;
	                CPUTasks = CPUTasks.OrderBy(x => (x.ArrivalTime > time ? 1 : 0)).ThenBy(x => x.CpuTime.ElementAtOrDefault(0)).ToList();
                    Process t = CPUTasks.ElementAt(0);
                    CPUTasks.RemoveAt(0);

                    if(t.ArrivalTime > cpuTime)
                    {
                        s.CPUTasks.Add(new CPUTask { ProcessId = 0, Start = cpuTime, End = t.ArrivalTime, Wait = true});
                        cpuTime = t.ArrivalTime;
                    }
                    int taskCpuTime = t.CpuTime.Dequeue();
                    s.CPUTasks.Add(new CPUTask { ProcessId = t.ProcessId, Start = cpuTime, End = cpuTime + taskCpuTime, Wait = false });
                    cpuTime += taskCpuTime;

                    if (t.IOTime.Any())
                    {
                        iOQueue.Enqueue(t);
                        t.ArrivalTime = cpuTime;
                        //Console.WriteLine("PId " + t.ProcessId + " sent to IOQueue.");
                    }
                }
                else
                {
                    Process t = iOQueue.Dequeue();
                    if (t.ArrivalTime > ioTime)
                    {
                        s.IOTasks.Add(new IOTask { ProcessId = 0, Start = ioTime, End = t.ArrivalTime, Wait = true });
                        //Console.WriteLine("I/O wait time " + (t.ArrivalTime - ioTime));
                        ioTime = t.ArrivalTime;
                    }
                    int ioTaskTime = t.IOTime.Dequeue(); ;
                    s.IOTasks.Add(new IOTask { ProcessId = t.ProcessId, Start = ioTime, End = ioTime + ioTaskTime, Wait = false });
                    ioTime += ioTaskTime;

                    if (t.CpuTime.Any())
                    {
                        //Console.WriteLine("PId " + t.ProcessId + " sent to CPUQueue.");
                        CPUTasks.Add(t);
                        //cpu wait
                        t.ArrivalTime = ioTime;
                    }
                }
            }

            return s;
        }

        private SJFAvailability getAvailability(Process p, bool isCpuBurst)
        {
            return new SJFAvailability
            {
                ArrivalTime = p.ArrivalTime,
                BurstTime = (isCpuBurst ? p.CpuTime : p.IOTime).ElementAtOrDefault(0)
            };
        }
    }
}
