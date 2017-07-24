using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Container_Classes
{
    public class SJFPreemptive : Scheduler
    {
        public Queue<Process> Processes { get; set; }

        public override Schedule Generate()
        {
            List<Process> CPUTasks = new List<Process>();
            Queue<Process> iOQueue = new Queue<Process>();
            Queue<Process>ArrivalQueue = new Queue<Process>();
            
            Schedule s = new Schedule
            {
                Processes = Processes.ToList(),
                CPUTasks = new List<CPUTask>(),
                IOTasks = new List<IOTask>(),
            };

            ArrivalQueue = new Queue<Process>(Processes.OrderBy(x => x.ArrivalTime).ToList());
            int currentTime = 0;
            
            Process cpuProc = null;
            Process ioProc = null;

            while(CPUTasks.Any() || iOQueue.Any() || ArrivalQueue.Any() || cpuProc != null || ioProc != null)
            {
                // can we work on new processes
                if(ArrivalQueue.Any())
                {
                    Queue<Process> temp = new Queue<Process>();

                    foreach ( var a in ArrivalQueue ) {
                        if (a.ArrivalTime <= currentTime ) {
                            CPUTasks.Add(a);
                        } else {
                            temp.Enqueue(a);
                        }
                    }

                    ArrivalQueue = temp;
                }
                
                // ioTask is done
                if (ioProc != null && ioProc.IOTime.ElementAt(0) <= 0) {
                    ioProc.IOTime.Dequeue();
                    CPUTasks.Add(ioProc);
                    ioProc = null;
                }

                // is cputask done?
                if (cpuProc != null && cpuProc.CpuTime.ElementAt(0) <= 0)
                {
                    // is this done done?
                    if (cpuProc.IOTime.Count > 0)
                    {
                        cpuProc.CpuTime.Dequeue();
                        // nah dawg
                        iOQueue.Enqueue(cpuProc);
                    } // yea dawg

                    cpuProc = null;
                }

                // see if we can add new ones
                if(iOQueue.Any() && ioProc == null)
                {
                    Process t = iOQueue.Dequeue();
                    ioProc = t;
                }

                CPUTasks = CPUTasks.OrderBy(x => x.CpuTime.ElementAt(0)).ToList();

                // preempt if necessary
                if (CPUTasks.Any() && cpuProc != null && CPUTasks.ElementAt(0).CpuTime.ElementAt(0) < cpuProc.CpuTime.ElementAt(0))
                {
                    CPUTasks.Add(cpuProc);
                    cpuProc = CPUTasks.ElementAt(0);
                    CPUTasks.RemoveAt(0);
                }

                // see if we can start new cpu tasks
                if (CPUTasks.Any() && cpuProc == null)
                {
                    cpuProc = CPUTasks.ElementAt(0);
                    CPUTasks.RemoveAt(0);
                }

                // iO did things
                if(ioProc != null)
                {
                    int[] shit = ioProc.IOTime.ToArray();
                    shit[0] = shit[0] - 1;
                    ioProc.IOTime = new Queue<int>(shit);
                }

                s.IOTasks.Add(new IOTask { Start = currentTime, End = currentTime + 1, Wait = (ioProc == null), ProcessId = (ioProc != null ? ioProc.ProcessId : 0), });

                // cpu is lifting
                if (cpuProc != null)
                {
                    int[] otherShit = cpuProc.CpuTime.ToArray();
                    otherShit[0] = otherShit[0] - 1;
                    cpuProc.CpuTime = new Queue<int>(otherShit);
                }

                s.CPUTasks.Add(new CPUTask { Start = currentTime, End = currentTime + 1, Wait = cpuProc == null, ProcessId = (cpuProc != null ? cpuProc.ProcessId : 0), });

                currentTime++;
            }

            return s;
        }
    }
}
