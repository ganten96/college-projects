using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure.DynamicMySQLDb;
using Infrastructure.Classes;
using Infrastructure.Database;
using System.Collections.Generic;
namespace DbProjUnitTests
{
    [TestClass]
    public class StoredProcedureUnitTest
    {
        DbprojDatabase db = new DbprojDatabase();

    /*    [TestMethod]
        public void GetStudentByFirstAndLastNameTest()
        {
            Student s = db.GetStudentInfoByFirstAndLastNameAndEmhpasis(1);
            Console.WriteLine(s.UniversityId);
            Assert.IsNotNull(s);
        }*/

        [TestMethod]
        public void GetAssessmentSemesterAverageByCriteria()
        {
            List<CriteriaResult> results = db.AssessmentSemesterAverageByCriteria(1, 1);
            Assert.IsNotNull(results);
        }

        [TestMethod]
        public void GetAssessmentAverageMaxMinByEmphasis()
        {
            List<AssessmentItem> assessmentItems = db.AssessmetAverageMaxMinByEmhpasis();
            Assert.IsNotNull(assessmentItems);
        }
        [TestMethod]
        public void GetMinMaxAvgForStudent()
        {
            AssessmentItem i = db.GetMinMaxAvgForStudent(1);
            Assert.IsNotNull(i);
        }

        [TestMethod]
        public void GetAllScoresForStudent()
        {
            List<AssessmentItem> i = db.GetAllScoresForStudent(1);
            Assert.IsNotNull(i);
        }
    }
}
