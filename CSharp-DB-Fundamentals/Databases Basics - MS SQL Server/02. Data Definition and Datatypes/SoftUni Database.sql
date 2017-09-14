CREATE DATABASE SoftUni

GO

USE SoftUni

CREATE TABLE Towns
(
	Id int IDENTITY PRIMARY KEY,
	Name varchar(50) NOT NULL
)

CREATE TABLE Addresses
(
	Id int IDENTITY,
	AddressText varchar (50) PRIMARY KEY,
	TownId int FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments 
(
	Id int IDENTITY PRIMARY KEY,
	Name varchar(50) FOREIGN KEY REFERENCES Addresses(AddressText) NOT NULL
)

CREATE TABLE Employees
(
	Id int IDENTITY PRIMARY KEY, 
	FirstName varchar(50) NOT NULL, 
	MiddleName varchar(50) NOT NULL, 
	LastName varchar(50) NOT NULL, 
	JobTitle varchar(50), 
	DepartmentId int FOREIGN KEY REFERENCES Departments(Id), 
	HireDate date, 
	Salary decimal (7,2),
	AddressId int
)

