SELECT m.Name, m.Age FROM Minnions AS [m]
INNER JOIN MinnionsVillains AS [mv]
ON m.Id = mv.MinnionId
WHERE mv.VillainId = @GivenId