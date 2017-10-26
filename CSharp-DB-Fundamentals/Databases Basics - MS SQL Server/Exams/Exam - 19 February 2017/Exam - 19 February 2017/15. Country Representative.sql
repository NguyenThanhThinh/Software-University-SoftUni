
SELECT d.Id, d.Name FROM Distributors AS [d]
 INNER JOIN Ingredients AS [i] ON i.DistributorId = d.Id
 GROUP BY d.Id, d.Name