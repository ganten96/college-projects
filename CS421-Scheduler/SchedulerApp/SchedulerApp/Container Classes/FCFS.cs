using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulerApp.Container_Classes
{
    public class FCFS : Scheduler
    {
        public Queue<Process> Processes { get; set; }
        
        public override Schedule Generate()
        {
            Schedule s = new Schedule
            {
                Processes = Processes.ToList()
            };

            Queue<Process> cpuQueue = new Queue<Process>();
            Queue<Process> iOQueue = new Queue<Process>();
            int cpuTime = 0;
            int ioTime = 0;
            
            foreach (Process p in Processes.OrderBy(x => x.ArrivalTime).ToList())
            {
                cpuQueue.Enqueue(p);
                //Console.WriteLine("Process enqueued " + p.ProcessId);
            }
            
            while (cpuQueue.Any() || iOQueue.Any())
            {
                if (cpuTime < ioTime || !iOQueue.Any())
                {

                    Process t = cpuQueue.Dequeue();

                    if (t.ArrivalTime > cpuTime)
                    {
                        s.CPUTasks.Add(new CPUTask { ProcessId = 0, Start = cpuTime, End = t.ArrivalTime, Wait = true });
                        //Console.WriteLine("CPU wait time " + (t.ArrivalTime - cpuTime));
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
                        cpuQueue.Enqueue(t);
                        //cpu wait
                        t.ArrivalTime = ioTime;
                    }
                }
            }

            Console.WriteLine(s.ToString());
            return s;

        }
    }
}
