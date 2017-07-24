using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class DBAssessmentItem
    {
        public int UniversityId { get; set; }
        // name

        public int AssessmentId { get; set; }
        public string AssessmentName { get; set; }
        
        public int SemesterId { get; set; }
        public DateTime StartDate { get; set; }

        public int CriteriaId { get; set; }
        public string CriteriaName { get; set; }
        public int MaxScore { get; set; }

        public int Score { get; set; }
        public string FacultyName { get; set; }

        public AssessmentItem AssessmentItem { get
        {
            return new AssessmentItem { Id = AssessmentId, Name = AssessmentName };
        }}

        public Criteria Criteria { get
        {
            return new Criteria { Id = CriteriaId, Name = CriteriaName, MaxScore = MaxScore };
        } }
        public CriteriaResult CriteriaResult { get { return new CriteriaResult { AssessmentId = AssessmentId, CriteriaId = CriteriaId, Score = Score, SemesterId = SemesterId, FacultyName = FacultyName, StudentId = UniversityId }; } }

        public Semester Semester { get { return new Semester { Id = SemesterId, StartDate = StartDate};}}

        public SemesterAssessment SemesterAssessment { get { return new SemesterAssessment {Semester = Semester, AssessmentItem = AssessmentItem}; } }

        public Student Student { get { return new Student{ UniversityId = UniversityId }; } }

        public static Dictionary<SemesterAssessment, ResultList> ToCriteria(IEnumerable<DBAssessmentItem> ai)
        {
            Dictionary<SemesterAssessment, ResultList> dict = new Dictionary<SemesterAssessment, ResultList>();

            foreach (DBAssessmentItem dbai in ai)
            {
                if (dict.ContainsKey(dbai.SemesterAssessment))
                {
                    dict[dbai.SemesterAssessment].Scores.Add(dbai.Score);
                }
                else
                {
                    dict.Add(dbai.SemesterAssessment, new ResultList { Scores = new List<int> { dbai.Score }, FacultyName = dbai.FacultyName });
                }
            }

            return dict;
        }
    }
}
