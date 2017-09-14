DECLARE @index INT = 0;
DECLARE @sum decimal = 0.0;

WHILE @index < (SELECT MAX(Id) FROM WizzardDeposits) - 1
BEGIN
	SET @sum += (SELECT [secondRow].DepositAmount FROM
	(SELECT DepositAmount, Id FROM WizzardDeposits 
	WHERE Id = @index) AS [secondRow])
	SET @sum += (SELECT DepositAmount FROM WizzardDeposits
	WHERE Id = @index + 1 )
	SET @index += 1;
END;

SELECT @sum


-- working one
select SUM(firstRow.secondRow) AS [SumDifference]
from (select DepositAmount - (select DepositAmount 
							  from WizzardDeposits AS [j]
							  where j.id = k.id +1) AS [secondRow]
      from WizzardDeposits AS [k]) AS [firstRow]