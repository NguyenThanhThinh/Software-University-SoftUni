SELECT r.OpenDate, r.Description, u.Email FROM Reports as [r]
INNER JOIN Categories as [c] ON c.Id = r.CategoryId
INNER JOIN Departments as [d] ON d.Id = c.DepartmentId AND c.DepartmentId IN (1, 4, 5)
INNER JOIN Users as [u] ON u.Id = r.UserId
WHERE r.CloseDate IS NULL AND
	  LEN(r.Description) > 20 AND r.Description LIKE '%str%'
ORDER BY r.OpenDate, u.Email, r.Id