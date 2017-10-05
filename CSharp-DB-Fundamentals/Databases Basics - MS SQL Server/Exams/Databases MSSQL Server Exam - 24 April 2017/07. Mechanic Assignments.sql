SELECT CONCAT(FirstName, ' ', LastName) AS [Mechanic], Status, IssueDate FROM Mechanics AS [m]
INNER JOIN Jobs AS [j]
ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, IssueDate, JobId