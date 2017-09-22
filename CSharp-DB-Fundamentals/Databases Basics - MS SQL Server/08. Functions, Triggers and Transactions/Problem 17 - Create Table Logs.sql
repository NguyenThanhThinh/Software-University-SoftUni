CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
BEGIN

	DECLARE @oldSum money
	DECLARE @newSum money
	DECLARE @AccountId int

	SELECT @oldSum = Balance FROM deleted
	SELECT @newSum = Balance FROM inserted
	SELECT @AccountId = AccountHolderId FROM inserted

	INSERT INTO Logs
	VALUES (@AccountId, @oldSum, @newSum)

END