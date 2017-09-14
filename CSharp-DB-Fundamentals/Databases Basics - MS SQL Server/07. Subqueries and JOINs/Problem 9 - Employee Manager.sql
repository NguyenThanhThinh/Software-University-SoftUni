SELECT [e1].EmployeeID, [e1].FirstName, [e1].ManagerID, [e2].FirstName AS [ManagerName] 
  FROM Employees AS [e1], Employees AS [e2]
WHERE e1.ManagerID = e2.EmployeeID
AND e1.ManagerID IN (3, 7)
ORDER BY e1.EmployeeID