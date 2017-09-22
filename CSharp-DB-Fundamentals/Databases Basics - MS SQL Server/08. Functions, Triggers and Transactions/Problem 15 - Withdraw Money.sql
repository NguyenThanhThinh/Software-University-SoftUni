ALTER PROC usp_WithdrawMoney (@AccountId int, @moneyAmount money)
AS
BEGIN
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @AccountId
	
	IF @@ROWCOUNT <> 1
		BEGIN
		ROLLBACK
		RAISERROR('Not Enough Money!', 16, 1)
		RETURN
		END

	COMMIT
END