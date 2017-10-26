SELECT v.Name, s1.count FROM
	(SELECT v.Id, COUNT(v.Id) as [count] FROM Villains AS [v]
	  INNER JOIN MinnionsVillains AS [mv]
		 ON mv.VillainId = v.Id
	  INNER JOIN Minnions AS [m]
		 ON m.Id = mv.MinnionId
	  GROUP BY v.Id
	 HAVING COUNT(v.Id) >= 2) AS [s1], Villains AS [v]
 WHERE v.Id IN (s1.Id)
 ORDER BY s1.count DESC