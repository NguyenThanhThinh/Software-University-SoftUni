SELECT e.FirstName, e.LastName, r.Description,  CONVERT(char(10), r.OpenDate,126) AS [OpenDate] FROM Employees as [e]
INNER JOIN Reports as [r] ON r.EmployeeId = e.Id
ORDER BY e.Id, r.OpenDate, r.Id