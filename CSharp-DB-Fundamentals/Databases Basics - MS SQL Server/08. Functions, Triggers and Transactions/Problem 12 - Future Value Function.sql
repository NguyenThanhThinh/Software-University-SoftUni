CREATE FUNCTION ufn_CalculateFutureValue (@Sum money, @YearlyIR float, @NumberOfYears int)
RETURNS money
BEGIN

DECLARE @FV money;
SET @FV = @Sum * (POWER((1 + @YearlyIR), @NumberOfYears))
RETURN @FV

END