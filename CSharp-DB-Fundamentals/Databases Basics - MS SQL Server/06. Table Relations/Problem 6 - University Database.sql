CREATE TABLE Majors
(
	MajorID int PRIMARY KEY IDENTITY,
	Name nvarchar(50)
)

CREATE TABLE Students
(
	StudentID int PRIMARY KEY IDENTITY,
	StudentNumber nvarchar(50),
	StudentName nvarchar(50),
	MajorID int NOT NULL
)

CREATE TABLE Payments
(
	PaymentID int PRIMARY KEY IDENTITY,
	PaymentDate date,
	PaymentAmount money,
	StudentID int
)

CREATE TABLE Agenda
(
	StudentID int,
	SubjectID int,
	PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Subjects
(
	SubjectID int PRIMARY KEY IDENTITY,
	SubjectName nvarchar(50) NOT NULL
)

ALTER TABLE Students
ADD CONSTRAINT FK_Students_Majors
FOREIGN KEY (MajorID)
REFERENCES Majors(MajorID)

ALTER TABLE Payments
ADD CONSTRAINT FK_Payments_Students
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID)

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_Students
FOREIGN KEY (StudentID)
REFERENCES Students(StudentID)

ALTER TABLE Agenda
ADD CONSTRAINT FK_Agenda_Subjects
FOREIGN KEY (SubjectID)
REFERENCES Subjects(SubjectID)