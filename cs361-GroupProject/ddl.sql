-- Nic Moon
-- Nick Ganter
-- Lisa Poeschl

-- Functional Dependencies
-- UniversityId -> FirstName, LastName, MiddleName, Status

-- While it might seem like a combination of names and status might work this is not necessarily a gaurentee.

-- Candidate Keys: { UniversityId }
-- Non-primes: FirstName, LastName, MiddleName, Status

-- 1NF: Data is atomic (passes)
-- 2NF: All non-primes are only determined by the candidate key (passes)
-- 3NF: With one functional dependency - transitive dependency is not possible (passes)
-- BCNF: One functional dependency and it depends on a super key (passes)

CREATE TABLE Student
(
	UniversityId INT NOT NULL AUTO_INCREMENT,
	FirstName VARCHAR(50) NOT NULL, 
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL,
	Status INT NOT NULL,
	PRIMARY KEY (UniversityId)
);

-- Functional Dependencies
-- Id -> Name, Initials
-- Name -> Id, Initials
-- Initials -> Id, Name
-- Plus super keys

-- Candidate Keys: { Id }, { Name }, { Initials }
-- Non-primes: None

-- 1NF: Data is atomic (passes)
-- 2NF: We have no non-primes (passes)
-- 3NF: We have transitive dependency, but it is on prime attributes (passes)
-- BCNF: All functional dependencies are for candidate keys (super keys) (passes)

CREATE TABLE Emphasis
(
	Id INT NOT NULL AUTO_INCREMENT,
	Initials VARCHAR(4), -- add unique constraints later
	Name VARCHAR(50),	 -- add unique constraints later
	PRIMARY KEY (Id)
);

-- Functional Dependencies
-- None

-- Candidate Keys: { StudentId, EmphasisId }
-- Non-primes: None

-- 1NF: Data is atomic (passes)
-- 2NF: We have no non-primes (passes)
-- 3NF: No functional dependencies (passes)
-- BCNF: No functional dependencies (passes)

CREATE TABLE StudentEmphasis
(
	StudentId INT NOT NULL,
	EmphasisId INT NOT NULL,
	-- this restricts a student to one emphasis, but easily allows the database
	-- to be manipulated to support several in the future
	FOREIGN KEY (StudentId) REFERENCES Student(UniversityId),
	FOREIGN KEY (EmphasisId) REFERENCES Emphasis(Id),
	KEY IX_StudentEmphasis_EmphasisId (EmphasisId),
	PRIMARY KEY (StudentId)
);

-- Functional Dependencies
-- Id -> StartDate
-- StartDate -> Id

-- Candidate Keys: { Id }, { StartDate }
-- Non-primes: None

-- 1NF: Data is atomic (passes)
-- 2NF: We have no non-primes (passes)
-- 3NF: We have transitive dependency, but it is on prime attributes (passes)
-- BCNF: All functional dependencies are for candidate keys (super keys) (passes)

CREATE TABLE Semester
(
	Id INT NOT NULL AUTO_INCREMENT,
	StartDate DATE NOT NULL, -- add unique constraint later
	PRIMARY KEY (Id)
);

-- Functional Dependencies
-- Id -> Name
-- Name -> Id

-- Candidate Keys: { Id }, { Name }
-- Non-primes: None

-- 1NF: Data is atomic (passes)
-- 2NF: We have no non-primes (passes)
-- 3NF: We have transitive dependency, but it is on prime attributes (passes)
-- BCNF: All functional dependencies are for candidate keys (super keys) (passes)

CREATE TABLE AssessmentItem
(
	Id INT NOT NULL AUTO_INCREMENT,
	Name VARCHAR(50) NOT NULL, -- add unique constraint later
	PRIMARY KEY (Id)
);

-- Functional Dependencies
-- None

-- Candidate Keys: { StudentId, AssessmentId }
-- Non-primes: None

-- 1NF: Data is atomic (passes)
-- 2NF: We have no non-primes (passes)
-- 3NF: No functional dependencies (passes)
-- BCNF: No functional dependencies (passes)

CREATE TABLE StudentAssesment
(
	StudentId INT NOT NULL,
	AssessmentId INT NOT NULL,
	FOREIGN KEY (StudentId) REFERENCES Student(UniversityId),
	FOREIGN KEY (AssessmentId) REFERENCES AssessmentItem(Id),
	PRIMARY KEY (StudentId, AssessmentId)
);

-- Functional Dependencies
-- Id -> Name, MaxScore
-- Name -> Id, MaxScore

-- Candidate Keys: { Id }, { Name }
-- Non-primes: MaxScore

-- 1NF: Data is atomic (passes)
-- 2NF: We have no composite candidate keys.
-- 3NF: We have transitive dependency, but it is on prime attributes (passes)
-- BCNF: All functional dependencies are for candidate keys (super keys) (passes)

CREATE TABLE Criteria
(
	Id INT NOT NULL AUTO_INCREMENT,
	Name VARCHAR(50) NOT NULL, -- add unique constraint later
	MaxScore INT NOT NULL,
	PRIMARY KEY (Id)
);

-- Functional Dependencies
-- None

-- Candidate Keys: { CriteriaId, AssessmentId }
-- Non-primes: None

-- 1NF: Data is atomic (passes)
-- 2NF: We have no non-primes (passes)
-- 3NF: No functional dependencies (passes)
-- BCNF: No functional dependencies (passes)

CREATE TABLE AssessmentCriteria
(
	CriteriaId INT NOT NULL,
	AssessmentId INT NOT NULL,
	FOREIGN KEY (CriteriaId) REFERENCES Criteria(Id),
	FOREIGN KEY (AssessmentId) REFERENCES AssessmentItem(Id),
	PRIMARY KEY (CriteriaId, AssessmentId)
);

-- Functional Dependencies
-- StudentId, AssessmentId, CriteriaId, SemesterId -> Score

-- FacultyName - cannot be functionally determined by any these assuming two professors may teach a course in the same
--               semester and give the same assessments (passes)

-- Candidate Keys: { StudentId, AssessmentId, CriteriaId, SemesterId }
-- Non-primes: FacultyName, Score

-- 1NF: Data is atomic (passes)
-- 2NF: (passes)

-- Score - can be functionally determined only by the entire candidate key 
--         (reasons why each are required follow)
-- StudentId: Multiple students can take the same assesment and recieve 
--            different scores, so you can't be certain without this
-- AssessmentId: A student will (likely) take many assesments at the university
--               meaning you might look at the wrong one without it
-- CriteriaId: An assesment can have multiple criterion that are independent 
--             of the others meaning we could look at the wrong one without
--             an indicator

-- 3NF: With one functional dependency - transitive dependency is not possible (passes)
-- BCNF: We have one functional dependency on the candidate key (super key) (passes)

CREATE TABLE CriteriaResult
(
	StudentId INT NOT NULL,
	AssessmentId INT NOT NULL,
	CriteriaId INT NOT NULL,
	SemesterId INT NOT NULL,
	Score INT NOT NULL,
	FacultyName VARCHAR(50) NOT NULL,
	FOREIGN KEY (StudentId) REFERENCES Student(UniversityId),
	FOREIGN KEY (SemesterId) REFERENCES Semester(Id),
	FOREIGN KEY (CriteriaId) REFERENCES Criteria(Id),
	FOREIGN KEY (AssessmentId) REFERENCES AssessmentItem(Id),
	PRIMARY KEY (StudentId, AssessmentId, CriteriaId, SemesterId)
); -- right now if they take the same AI in the same semester we would have problems
