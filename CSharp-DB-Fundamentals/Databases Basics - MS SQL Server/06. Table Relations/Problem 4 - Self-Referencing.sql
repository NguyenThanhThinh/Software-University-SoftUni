CREATE TABLE Teachers
(
	TeacherID int PRIMARY KEY IDENTITY(101,1),
	Name nvarchar(50) NOT NULL,
	ManagerID int
)

INSERT INTO Teachers (Name, ManagerID)
VALUES ('John', NULL), ('Maya', 106), ('Silvia', 106), ('Ted', 105), ('Mark', 101), ('Greta', 101)

ALTER TABLE Teachers
ADD CONSTRAINT FK_ManagerID_TeacherID
FOREIGN KEY (ManagerID)
REFERENCES Teachers(TeacherID)