CREATE FUNCTION udf_GetRating(@Name nvarchar(25))
RETURNS varchar(10)
AS
BEGIN
	DECLARE @Result varchar(10) = 
	(SELECT
	   CASE WHEN AVG(f.Rate) < 5 THEN 'Bad'
		    WHEN AVG(f.Rate) BETWEEN 5 AND 8 THEN 'Average'
		    WHEN AVG(f.Rate) > 8 THEN 'Good'
		    END
	   FROM Products AS [p]
	  INNER JOIN Feedbacks AS [f] ON f.ProductId = p.Id
	  WHERE p.Name = @Name
	  GROUP BY p.Name);

	IF(@Result IS NULL)
	BEGIN
	  SET @Result = 'No rating'
	END

RETURN @Result

END