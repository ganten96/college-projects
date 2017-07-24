using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class Student
    {
        public int UniversityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public Status Status { get; set; }

        public Emphasis Emphasis { get; set; }

        public List<AssessmentItem> AssessmentItems { get; set; }

        public Dictionary<SemesterAssessment, ResultList> StudentAssessmentItems { get; set; }
    }
}
