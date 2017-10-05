CREATE PROC udp_SendMessage(@UserId INT, @ChatId INT, @Content varchar(200))
AS
BEGIN
	DECLARE @ChatCount int = (SELECT COUNT(*) FROM UsersChats AS [uc]
			WHERE @ChatId = uc.ChatId AND @UserId = uc.UserId);
	
	IF (@ChatCount <> 1)
	BEGIN
		RAISERROR('There is no chat with that user!', 16, 1)
	END
	ELSE
	BEGIN 
		INSERT INTO Messages (Content,  ChatId, UserId, SentOn)
		VALUES (@Content, @ChatId, @UserId, GETDATE())
	END
END