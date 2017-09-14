SELECT SUBSTRING(FirstName, 1, 1) AS [FirstName] FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName, 1, 1)