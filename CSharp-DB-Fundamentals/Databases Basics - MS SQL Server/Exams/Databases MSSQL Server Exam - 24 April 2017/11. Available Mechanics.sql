SELECT CONCAT(FirstName, ' ', LastName) AS [Available] FROM Mechanics
WHERE MechanicId NOT IN 
	(SELECT DISTINCT MechanicId FROM Jobs
	 WHERE STATUS <> 'Finished' AND MechanicId IS NOT NULL)
ORDER BY Mechanicid