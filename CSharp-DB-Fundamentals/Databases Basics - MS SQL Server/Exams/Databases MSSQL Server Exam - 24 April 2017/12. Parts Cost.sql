SELECT SUM(op.Quantity * p.Price) AS [Parts Total] 
  FROM Orders AS [o]
 INNER JOIN OrderParts AS [op]
	ON o.OrderId = op.OrderId
 INNER JOIN Parts AS [p]
	ON p.PartId = op.PartId
 WHERE DATEDIFF(DAY, o.IssueDate, '2017-04-24') <= 21