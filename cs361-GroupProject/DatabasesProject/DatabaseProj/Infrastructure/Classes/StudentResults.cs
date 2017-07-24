using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class StudentResults
    {
        public Dictionary<SemesterAssessment, ResultList> Results { get; set; }
    }
}
