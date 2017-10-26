SELECT e.FirstName + ' ' + e.LastName AS [Name], COUNT(r.EmployeeId) as [Users Number]FROM Employees as [e]
LEFT JOIN Reports as [r] ON r.EmployeeId = e.Id
GROUP BY e.FirstName, e.LastName
ORDER BY COUNT(r.EmployeeId) DESC, Name


-- testing is this
SELECT * FROM Employees as [e]
INNER JOIN Reports as [r] ON r.EmployeeId = e.Id

SELECT * FROM Reports