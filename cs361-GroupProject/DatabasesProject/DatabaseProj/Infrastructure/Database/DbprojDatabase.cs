using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DynamicMySQLDb;
using Infrastructure.Classes;
using System.Data.SqlClient;
namespace Infrastructure.Database
{
    public class DbprojDatabase : MySQLDynamicDb
    {
        public Student GetStudentByFirstAndLastName(string firstName, string lastName)
        {
            try
            {
                return RunProcedure<Student>("GetStudentIdByFirstAndLastName", new { firstName, lastName }).First();
            }
            catch(SqlException e)
            {
                throw;
            }
        }

        public bool AddSemester(Semester s)
        {
            try
            {
                return ExecuteQuery("AddSemester", new { sDate = s.StartDate });
            }
            catch(SqlException e)
            {
                throw e;
            }
        }
        public List<CriteriaResult> AssessmentSemesterAverageByCriteria(int assessmentId, int semesterId)
        {
            try
            {
                return RunProcedure<CriteriaResult>("AssessmentSemesterAverageByCriteria", new { assessment = assessmentId, semester = semesterId }).ToList();
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

        public List<Semester> GetAllSemesters()
        {
            try
            {
                return RunProcedure<Semester>("GetAllSemesters", new { }).ToList();
            }
            catch(SqlException e)
            {
                throw;
            }
        }

        public List<AssessmentItem> GetAllAssessments()
        {
            try
            {
                return RunProcedure<AssessmentItem>("GetAllAssessments", new { }).ToList();
            }
            catch(SqlException e)
            {
                throw;
            }
        }

        public List<CriteriaResult> AllScoresForStudent(int studentId)
        {
            try
            {
                return RunProcedure<CriteriaResult>("AllScoresForStudent", new { studentId }).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public List<Student> GetStudentLikeFirstAndLastNameAndEmphasis(string firstName, string lastName,
                                                                       string emphasis)
        {
            try
            {
                List<Student> students = new List<Student>();
                IEnumerable<dynamic> rows = RunProcedure<dynamic>("GetStudentsLikeFirstAndLastName",
                                                                       new {firstName, lastName, emphasis});
                foreach (dynamic row in rows)
                {
                    students.Add(new Student
                    {
                        UniversityId = row.UniversityId,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        MiddleName = row.MiddleName,
                        Status = (Status)row.Status,
                        Emphasis = new Emphasis()
                            {
                                Name = row.Name,
                                Id = row.Id
                            }
                    });
                }
                return students;
            }
            catch (SqlException e)
            {
                
                throw e;
            }  
        }

        public Student GetStudentByStudentId(int studentId)
        {
            try
            {
                return RunProcedure<Student>("GetStudentInfoByStudentId", new { studentId }).FirstOrDefault();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public Student GetStudentInfoByStudentId(int studentId)
        {
            try
            {
                Student s = GetStudentByStudentId(studentId);
                s.StudentAssessmentItems = DBAssessmentItem.ToCriteria(RunProcedure<DBAssessmentItem>("GetStudentAssessmentsById", new { studentId }));
                return s;
            }
           catch(SqlException e)
            {
                throw e;
            }
        }

        public bool InsertStudentAssessment(int stuId, int asId, int critId, int score, int semId, string facultyName)
        {
            try
            {
                return ExecuteQuery("InsertStudentAssessment", new { stuId, asId, critId, score, semId, facultyName });
            }
            catch(SqlException e)
            {
                throw;
            }
        }

		public bool InsertCriteria(Criteria c)
		{
			try
			{
				return ExecuteQuery("AddCriteria", new { name = c.Name, maxScore = c.MaxScore });
			}
			catch (SqlException e)
			{
				throw e;
			}
		}

        public bool InsertStudent(Student s)
        {
            try
            {
                return ExecuteQuery("AddStudent", new { firstName = s.FirstName, lastName = s.LastName, middleName = s.MiddleName, status = (int)s.Status, emphasisId = s.Emphasis.Id });
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

		public bool InsertAssessmentItem ( AssessmentItem ai )
		{
			RawQuery( ai.AddQuery );
			return true;
		}

        public List<AssessmentItem> AssessmetAverageMaxMinByEmhpasis()
        {
            try
            {
                return RunProcedure<AssessmentItem>("AssessmentAverageMaxMinByEmphasis", new {}).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public AssessmentItem GetMinMaxAvgForStudent(int studentId)
        {
            try
            {
                return RunProcedure<AssessmentItem>("MaxMinAvgForStudent", new { studentId }).FirstOrDefault();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

        public List<AssessmentItem> GetAllScoresForStudent(int studentId)
        {
            try
            {
                return RunProcedure<AssessmentItem>("AllScoresForStudent", new { studentId }).ToList();
            }
            catch(SqlException e)
            {
                throw e;
            }
        }

		public List<Criteria> GetAllCriteria()
		{
			try
			{
				return RunProcedure<Criteria>("GetAllCriteria", new {}).ToList();
			}
			catch (SqlException e)
			{
				throw e;
			}
		}

        public bool UpdateStudent(Student s)
        {
            try
            {
                return ExecuteQuery("EditStudent",
                                    new
                                        {
                                            //fN VARCHAR(50), IN lN VARCHAR(50), IN mN VARCHAR(50), IN sT INT, IN eId
                                            sId = s.UniversityId,
                                            fN = s.FirstName,
                                            lN = s.LastName,
                                            mN = s.MiddleName,
                                            sT = (int)s.Status,
                                            eId = s.Emphasis.Id
                                        });
            }
            catch (SqlException e)
            {
                
                throw e;
            }
        }

        public List<Criteria>GetCriteriasForAssessment(int assessmentId)
        {
            try
            {
                return RunProcedure<Criteria>("GetCriteriaForAssessmentId", new { assessmentId }).ToList();
            }
            catch(SqlException e)
            {
                throw;
            }
        }

        public bool EditAssessment(string newName, int curId)
        {
            return ExecuteQuery("EditAssessment", new { newName, curId });
        }

        public bool DeleteAssessment(int inId)
        {
            try
            {
                return ExecuteQuery("DeleteAssessment", new { inId });
            }
            catch
            {
                return false;
            }
        }

        public bool EditCriteria(string inName, int inMaxScore, int inId)
        {
            return ExecuteQuery("EditCriteria", new { inName, inMaxScore, inId });
        }

        public bool DeleteCriteria(int inId)
        {
            try
            {
                return ExecuteQuery("DeleteCriteria", new { inId });
            }
            catch
            {
                return false;
            }
        }

		public dynamic RawQuery (string query)
		{
			try
			{
				return base.RawQuery( query );
			}
			catch ( Exception )
			{
				throw;
			}
		}
    }
}
