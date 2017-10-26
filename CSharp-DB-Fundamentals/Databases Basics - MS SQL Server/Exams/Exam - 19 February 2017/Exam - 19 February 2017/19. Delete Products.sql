CREATE TRIGGER tr_OnDeleteProduct ON Products INSTEAD OF DELETE
AS
	DECLARE @ProductId int = (SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients
	 WHERE ProductId = @ProductId

	DELETE FROM Feedbacks
	 WHERE ProductId = @ProductId

	DELETE FROM Products
	 WHERE Id = @ProductId