SELECT c.Name AS [CategoryName], COUNT(e.Id) AS [Employees Number] FROM Categories as [c]
INNER JOIN Employees as [e] ON e.DepartmentId = c.DepartmentId
INNER JOIN Departments as [d] ON d.Id = c.DepartmentId
GROUP BY c.Name
ORDER BY c.Name