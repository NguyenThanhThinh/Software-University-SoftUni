SELECT e.DepositGroup, 
   SUM(e.DepositAmount) AS [TotalSum] 
  FROM (SELECT DepositGroup, DepositAmount
		  FROM WizzardDeposits
		 WHERE MagicWandCreator = 'Ollivander family') 
		    AS e
GROUP BY e.DepositGroup
HAVING SUM(e.DepositAmount) < 150000
ORDER BY [TotalSum] DESC