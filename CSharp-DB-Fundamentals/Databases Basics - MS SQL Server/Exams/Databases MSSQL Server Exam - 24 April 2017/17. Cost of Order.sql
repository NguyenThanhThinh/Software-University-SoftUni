CREATE FUNCTION udf_GetCost (@JobsId int)
RETURNS decimal(5,2)
AS
BEGIN

	DECLARE @totalSum decimal(5,2) = 0;

	SELECT @totalSum = s1.price FROM
	(SELECT SUM(p.Price * pn.Quantity) AS [price] FROM Jobs AS [j]
	INNER JOIN PartsNeeded AS [pn]
	ON j.JobId = pn.JobId
	INNER JOIN Parts AS [p]
	ON pn.PartId = p.PartId
	WHERE pn.JobId = @JobsId) AS [s1]

RETURN @totalSum;

END