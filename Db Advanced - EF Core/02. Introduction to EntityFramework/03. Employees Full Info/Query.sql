SELECT Employees.FirstName, Employees.EmployeeID FROM Employees
INNER JOIN EmployeesProjects
ON Employees.EmployeeID = EmployeesProjects.EmployeeID
INNER JOIN Projects
ON EmployeesProjects.ProjectID = Projects.ProjectID
WHERE YEAR(Projects.StartDate) = 2002
GROUP BY Employees.FirstName, Employees.EmployeeID