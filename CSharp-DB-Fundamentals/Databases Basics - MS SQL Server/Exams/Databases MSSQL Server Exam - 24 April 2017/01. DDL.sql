CREATE DATABASE WashingMachineService 

GO

use WashingMachineService

GO

CREATE TABLE Clients
(
	ClientId int PRIMARY KEY IDENTITY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Phone char(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId int PRIMARY KEY IDENTITY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Address varchar(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId int PRIMARY KEY IDENTITY,
	Name varchar(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs
(
	JobId int PRIMARY KEY IDENTITY,
	ModelId int NOT NULL,
	Status varchar(50) CHECK (Status = 'Pending' OR Status = 'In Progress' OR Status = 'Finished') DEFAULT 'Pending' NOT NULL,
	ClientId int NOT NULL,
	MechanicId int,
	IssueDate date NOT NULL,
	FinishDate date,
	CONSTRAINT FK_Jobs_Models
	FOREIGN KEY (ModelId)
	REFERENCES Models(ModelId),
	CONSTRAINT FK_Jobs_Clients
	FOREIGN KEY (ClientId)
	REFERENCES Clients(ClientId),
	CONSTRAINT FK_Jobs_Mechanics
	FOREIGN KEY (MechanicId)
	REFERENCES Mechanics(MechanicId)
)

CREATE TABLE Orders
(
	OrderId int PRIMARY KEY IDENTITY,
	JobId int NOT NULL,
	IssueDate date,
	Delivered bit DEFAULT 0 NOT NULL
	CONSTRAINT FK_Orders_Jobs
	FOREIGN KEY (JobId)
	REFERENCES Jobs(JobId)
)

CREATE TABLE Vendors
(
	VendorId int PRIMARY KEY IDENTITY,
	Name varchar(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
	PartId int PRIMARY KEY IDENTITY,
	SerialNumber varchar(50) UNIQUE NOT NULL,
	Description varchar(50),
	Price decimal(6,2) CHECK (Price > 0 AND Price < 9999.99) NOT NULL,
	VendorId int NOT NULL,
	StockQty int CHECK (StockQty >= 0) DEFAULT 0
	CONSTRAINT FK_Parts_Vendors
	FOREIGN KEY (VendorId)
	REFERENCES Vendors(VendorId)
)

CREATE TABLE OrderParts
(
	OrderId int NOT NULL,
	PartId int NOT NULL,
	Quantity int CHECK (Quantity > 0) DEFAULT 1 NOT NULL,
	CONSTRAINT PK_OrderId_PartId
	PRIMARY KEY (OrderId, PartId),
	CONSTRAINT FK_OrderParts_Orders
	FOREIGN KEY (OrderId)
	REFERENCES Orders(OrderId),
	CONSTRAINT FK_OrderParts_Parts
	FOREIGN KEY (PartId)
	REFERENCES Parts(PartId)
)

CREATE TABLE PartsNeeded
(
	JobId int NOT NULL,
	PartId int NOT NULL,
	Quantity int CHECK (Quantity > 0) DEFAULT 1 NOT NULL,
	CONSTRAINT PK_JobId_PartId
	PRIMARY KEY (JobId, PartId),
	CONSTRAINT FK_PartsNeeded_Jobs
	FOREIGN KEY (JobId)
	REFERENCES Jobs(JobId),
	CONSTRAINT FK_PartsNeeded_Parts
	FOREIGN KEY (PartId)
	REFERENCES Parts(PartId)
)