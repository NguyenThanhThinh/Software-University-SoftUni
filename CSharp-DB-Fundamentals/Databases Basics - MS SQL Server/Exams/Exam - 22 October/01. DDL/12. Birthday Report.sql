SELECT DISTINCT c.Name FROM Categories as [c]
INNER JOIN Reports as [r] ON c.Id = r.CategoryId
INNER JOIN Users as [u] ON u.Id = r.UserId
WHERE MONTH(u.BirthDate) = MONTH(r.OpenDate) AND DAY(u.BirthDate) = DAY(r.OpenDate)
ORDER BY c.Name