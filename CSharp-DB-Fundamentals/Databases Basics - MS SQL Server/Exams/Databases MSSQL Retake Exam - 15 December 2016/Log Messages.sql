CREATE TRIGGER trgMessagesAfterDelete ON [dbo].[Messages] FOR DELETE
AS

	DECLARE @Id int;
	DECLARE @Content varchar(200);
	DECLARE @SentOn date;
	DECLARE @ChatId int;
	DECLARE @UserId int;

	SET @Id = (SELECT d.Id FROM deleted AS d);
	SET @Content = (SELECT d.Content FROM deleted AS d);
	SET @SentOn = (SELECT d.SentOn FROM deleted AS d);
	SET @ChatId = (SELECT d.ChatId FROM deleted AS d);
	SET @UserId = (SELECT d.UserId FROM deleted AS d);

	INSERT INTO MessageLogs(Id, Content, SentOn, ChatId, UserId)
	VALUES (@Id, @Content, @SentOn, @ChatId, @UserId)