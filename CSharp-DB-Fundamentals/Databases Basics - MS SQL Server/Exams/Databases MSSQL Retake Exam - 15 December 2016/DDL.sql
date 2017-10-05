CREATE TABLE Locations
(
	Id int PRIMARY KEY,
	Latitude float,
	Longitude float
)

CREATE TABLE Credentials
(
	Id int PRIMARY KEY,
	Email varchar(30),
	Password varchar(20)
)

CREATE TABLE Chats
(
	Id int PRIMARY KEY,
	Title varchar(32),
	StartDate date,
	IsActive bit
)

CREATE TABLE Users
(
	Id int PRIMARY KEY IDENTITY,
	Nickname varchar(25),
	Gender char(1),
	Age int,
	LocationId int FOREIGN KEY REFERENCES Locations(Id),
	CredentialId int UNIQUE FOREIGN KEY REFERENCES Credentials(Id)
)

CREATE TABLE Messages
(
	Id int PRIMARY KEY,
	Content varchar(200),
	SentOn date,
	ChatId int FOREIGN KEY REFERENCES Chats(Id),
	UserId int FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE UsersChats
(
	UserId int,
	ChatId int,
	CONSTRAINT PK_UsersChats PRIMARY KEY(ChatId, UserId),
	CONSTRAINT FK_UsersChats_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_UsersChats_ChatID FOREIGN KEY (ChatId) REFERENCES Chats(Id)
)