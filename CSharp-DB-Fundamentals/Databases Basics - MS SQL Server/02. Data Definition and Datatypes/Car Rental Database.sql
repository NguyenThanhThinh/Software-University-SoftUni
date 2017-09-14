CREATE DATABASE CarRental

GO

USE CarRental

CREATE TABLE Categories
(
	Id int IDENTITY PRIMARY KEY,
	CategoryName varchar(50) NOT NULL,
	DailyRate int,
	WeeklyRate int,
	MonthlyRate int,
	WeekendRate int
)

CREATE TABLE Cars 
(
	Id int IDENTITY PRIMARY KEY, 
	PlateNumber int, 
	Manufacturer varchar(20), 
	Model varchar(20) NOT NULL, 
	CarYear int, 
	CategoryId int, 
	Doors int, 
	Picture varbinary(max), 
	Condition varchar(50), 
	Available bit
)

CREATE TABLE Employees 
(
	Id int IDENTITY PRIMARY KEY, 
	FirstName varchar(50) NOT NULL, 
	LastName varchar(50) NOT NULL, 
	Title varchar(50),
	Notes varchar(500)
)

CREATE TABLE Customers 
(
	Id int IDENTITY PRIMARY KEY, 
	DriverLicenceNumber int NOT NULL, 
	FullName varchar(50), 
	Address varchar(100), 
	City varchar(50), 
	ZIPCode int, 
	Notes varchar(500)
)

CREATE TABLE RentalOrders 
(
	Id int IDENTITY PRIMARY KEY,
	EmployeeId int NOT NULL, 
	CustomerId int NOT NULL, 
	CarId int, 
	TankLevel decimal(3,1), 
	KilometrageStart decimal(10,2), 
	KilometrageEnd decimal(10,2), 
	TotalKilometrage decimal(15,2), 
	StartDate date, 
	EndDate date, 
	TotalDays int, 
	RateApplied int, 
	TaxRate int, 
	OrderStatus varchar(10), 
	Notes varchar(500)
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
VALUES ('Part1', 2, 3, 4, 5),
	('Part1', 2, 3, 4, 5),
	('Part1', 2, 3, 4, 5)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
VALUES (7, 'Honda', 'Acord', 2006, 7, 4, NULL, 'New', 1),
	(7, 'Honda', 'Acord', 2006, 7, 4, NULL, 'New', 1),
	(7, 'Honda', 'Acord', 2006, 7, 4, NULL, 'New', 1)

INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES ('Sev', 'Paunov', 'Dev', NULL),
	('Sev', 'Paunov', 'Dev', NULL),
	('Sev', 'Paunov', 'Dev', NULL)

INSERT INTO Customers (DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
VALUES (234, 'Sevdalin Paunov', '23. City Tour, BG', 'Sofia', 2394, NULL),
	(234, 'Sevdalin Paunov', '23. City Tour, BG', 'Sofia', 2394, NULL),
	(234, 'Sevdalin Paunov', '23. City Tour, BG', 'Sofia', 2394, NULL)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
VALUES (2, 3, 4, 2.3, 5.5, 6.6, 7.7, '07/07/2017', '07/08/2017', 30, 5, 3, 'Sold', NULL),
	(2, 3, 4, 2.3, 5.5, 6.6, 7.7, '07/07/2017', '07/08/2017', 30, 5, 3, 'Sold', NULL),
	(2, 3, 4, 2.3, 5.5, 6.6, 7.7, '07/07/2017', '07/08/2017', 30, 5, 3, 'Sold', NULL)