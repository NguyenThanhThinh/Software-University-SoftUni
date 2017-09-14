CREATE TABLE People
(
Id int IDENTITY UNIQUE,
Name nvarchar(200) NOT NULL,
Picture varbinary(max),
Height decimal(10,2),
Weight decimal (10,2),
Gender char(1) NOT NULL,
Birthday datetime NOT NULL,
Biography text
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES ('Ivan', NULL, 5.22, 7.21, 'm', 10/11/2017, 'Az sym bai Ivan')

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES ('Sev', NULL, 235.22, 37.21, 'm', 2017/10/10, 'Az sym Sev')

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES ('Mimi', NULL, 52.22, 72.21, 'f', 2017/02/06, 'Az sym Mimi')

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES ('Cuci', NULL, 235.22, 867.21, 'f', 10/01/2017, 'Az sym Cuci')

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthday, Biography)
VALUES ('Kremka', NULL, 65.22, 77.21, 'f', 03/11/2007, 'Az sym Kremkan')