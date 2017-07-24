using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Container_Classes
{
    public class MultilevelFeedback : Scheduler
    {
        //Queue of all processess.
        //public List<Process> processes { get; set; }

        //FCFS Priority 1
        Queue<Process> cpuQueue1 = new Queue<Process>();
        //FCFS Priority 2
        Queue<Process> cpuQueue2 = new Queue<Process>();
        //FCFS Priority 3 
        Queue<Process> cpuQueue3 = new Queue<Process>();
        //some fucking queue
        Queue<Process> cpuQueue4 = new Queue<Process>();

        Queue<Process> iOQueue = new Queue<Process>();
        /*Queue<IOTask> ioTasks = new Queue<IOTask>();
        Queue<CPUTask> cpuTasks = new Queue<CPUTask>();*/

        public const int cpuTime = 0;
        public const int ioTime = 0;
        


        public override Schedule Generate()
        {
            Quantum = new Random().Next(3) + 4;
            int timeQuantaP1 = Quantum.HasValue ? Quantum.Value : 5;
            int timeQuantaP2 = timeQuantaP1 * 2;
            int timeQuantaP3 = timeQuantaP2 * 2;

            int[] timeQuantas = new int[] { timeQuantaP1, timeQuantaP2, timeQuantaP3, Int32.MaxValue };

            Schedule s = new Schedule 
            { 
                Processes = Processes.ToList()
            };

            Queue<Process> notArrived = new Queue<Process>();
            foreach (Process p in Processes.OrderBy(x => x.ArrivalTime).ToList())
            {
                notArrived.Enqueue(p);
                //Console.WriteLine("Process enqueued " + p.ProcessId);
            }

            int currentTime = 0;

            Process cpuProc = null;
            int curQueue = 0;
            Process ioProc = null;

            //fix sentinel condition
            while (cpuQueue1.Any() || cpuQueue2.Any() || cpuQueue3.Any() || cpuQueue4.Any() || iOQueue.Any() || notArrived.Any() || cpuProc != null || ioProc != null)
            {
                // first we check if we can add any of the not arrived processes
                while (notArrived.Any() && notArrived.Peek().ArrivalTime <= currentTime)
                {
                    cpuQueue1.Enqueue(notArrived.Dequeue());
                }

                // ioTask is done
                if (ioProc != null && ioProc.IOTime.ElementAt(0) <= 0)
                {
                    ioProc.IOTime.Dequeue();
                    cpuQueue1.Enqueue(ioProc);
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

                // check if we have been running for too longk
                if (cpuProc != null && cpuProc.RunningFor >= timeQuantas[curQueue - 1])
                {
                    if (curQueue == 1)
                    {
                        cpuQueue2.Enqueue(cpuProc);
                    }
                    else if (curQueue == 2)
                    {
                        cpuQueue3.Enqueue(cpuProc);
                    }
                    else
                    {
                        cpuQueue4.Enqueue(cpuProc);
                    }

                    cpuProc = null;
                }

                // see if we can add new ones
                if (iOQueue.Any() && ioProc == null)
                {
                    ioProc = iOQueue.Dequeue();
                }

                // see if we can start new cpu tasks
                if ((cpuQueue1.Any() || cpuQueue2.Any() || cpuQueue3.Any() || cpuQueue4.Any()) && cpuProc == null)
                {
                    if (cpuQueue1.Any()) //see if there's anything at priority 1
                    {
                        cpuProc = cpuQueue1.Dequeue();
                        curQueue = 1;
                    }
                    else if (cpuQueue2.Any()) //see if there's anything at priority 2
                    {
                        cpuProc = cpuQueue2.Dequeue();
                        curQueue = 2;
                    }
                    else if (cpuQueue3.Any()) //see if there's anything at priority 3
                    {
                        cpuProc = cpuQueue3.Dequeue();
                        curQueue = 3;
                    }
                    else if (cpuQueue4.Any()) //see if there's anything in priority 4
                    {
                        cpuProc = cpuQueue4.Dequeue();
                        curQueue = 4;
                    }
                }

                // iO doing stuff
                if (ioProc != null)
                {
                    ioProc.RunningFor++;
                    ioProc.IOTime = ioProc.NewIOTime(1);
                }

                s.IOTasks.Add(new IOTask { Start = currentTime, End = currentTime + 1, Wait = (ioProc == null), ProcessId = (ioProc != null ? ioProc.ProcessId : 0), });

                // cpu is lifting
                if (cpuProc != null)
                {
                    cpuProc.RunningFor++;

                    cpuProc.CpuTime = cpuProc.NewCPUTime(1);
                }

                s.CPUTasks.Add(new CPUTask { Start = currentTime, End = currentTime + 1, Wait = cpuProc == null, ProcessId = (cpuProc != null ? cpuProc.ProcessId : 0), });
                currentTime++;
            }

            return s;
        }
    }
}
