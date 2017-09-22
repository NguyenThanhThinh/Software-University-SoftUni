CREATE PROC usp_CalculateFutureValueForAccount (@Sum money, @YearlyIR float, @NumberOfYears int)
AS

SELECT a.Id, g.FirstName, g.LastName,  g.[Current Balance], 
[dbo].[ufn_CalculateFutureValue]([Current Balance], 0.1, 5) AS [Balance in 5 years] FROM
(SELECT ah.FirstName, ah.LastName, SUM(a.Balance) AS [Current Balance] FROM AccountHolders AS [ah]
INNER JOIN Accounts AS [a]
ON ah.Id = a.AccountHolderId
GROUP BY ah.FirstName, ah.LastName) AS [g], AccountHolders AS [a]

-- не е завършена