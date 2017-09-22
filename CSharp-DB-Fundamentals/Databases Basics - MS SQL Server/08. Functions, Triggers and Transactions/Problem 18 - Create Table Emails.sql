CREATE TRIGGER tr_OnLogsUpdate ON [Logs] FOR INSERT
AS
BEGIN
	DECLARE @Recipient int;
	DECLARE @Subject nvarchar(100);
	DECLARE @Body nvarchar(200);
	DECLARE @oldSum money;
	DECLARE @newSum money;

	SELECT @Recipient = AccountId FROM inserted
	SELECT @Subject = CONCAT('Balance change for account: ', @Recipient)
	SELECT @oldSum = OldSum FROM Logs
	SELECT @newSum = NewSum FROM Logs

	SELECT @Body = CONCAT('On ', GETDATE(), ' your balance was changed from ', @oldSum, ' to ', @newSum, '.')

	INSERT INTO NotificationEmails
	VALUES (@Recipient, @Subject, @Body)
END