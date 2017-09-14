SELECT MIN(g.Salary) AS [MinAverageSalary] 
  FROM
	  (SELECT e.DepartmentID, AVG(e.Salary) AS [Salary] 
	     FROM Employees AS [e]
       GROUP BY e.DepartmentID) AS g