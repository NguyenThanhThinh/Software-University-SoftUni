SELECT TOP 3 CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic], s1.Jobs FROM
	(SELECT MechanicId, COUNT(j.JobId) AS [Jobs] FROM Jobs AS [j]
	WHERE j.Status <> 'Finished'
	GROUP BY MechanicId) AS [s1], Mechanics AS [m]
WHERE s1.MechanicId = m.MechanicId AND s1.Jobs > 1
ORDER BY s1.Jobs DESC, m.MechanicId