using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Container_Classes
{
    public class SJFAvailability : IAvailability
    {
        public int ArrivalTime { get; set; }

        public int BurstTime { get; set; }

        public int CompareTo(object obj)
        {
            if (obj.GetType().Equals(typeof(IAvailability)))
            {
                IAvailability av = (IAvailability)obj;
                return ArrivalTime < av.ArrivalTime || ArrivalTime == av.ArrivalTime && BurstTime < av.ArrivalTime ? -1 : 1;
            }
            return -1;
        }
    }
}
