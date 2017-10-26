SELECT d.Name, c.Name, 
	( 
	(SELECT countt FROM(SELECT d.Name as [interName], COUNT(c.Id) as [countt]
  FROM Departments as [d]
INNER JOIN Categories as [c] ON c.DepartmentId = d.Id
INNER JOIN Reports as [r] ON r.CategoryId = c.Id
INNER JOIN Users as [u] ON u.Id = r.UserId AND r.OpenDate IS NOT NULL
GROUP BY d.Name
) as [s1] WHERE interName = d.Name) / COUNT(c.Id) ) as [Cunter]
  FROM Departments as [d]
INNER JOIN Categories as [c] ON c.DepartmentId = d.Id
INNER JOIN Reports as [r] ON r.CategoryId = c.Id
INNER JOIN Users as [u] ON u.Id = r.UserId AND r.OpenDate IS NOT NULL
GROUP BY d.Name, c.Name
ORDER BY d.Name, c.Name

