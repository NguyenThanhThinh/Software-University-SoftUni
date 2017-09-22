CREATE PROC usp_TransferMoney (@senderId int, @receiverId int, @amount money)
AS
BEGIN
	BEGIN TRANSACTION

	if @amount >= 0
	BEGIN TRY
	EXEC [dbo].[usp_WithdrawMoney] @senderId, @amount
	EXEC [dbo].[usp_DepositMoney] @receiverId, @amount
	END TRY

	BEGIN CATCH
	ROLLBACK
	RETURN
	END CATCH

	COMMIT
END