SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic], s1.[Average Days] FROM
	(SELECT m.MechanicId, AVG((DATEDIFF(day, j.IssueDate, j.FinishDate))) AS [Average Days] FROM Mechanics AS [m]
	INNER JOIN Jobs AS [j]
	ON m.MechanicId = j.MechanicId
	WHERE Status = 'Finished'
	GROUP BY m.MechanicId) AS [s1], Mechanics AS [m]
WHERE m.MechanicId = s1.MechanicId