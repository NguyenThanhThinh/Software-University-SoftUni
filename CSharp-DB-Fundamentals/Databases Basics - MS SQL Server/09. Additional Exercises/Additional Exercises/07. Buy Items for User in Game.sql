SELECT gt.Name FROM Users AS [u]
 INNER JOIN UsersGames AS [ug] ON ug.UserId = u.Id
 INNER JOIN Games AS [g] ON g.Id = ug.GameId
 INNER JOIN GameTypes AS [gt] ON gt.Id = g.GameTypeId
 group by gt.name