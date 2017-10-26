SELECT i.Name, 
       i.Price, 
	   i.MinLevel, 
	   s.Strength, 
	   s.Defence, 
	   s.Speed, 
	   s.Luck, 
	   s.Mind 
  FROM Items AS [i]
 INNER JOIN [Statistics] AS [s] ON s.Id = i.StatisticId
 WHERE  (SELECT s.Mind FROM [Statistics] AS [s] WHERE s.Id = i.StatisticId) >
	    (SELECT AVG(Mind) FROM [Statistics])
   AND
		(SELECT s.Speed FROM [Statistics] AS [s] WHERE s.Id = i.StatisticId) >
	    (SELECT AVG(Speed) FROM [Statistics])
   AND
		(SELECT s.Luck FROM [Statistics] AS [s] WHERE s.Id = i.StatisticId) >
	    (SELECT AVG(Luck) FROM [Statistics])
 ORDER BY i.Name
