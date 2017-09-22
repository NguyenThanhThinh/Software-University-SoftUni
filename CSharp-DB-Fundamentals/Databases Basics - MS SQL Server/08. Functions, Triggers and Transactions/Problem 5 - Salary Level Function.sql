CREATE FUNCTION ufn_GetSalaryLevel(@salary MONEY)
RETURNS varchar(7)
AS
BEGIN

DECLARE @Result varchar(7) = 'High'

	if(@salary < 30000)
	BEGIN
		SET @Result = 'Low'
		RETURN @Result
	END
	if(@salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @Result = 'Average'
		RETURN @Result
	END

RETURN @Result

END