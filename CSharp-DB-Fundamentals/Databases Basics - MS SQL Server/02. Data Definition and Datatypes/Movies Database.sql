CREATE DATABASE Movies

GO

USE Movies

CREATE TABLE Directors
(
	Id int,
	DirectorName varchar(50) NOT NULL,
	Notes varchar(1500)
)

CREATE TABLE Genres
(
	Id int,
	GenresName varchar(50) NOT NULL,
	Notes varchar(1500)
)

CREATE TABLE Categories
(
	Id int,
	CategoriesName varchar(50) NOT NULL,
	Notes varchar(1500),
)

CREATE TABLE Movies
(
	Id int IDENTITY,
	Title varchar(50) NOT NULL,
	DirectorId int NOT NULL, 
	CopyrightYear int, 
	Length int NOT NULL, 
	GenreId int NOT NULL, 
	CategoryId int NOT NULL, 
	Rating decimal(1,1), 
	Notes varchar(1500)
)

ALTER TABLE Categories
ALTER COLUMN Id int NOT NULL

ALTER TABLE Categories
ADD CONSTRAINT PK_Id PRIMARY KEY(Id)

ALTER TABLE Directors
ALTER COLUMN Id int NOT NULL

ALTER TABLE Directors
ADD CONSTRAINT PK_DirectorId PRIMARY KEY (Id)

ALTER TABLE Genres
ALTER COLUMN Id int NOT NULL

ALTER TABLE Genres
ADD CONSTRAINT PK_GenresId PRIMARY KEY (Id)

ALTER TABLE Movies
ALTER COLUMN Id int NOT NULL

ALTER TABLE  Movies
ADD CONSTRAINT PK_MoviesId PRIMARY KEY (Id)

ALTER TABLE Movies
ALTER COLUMN Rating decimal (2,1)

INSERT INTO Categories
VALUES (1, 'Sev', NULL), (2, 'Val', NULL), (3, 'Sev', NULL), (4, 'Val', NULL), (5, 'Sev', 'Bal')

INSERT INTO Directors
VALUES (1, 'Sev', NULL), (2, 'Val', 'Bal'), (3, 'Sev', NULL), (4, 'Val', NULL), (5, 'Sev', NULL)

INSERT INTO Genres
VALUES (1, 'Sev', NULL), (2, 'Val', NULL), (3, 'Sev', 'Bal'), (4, 'Val', NULL), (5, 'Sev', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
VALUES ('Matrix', 2, NULL, 120, 2, 3, NULL, NULL), ('Matrix', 2, NULL, 120, 2, 3, 9.7, NULL),
	('Matrix', 2, NULL, 120, 2, 3, 9.7, NULL), ('Matrix', 2, NULL, 120, 2, 3, 9.7, NULL),
	('Matrix', 2, NULL, 120, 2, 3, 9.7, NULL)
