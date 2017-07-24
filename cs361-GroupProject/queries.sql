-- Nic Moon
-- Nick Ganter
-- Lisa Poeschl

-- Phase 3
-- CS361 - Databases

-- TODOs
-- We might have to provide similar functions that find
-- the Ids for an item (by name for example) and call into
-- the existing functionss with those

-- 1. A query to display the average score for a specific criterion 
--    (identified by id such as A1F12C1) in a specific CDAI in a 
--    specific semester.

CREATE FUNCTION AssessmentSemesterCriterionAverage
	(assessment INT, semester INT, criteria INT)
BEGIN
	DECLARE average = SELECT
		AVG(Score)
	FROM
		CriteriaResult cr
	WHERE
		cr.AssessmentId = assessment
		AND
		cr.SemesterId = semester
		AND
		cr.CriteriaId = criteria
	LIMIT
		1;

	RETURN average;
END

-- 2. A query to display the average scores for all criteria in a 
--    specific CDAI in a specific semester (CDAI identified by id 
--    such as A1F12)

CREATE PROCEDURE AssessmentSemesterAverageByCriteria
	(assessment INT, semester INT)
BEGIN
	SELECT
		cr.CriteriaId,
		AVG(Score)
	FROM
		CriteriaResult cr
	WHERE
		cr.AssessmentId = assessment
		AND
		cr.SemesterId = semester
	GROUP BY
		cr.CriteriaId;

	RETURN average;
END

-- 3. A query to display the average scores for all criteria in a
--    specific CDAI (identified by id such as A1)

CREATE FUNCTION AssessmentAverageByCriteria
	(assessment INT)
BEGIN
	SELECT
		cr.CriteriaId,
		AVG(Score)
	FROM
		CriteriaResult cr
	WHERE
		cr.AssessmentId = assessment
	GROUP BY
		cr.CriteriaId;

	RETURN average;
END

-- 4. A query to display the average score over all criteria in a 
--    specific CDAI in a specific semester (CDAI identified by id 
--    such as A1F12)

CREATE FUNCTION AssessmentSemesterAverage
	(assessment INT, semester INT)
BEGIN
	DECLARE average = SELECT
		AVG(Score)
	FROM
		CriteriaResult cr
	WHERE
		cr.AssessmentId = assessment
		AND
		cr.SemesterId = semester
	LIMIT
		1;

	RETURN average;
END

-- 5. A query to display the average score over all criteria for a
-- specific CDAI (identified by id such as A1)

CREATE FUNCTION AssessmentAverage
	(assessment INT)
BEGIN
	DECLARE average = SELECT
		AVG(Score)
	FROM
		CriteriaResult cr
	WHERE
		cr.AssessmentId = assessment
	LIMIT
		1;

	RETURN average;
END

-- 6. A query to identify the CDAI with the highest average score 
--    across all CDAIs.

CREATE FUNCTION AssessmentWithHighestAverage
BEGIN
	DECLARE results = (
		SELECT
			cr.AssessmentId,
			AVG(Score) AS AverageScore
		FROM
			CriteriaResult cr
		GROUP BY
			cr.AssessmentId
		ORDER BY
			AverageScore DESC
		LIMIT
			1
	);

	DECLARE max = (
		SELECT
			AverageScore
		FROM
			results
		LIMIT
			1
	);

	RETURN max;
END

-- 7. A query to identify the CDAI with the lowest average score 
--    across all CDAIs.

CREATE FUNCTION AssessmentWithLowestAverage
BEGIN
	DECLARE results = (
		SELECT
			cr.AssessmentId,
			AVG(Score) AS AverageScore
		FROM
			CriteriaResult cr
		GROUP BY
			cr.AssessmentId
		ORDER BY
			AverageScore ASC
		LIMIT
			1
	);

	DECLARE max = (
		SELECT
			AverageScore
		FROM
			results
		LIMIT
			1
	);

	RETURN max;
END

-- 8. A query to provide the average, lowest and highest CDAI scores, 
--    over all CDAI scores in each emphasis, grouped by emphasis. 
--    Include “undeclared” as its own category.
CREATE PROCEDURE AssessmentAverageMaxMinByEmphasis
	()
BEGIN
	SELECT
		e.Id AS EmphasisId,
		COALESCE(e.Name, "Undeclared") AS EmphasisName,
		cr.AssessmentId,
		AVG(Score) AS AverageScore,
		MIN(Score) AS LowestScore,
		MAX(Score) AS HighestScore
	FROM
		Emphasis e
		-- Students with no emphasis are null (use COALESCE to return
		-- undeclared)
		LEFT JOIN StudentEmphasis se ON e.Id = se.EmphasisId
		INNER JOIN CriteriaResult cr ON se.StudentId = cr.StudentId
	GROUP BY
		e.Id,
		cr.AssessmentId;
END

-- 9. A query to display all the CDAI data (every criteria score 
--    earned by that student) for a student, identified by first name
--    and last name.

CREATE PROCEDURE AllScoresForStudent
	(studentId INT)
BEGIN
	SELECT
		cr.StudentId,
		cr.AssessmentId,
		cr.CriteriaId,
		cr.SemesterId,
		cr.Score,
		cr.FacultyName
	FROM
		CriteriaResult cr
	WHERE
		cr.StudentId = studentId;
END

CREATE PROCEDURE AllScoresForStudentByFirstAndLastName
	(studentId INT)
BEGIN
	DECLARE studentId = GetStudentIdByFirstAndLastName(firstName, lastName);

	CALL AllScoresForStudent(studentId);
END

-- 10. A query to display the highest, lowest and average CDAI scores 
--     for a student (along with the CDAI ID), identified by first 
--     name and last name, over all CDAIs taken by that student.

CREATE PROCEDURE MaxMinAvgForStudent
	(studentId INT)
BEGIN
	SELECT
		MAX(Score) AS HighestScore,
		AVG(Score) AS AverageScore,
		MIN(Score) AS LowestScore
	FROM
		CriteriaResult cr
	WHERE
		cr.StudentId = studentId;
END

CREATE PROCEDURE MaxMinAvgForStudentByFirstAndLastName
	(firstName VARCHAR(50), lastName VARCHAR(50))
BEGIN
	DECLARE studentId = GetStudentIdByFirstAndLastName(firstName, lastName);

	CALL MaxMinAvgForStudent(studentId);
END

-- Get StudentId by First Name and Last Name
CREATE FUNCTION GetStudentIdByFirstAndLastName
	(firstName VARCHAR(50), lastName VARCHAR(50))
BEGIN
	DECLARE id = (
		SELECT
			s.UniversityId
		FROM
			Student s
		WHERE
			s.FirstName = firstName
			AND
			s.LastName = LastName
		LIMIT
			1
	);

	RETURN id;
END
