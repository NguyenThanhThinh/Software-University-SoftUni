SELECT d.Name, 
  CASE WHEN AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) > 0.0 THEN CAST(AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS varchar)
  ELSE 'no info'
  END
 FROM Departments as [d]
INNER JOIN Categories as [c] ON c.DepartmentId = d.Id
INNER JOIN Reports as [r] ON r.CategoryId = c.Id
GROUP BY d.Name
ORDER BY d.Name