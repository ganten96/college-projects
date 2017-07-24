using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Classes
{
    public class AssessmentItem
    {
        public AssessmentItem()
        {
            Criterion = new List<Criteria>();
            CriteriaResults = new List<CriteriaResult>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double AverageScore { get; set; }

        public int LowestScore { get; set; }

        public int HighestScore { get; set; }

        public List<Criteria> Criterion { get; set; }

        public List<CriteriaResult> CriteriaResults { get; set; }

        public void AddCrieria(dynamic id, dynamic name, dynamic maxScore)
        {
            Criteria c = new Criteria
            {
                Id = id,
                Name = name,
                MaxScore = maxScore
            };

            Criterion.Add(c);
        }

		public string AddQuery {get
		{
			// todo return object for verification
			return "INSERT INTO AssessmentItem (`Name`) VALUES ('" + Name + "'); INSERT INTO AssessmentCriteria (`AssessmentId`, `CriteriaId`) VALUES " + Criterion.Select(x => "( LAST_INSERT_ID(), " + x.Id + " )").Aggregate((x, y) => x + ", " + y) + "; SELECT 1 AS `Id`;";
		}}

        public override int GetHashCode()
        {
            int hash = 17;

            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + Name.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            return obj is AssessmentItem && Equals((AssessmentItem)obj);
        }

        /// <summary>
        /// Equalses the specified p.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        public bool Equals(AssessmentItem p)
        {
            return Id == p.Id;
        }
    }
}
