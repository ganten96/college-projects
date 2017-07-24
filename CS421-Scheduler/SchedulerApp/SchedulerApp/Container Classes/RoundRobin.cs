using System;
using System.Collections.Generic;
using System.Linq;

namespace SchedulerApp.Container_Classes
{
    public class RoundRobin : Scheduler
    {
        public Queue<Process> Processes { get; set; }

        public override Schedule Generate()
        {
            Schedule s = new Schedule
            {
                Processes = Processes.ToList()
            };

            Queue<Process> cpuQueue = new Queue<Process>(); //final queue of processes
            Queue<Process> iOQueue = new Queue<Process>();  //final queue of io interaction
            int cpuTime = 0;                                //cpu running time 'so far'
            int ioTime = 0;                                 //io interaction time 'so far'

            Quantum = new Random().Next(8) + 4;
            int timeQuantum = Quantum.HasValue ? Quantum.Value : 10; //define the time quantum, 10 by default
            const int processChangeTime = 2; //variable to keep track of time it takes to switch cpu tasks

            foreach (Process p in Processes.OrderBy(x => x.ArrivalTime).ToList())
            {
                cpuQueue.Enqueue(p);
                // Console.WriteLine("Process enqueued " + p.ProcessId);
            }

            while (cpuQueue.Any() || iOQueue.Any())
            {
                if (cpuTime < ioTime || !iOQueue.Any())
                {

                    Process t = cpuQueue.Dequeue();

                    if (t.ArrivalTime > cpuTime)
                    {
                        s.CPUTasks.Add(new CPUTask { ProcessId = 0, Start = cpuTime, End = t.ArrivalTime, Wait = true });
                        // Console.WriteLine("CPU wait time " + (t.ArrivalTime - cpuTime));
                        cpuTime = t.ArrivalTime;

                    }
                    int taskCpuTime = t.CpuTime.Dequeue();

                    if (taskCpuTime <= timeQuantum) // if the cpu time is less than the time quantum then treat it normally
                    {
                        s.CPUTasks.Add(new CPUTask { ProcessId = t.ProcessId, Start = cpuTime, End = cpuTime + taskCpuTime, Wait = false });
                        cpuTime += taskCpuTime;

                        if (t.IOTime.Any()) //if the task finished then send it to the io queue
                        {
                            iOQueue.Enqueue(t);
                            t.ArrivalTime = cpuTime;
                            // Console.WriteLine("PId " + t.ProcessId + " sent to IOQueue.");
                        }
                    }
                    else // else we want to add the time quantum to the cpu time and decrease the cpu task time of the process
                    {
                        s.CPUTasks.Add(new CPUTask { ProcessId = t.ProcessId, Start = cpuTime, End = cpuTime + timeQuantum, Wait = false });
                        cpuTime += timeQuantum;   //increase the cpu time by the time quantum
                        //List<int> temp = t.CpuTime.ToList(); //decrement the cpu time
                        taskCpuTime -= timeQuantum;
                        t.CpuTime.Enqueue(taskCpuTime);
                        cpuQueue.Enqueue(t);      //add the process back onto the queue
                    }

                    //at the end of each process that the cpu handles we need to add the time it takes to switch processes
                    if (cpuQueue.Any())
                    {
                        s.CPUTasks.Add(new CPUTask { ProcessId = 0, Start = cpuTime, End = cpuTime + processChangeTime, Wait = true });
                        //increment the cpuTime
                        cpuTime += processChangeTime;
                    }
                }
                else
                {
                    Process t = iOQueue.Dequeue();
                    if (t.ArrivalTime > ioTime)
                    {
                        s.IOTasks.Add(new IOTask { ProcessId = 0, Start = ioTime, End = t.ArrivalTime, Wait = true });
                        // Console.WriteLine("I/O wait time " + (t.ArrivalTime - ioTime));
                        ioTime = t.ArrivalTime;
                    }
                    int ioTaskTime = t.IOTime.Dequeue(); ;
                    s.IOTasks.Add(new IOTask { ProcessId = t.ProcessId, Start = ioTime, End = ioTime + ioTaskTime, Wait = false });
                    ioTime += ioTaskTime;

                    if (t.CpuTime.Any())
                    {
                        // Console.WriteLine("PId " + t.ProcessId + " sent to CPUQueue.");
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