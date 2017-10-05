
SELECT m.Name, s3.Count FROM
	(SELECT TOP 1 s2.ModelId, COUNT(*) AS [Count] FROM
		(SELECT m.ModelId, j.JobId, SUM(p.Price) AS [Total price] FROM Models AS [m]
		INNER JOIN Jobs AS [j]
		ON m.ModelId = j.ModelId
		INNER JOIN PartsNeeded AS [pn]
		ON j.JobId = pn.JobId
		INNER JOIN Parts AS [p]
		ON pn.PartId = p.PartId
		GROUP BY m.ModelId, j.JobId) AS [s2]
	GROUP BY s2.ModelId
	ORDER BY COUNT(*) DESC) AS [s3], 
	Models AS [m]
WHERE s3.ModelId = m.ModelId

-- тр€бва да изкарам сумата накра€, но не знам как да € пренеса