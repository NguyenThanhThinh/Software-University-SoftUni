SELECT e.DepositGroup, 
   SUM(e.DepositAmount) AS [TotalSum] 
  FROM (
       SELECT DepositGroup, DepositAmount
		 FROM WizzardDeposits
		WHERE MagicWandCreator = 'Ollivander family') 
		AS e
GROUP BY e.DepositGroup