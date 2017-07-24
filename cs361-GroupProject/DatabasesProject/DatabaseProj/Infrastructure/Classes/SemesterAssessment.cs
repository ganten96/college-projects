using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class SemesterAssessment
    {
        public Semester Semester { get; set; }
        public AssessmentItem AssessmentItem { get; set; }

        public override int GetHashCode()
        {
            int hash = 17;
            // Suitable nullity checks etc, of course :)
            hash = hash * 23 + Semester.GetHashCode();
            hash = hash * 23 + AssessmentItem.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            return obj is SemesterAssessment && Equals((SemesterAssessment)obj);
        }

        /// <summary>
        /// Equalses the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public bool Equals(SemesterAssessment p)
        {
            return Semester.Equals(p.Semester) && AssessmentItem.Equals(p.AssessmentItem);
        }
    }
}
