  SELECT w.[DepositGroup]
    FROM WizzardDeposits w
GROUP BY   w.[DepositGroup]
  HAVING AVG (w.MagicWandSize) = (
  SELECT MIN (WandSizeTable.AverageSizes) AS MinimalSize
    FROM (SELECT AVG (w.MagicWandSize) AS AverageSizes
            FROM WizzardDeposits w
        GROUP BY w.DepositGroup) 
		      AS WandSizeTable)