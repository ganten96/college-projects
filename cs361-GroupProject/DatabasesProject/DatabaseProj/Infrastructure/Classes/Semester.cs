using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class Semester
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public override int GetHashCode()
        {
            int hash = 17;
            
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + StartDate.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            return obj is Semester && Equals((Semester)obj);
        }

        /// <summary>
        /// Equalses the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public bool Equals(Semester p)
        {
            return Id == p.Id && StartDate == p.StartDate;
        }
    }
}
