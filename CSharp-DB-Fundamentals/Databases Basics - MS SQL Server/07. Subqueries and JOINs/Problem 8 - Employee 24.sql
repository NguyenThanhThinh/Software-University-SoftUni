SELECT e.EmployeeID, e.FirstName, p.Name AS [ProjectName]
  FROM Employees AS [e]
JOIN EmployeesProjects AS [ep]
ON e.EmployeeID = ep.EmployeeID
AND e.EmployeeID = 24
LEFT JOIN Projects AS [p]
ON ep.ProjectID = p.ProjectID
AND p.StartDate < '2005/01/01'