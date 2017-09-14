CREATE TABLE Users
(
	Id bigint PRIMARY KEY IDENTITY,
	Username varchar(30) NOT NULL,
	Password varchar(26) NOT NULL,
	ProfilePicture varbinary(max),
	LastLoginTime smalldatetime,
	IsDeleted tinyint
)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES ('Ivan', 123, NULL, NULL, 1), 
	('Pesho', 123, NULL, NULL, 1), 
	('Stefan', 123, NULL, NULL, 1), 
	('Mimi', 123, NULL, NULL, 1),
	('Cici', 123, NULL, NULL, 1)