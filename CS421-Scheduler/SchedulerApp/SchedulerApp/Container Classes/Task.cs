using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Container_Classes
{
    public class Task
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int ProcessId { get; set; }
        public bool Wait { get; set; }

        public override string ToString()
        {
            return "Task Start: " + Start + " Task End: " + End + " Wait Status: " + Wait.ToString() + " for PId: " + ProcessId;
        }
    }
}
