CREATE TABLE Orders
(
	OrderID int PRIMARY KEY IDENTITY,
	CustomerID int NOT NULL
)

CREATE TABLE Customers
(
	CustomerID int PRIMARY KEY IDENTITY,
	Name varchar(50),
	Birthday date,
	CityID int NOT NULL
)

CREATE TABLE Cities
(
	CityID int PRIMARY KEY IDENTITY,
	Name varchar(50)
)

CREATE TABLE OrderItems
(
	OrderID int NOT NULL,
	ItemID int NOT NULL,
	PRIMARY KEY (OrderID, ItemID)
)

CREATE TABLE Items
(
	ItemID int PRIMARY KEY IDENTITY,
	Name varchar(50),
	ItemTypeID int NOT NULL
)

CREATE TABLE ItemTypes
(
	ItemTypeID int PRIMARY KEY IDENTITY,
	Name varchar(50),
)

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Customers
FOREIGN KEY (CustomerID)
REFERENCES Customers(CustomerID)

ALTER TABLE Customers
ADD CONSTRAINT FK_Customers_Cities
FOREIGN KEY (CityID)
REFERENCES Cities(CityID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Orders
FOREIGN KEY (OrderID)
REFERENCES Orders(OrderID)

ALTER TABLE OrderItems
ADD CONSTRAINT FK_OrderItems_Items
FOREIGN KEY (ItemID)
REFERENCES Items(ItemID)

ALTER TABLE Items
ADD CONSTRAINT FK_Items_ItemTypes
FOREIGN KEY (ItemTypeID)
REFERENCES ItemTypes(ItemTypeID)