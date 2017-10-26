CREATE TABLE Countries
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(50) UNIQUE
)

CREATE TABLE Customers
(
Id int PRIMARY KEY IDENTITY,
FirstName nvarchar(25),
LastName nvarchar(25),
Gender char(1) CHECK (Gender = 'M' OR Gender = 'F'),
Age int,
PhoneNumber char(10) CHECK (LEN(PhoneNUmber) = 10),
CountryId int
CONSTRAINT FK_Customers_Countries FOREIGN KEY (CountryId)
REFERENCES Countries(Id)
)

CREATE TABLE Products
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(25) UNIQUE, 
Description nvarchar(250),
Recipe nvarchar(max),
Price money CHECK (Price >= 0.0)
)

CREATE TABLE Feedbacks
(
Id int PRIMARY KEY IDENTITY,
Description nvarchar(255),	
Rate decimal(4,2) CHECK (Rate BETWEEN 0 AND 10),
ProductId int,
CustomerId int
CONSTRAINT FK_Feedbacks_Products FOREIGN KEY (ProductId)
REFERENCES Products(Id),
CONSTRAINT FK_Feedbacks_Customers FOREIGN KEY (CustomerId)
REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(25) UNIQUE,
AddressText nvarchar(30),
Summary nvarchar(200),
CountryId int
CONSTRAINT FK_Distributors_Countries FOREIGN KEY (CountryId)
REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
Id int PRIMARY KEY IDENTITY,
Name nvarchar(30),
Description nvarchar(200),
OriginCountryId int,
DistributorId int
CONSTRAINT FK_Ingredients_OriginCountry FOREIGN KEY (OriginCountryId)
REFERENCES Countries(Id),
CONSTRAINT FK_Ingredients_Distributor FOREIGN KEY (DistributorId)
REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
ProductId int,
IngredientId int
CONSTRAINT PK_ProductId_IngredientId
PRIMARY KEY (ProductId, IngredientId),
CONSTRAINT FK_ProductsIngredients_Products FOREIGN KEY (ProductId)
REFERENCES Products(Id),
CONSTRAINT FK_ProductsIngredients_Ingredients FOREIGN KEY (IngredientId)
REFERENCES Ingredients(Id)
)