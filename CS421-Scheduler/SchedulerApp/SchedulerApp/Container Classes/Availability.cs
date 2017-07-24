using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Container_Classes
{
    public interface IAvailability : IComparable
    {
        int ArrivalTime { get; set; }
        int BurstTime { get; set; }
        
    }
}
