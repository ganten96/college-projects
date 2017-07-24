using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Container_Classes
{
    public abstract class Scheduler
    {
        public List<Process> Processes { get; set; }
        public abstract Schedule Generate();

        public int? Quantum { get; set; }
    }
}
