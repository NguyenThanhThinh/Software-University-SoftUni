SELECT ProductId, 
       c.FirstName + ' ' + c.LastName AS [CustomerName], 
	   ISNULL(fe.Description, '') AS [FeedbackDescription]
  FROM Feedbacks AS [fe]
 INNER JOIN Customers AS [c] ON c.Id = fe.CustomerId
 WHERE c.Id IN (SELECT f.CustomerId FROM Feedbacks AS [f]
 GROUP BY f.CustomerId
HAVING COUNT(f.CustomerId) >= 3)
 ORDER BY ProductId, [CustomerName], fe.Id