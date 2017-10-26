CREATE PROCEDURE usp_SendFeedback (@CustomerId int, @ProductId int, @Rate decimal(4,2), @Description nvarchar(255))
AS
BEGIN TRANSACTION
	INSERT INTO Feedbacks (CustomerId, ProductId, Rate, Description)
	VALUES (@CustomerId, @ProductId, @Rate, @Description)

	DECLARE @FeedbacksCount int = 
		(SELECT COUNT(*)
		   FROM Feedbacks AS [f]
		  WHERE f.CustomerId = @CustomerId)

	IF(@FeedbacksCount > 3)
	BEGIN
		ROLLBACK
		RAISERROR('You are limited to only 3 feedbacks per product!', 16, 1)
		RETURN
	END
COMMIT