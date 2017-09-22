SELECT g.Name AS [Game], gt.Name AS [Game Type], u.Username, ug.Level, ug.Cash, c.Name AS [Character] 
  FROM Games AS [g]
INNER JOIN GameTypes AS [gt]
	ON g.GameTypeId = gt.Id
INNER JOIN UsersGames AS [ug]
	ON ug.GameId = g.Id
INNER JOIN Users AS [u]
	ON u.Id = ug.UserId
INNER JOIN Characters AS [c]
	ON ug.CharacterId = c.Id
ORDER BY ug.Level DESC, u.Username, g.Name