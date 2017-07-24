using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerApp.Container_Classes
{
	[Serializable]
    public class Process
    {
        public int ReadyAt { get; set; }
        public int ArrivalTime { get; set; }
        public Queue<int> CpuTime { get; set; }
        public Queue<int> IOTime { get; set; }
        public int ProcessId { get; set; }
        public int OriginalArrivalTime { get; set; }

        public int RunningFor { get; set; }

        public Queue<int> NewCPUTime(int dec)
        {
            Queue<int> q = new Queue<int>();

            if (CpuTime.Count > 0)
            {
                List<int> temp = new List<int>(CpuTime.ToList());
                temp[0] -= dec;
                q = new Queue<int>(temp);
            }

            return q;
        }

        public Process()
        {
            RunningFor = 0;
        }

        public Queue<int> NewIOTime(int dec)
        {
            Queue<int> q = new Queue<int>();

            if (IOTime.Count > 0)
            {
                List<int> temp = new List<int>(IOTime.ToList());
                temp[0] -= dec;
                q = new Queue<int>(temp);
            }

            return q;
        }

		public override string ToString()
		{
			return ProcessId + " - AT: " + ArrivalTime + " CT: [ " + CpuTime.Select( x => x.ToString( CultureInfo.InvariantCulture ) ).DefaultIfEmpty().Aggregate( (x,y) => x + ", " + y ) + " ] IT: [ " + IOTime.Select( x => x.ToString( CultureInfo.InvariantCulture ) ).DefaultIfEmpty().Aggregate( (x,y)=> x + ", " + y ) + " ]";
		}

	    public Process Clone ()
	    {
			MemoryStream ms = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();

			bf.Serialize(ms, this);

			ms.Position = 0;
			object obj = bf.Deserialize(ms);
			ms.Close();

			return obj as Process;
	    }
    }
}
