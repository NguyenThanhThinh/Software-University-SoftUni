CREATE DATABASE Hotel

GO

USE Hotel

CREATE TABLE Employees
(
	Id int IDENTITY PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Title varchar(100) NOT NULL,
	Notes varchar(500)
)

CREATE TABLE Customers
(
	AccountNumber int IDENTITY PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	PhoneNumber varchar(10) CHECK (DATALENGTH(PhoneNumber) > 7),
	EmergencyName varchar(50),
	EmergencyNumber varchar(10),
	Notes varchar(350)
)

CREATE TABLE RoomStatus
(
	RoomStatus varchar(10) PRIMARY KEY, 
	Notes varchar(500)	
)

CREATE TABLE RoomTypes
(
	RoomType varchar(10) PRIMARY KEY,
	Notes varchar(500)
)

CREATE TABLE BedTypes
(
	BedType varchar(10) PRIMARY KEY,
	Notes varchar(500)
)

CREATE TABLE Rooms
(
	RoomNumber int IDENTITY PRIMARY KEY,
	RoomType varchar(10) NOT NULL,
	BedType varchar(10) NOT NULL,
	Rate decimal(2,1),
	RoomStatus varchar(10),
	Notes varchar(500)
)

CREATE TABLE Payments
(
	Id int IDENTITY PRIMARY KEY,
	EmployeeId int NOT NULL,
	PaymentDate date,
	AccountNumber int NOT NULL,
	FirstDateOccupied date,
	LastDateOccupied date,
	TotalDays int,
	AmountCharged decimal(7,2),
	TaxRate decimal (4,2),
	TaxAmount decimal(7,2),
	PaymentTotal decimal (8,2),
	Notes varchar(500)
)

CREATE TABLE Occupancies
(
	Id int IDENTITY PRIMARY KEY,
	EmployeeId int,
	DateOccupied date NOT NULL,
	AccountNumber int NOT NULL, 
	RoomNumber int NOT NULL, 
	RateApplied decimal(4,2), 
	PhoneCharge decimal(6,2), 
	Notes varchar(500)
)


INSERT INTO Employees (FirstName, LastName, Title, Notes)
VALUES ('Sev', 'Paunov', 'RTS', NULL),
	('Pesho', 'Ivanov', 'MVS', NULL),
	('Nik', 'Gecov', 'ZTW', NULL)

INSERT INTO Customers (FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
VALUES ('Sev', 'Paunov', '0883837374', NULL, NULL, NULL),
	('Pesho', 'Ivanov', '0883845374', NULL, NULL, NULL),
	('Nik', 'Gecov', '0883837884', NULL, NULL, NULL)

INSERT INTO RoomStatus (RoomStatus, Notes)
VALUES ('Open', 'No notes'),
	('Closed', 'No notes'),
	('Busy', 'No notes')

INSERT INTO RoomTypes (RoomType, Notes)
VALUES ('Single', 'No notes'),
	('Double', 'No notes'),
	('Normal', 'No notes')

INSERT INTO BedTypes (BedType, Notes)
VALUES ('Kingsize', 'No notes'),
	('Small', 'No notes'),
	('Normal', 'No notes')

INSERT INTO Rooms (RoomType, BedType, Rate, RoomStatus, Notes)
VALUES ('Single', 'Kingsize', 4.3, 'Open', NULL),
	('Double', 'Kingsize', 7.3, 'Open', NULL),
	('Single', 'Normal', 1.3, 'Closed', NULL)


INSERT INTO Payments (EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, 
						TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
VALUES (3, '2017/07/07', 7, '07/05/2017', '07/06/2017', 17, 93.10, 3.4, 117.10, 234.23, NULL),
	(3, '2017/07/07', 7, '07/05/2017', '07/06/2017', 17, 93.10, 3.4, 117.10, 234.23, NULL),
	(3, '2017/07/07', 7, '07/05/2017', '07/06/2017', 17, 93.10, 3.4, 117.10, 234.23, NULL)

ALTER TABLE Occupancies
ALTER COLUMN DateOccupied date

INSERT INTO Occupancies (EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
VALUES (7, NULL, 8, 17, 2.3, 17.1, NULL),
	(7, NULL, 8, 17, 2.3, 17.1, NULL),
	(7, NULL, 8, 17, 2.3, 17.1, NULL)
