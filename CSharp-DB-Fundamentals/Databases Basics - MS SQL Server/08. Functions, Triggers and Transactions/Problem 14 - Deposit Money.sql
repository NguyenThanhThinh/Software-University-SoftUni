ALTER PROC usp_DepositMoney (@AccountId int, @moneyAmount money)
AS
BEGIN
	BEGIN TRANSACTION
	UPDATE Accounts
	SET Balance += @moneyAmount
	WHERE Id = @AccountId
	
	IF @@ROWCOUNT <> 1
		BEGIN
		ROLLBACK
		RAISERROR('Transaction failed!', 16, 1)
		RETURN
		END

	COMMIT
END