SELECT p.PartId, p.Description, SUM(pn.Quantity) AS [Required], SUM(p.StockQty) AS [In Stock], SUM(op.Quantity) AS [Ordered] FROM Jobs AS [j]
INNER JOIN PartsNeeded AS [pn]
ON j.JobId = pn.JobId
INNER JOIN Parts AS [p]
ON pn.PartId = p.PartId
INNER JOIN OrderParts AS [op]
ON op.PartId = p.PartId
INNER JOIN Orders AS [o]
ON o.OrderId = op.OrderId
WHERE j.Status <> 'Finished'
GROUP BY p.PartId, p.Description
HAVING SUM(pn.Quantity) > SUM(p.StockQty)

-- не е дорешена