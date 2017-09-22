CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Salary money)
AS
SELECT tb.[First Name], tb.[Last Name] FROM
(SELECT ah.FirstName AS [First Name], ah.LastName AS [Last Name], SUM(a.Balance) AS [TotalBalance] 
   FROM AccountHolders AS [ah]
INNER JOIN Accounts AS [a]
ON ah.Id = a.AccountHolderId
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > 4000) AS [tb]