SELECT j.JobId, SUM(op.Quantity * p.Price) AS [Total] FROM Jobs AS [j]
 INNER JOIN Orders AS [o]
	ON j.JobId = o.JobId
 INNER JOIN OrderParts AS [op]
	ON o.OrderId = op.OrderId
 INNER JOIN Parts AS [p]
	ON op.PartId = p.PartId
 WHERE j.Status = 'Finished'
 GROUP BY j.JobId
 ORDER BY SUM(op.Quantity * p.Price) DESC, j.JobId