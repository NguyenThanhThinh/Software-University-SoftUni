SELECT c.Name, COUNT(*) as [ReportsNumber] FROM Categories as [c]
INNER JOIN Reports as [r] ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY COUNT(*) DESC, c.Name