using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class CriteriaResult
    {
        public int StudentId { get; set; }
        public int AssessmentId { get; set; }
        public int CriteriaId { get; set; }
        public int SemesterId { get; set; }
        public int Score { get; set; }
        public string FacultyName { get; set; }
    }
}
