CREATE TABLE Users
(
Id int PRIMARY KEY IDENTITY,
Username nvarchar(30) NOT NULL UNIQUE,
Password nvarchar(50) NOT NULL,
Name nvarchar(50),
Gender char(1) CHECK (Gender IN ('M', 'F')),
BirthDate datetime,
Age int,
Email nvarchar(50) NOT NULL
)

CREATE TABLE Departments
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(50) NOT NULL
)

CREATE TABLE Employees
(
Id int PRIMARY KEY IDENTITY,
FirstName nvarchar(25),
LastName nvarchar(25),
Gender char(1) CHECK (Gender IN ('M', 'F')), 
BirthDate datetime,
Age int,
DepartmentId int NOT NULL
CONSTRAINT FK_Employees_Departments FOREIGN KEY (DepartmentId)
REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
Id int PRIMARY KEY IDENTITY,
Name varchar(50) NOT NULL,
DepartmentId int
CONSTRAINT FK_Categories_Departments FOREIGN KEY (DepartmentId)
REFERENCES Departments(Id)
)

CREATE TABLE Status
(
Id int PRIMARY KEY IDENTITY,
Label varchar(30) NOT NULL
)

CREATE TABLE Reports
(
Id int PRIMARY KEY IDENTITY,
CategoryId int NOT NULL,
StatusId int NOT NULL,
OpenDate datetime NOT NULL,
CloseDate datetime,
Description varchar(200),
UserId int NOT NULL,
EmployeeId int
CONSTRAINT FK_Reports_Categories FOREIGN KEY (CategoryId)
REFERENCES Categories(Id),
CONSTRAINT FK_Reports_Status FOREIGN KEY (StatusId)
REFERENCES Status(Id),
CONSTRAINT FK_Reports_Users FOREIGN KEY (UserId)
REFERENCES Users(Id),
CONSTRAINT FK_Reports_Employees FOREIGN KEY (EmployeeId)
REFERENCES Employees(Id)
)