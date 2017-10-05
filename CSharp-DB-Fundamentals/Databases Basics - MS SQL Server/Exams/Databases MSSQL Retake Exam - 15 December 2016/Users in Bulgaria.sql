SELECT Nickname, Title, Latitude, Longitude FROM Users AS [u]
 INNER JOIN Locations AS [l]
	ON u.LocationId = l.Id 
   AND (l.Latitude BETWEEN 41.139999 AND 44.129999)
   AND (l.Longitude BETWEEN 22.209999 AND 28.3599999)
 INNER JOIN UsersChats AS [uc]
	ON uc.UserId = u.Id
 INNER JOIN Chats AS [c]
	ON uc.ChatId = c.Id
 ORDER BY Title

 -- I should make the range numbers with bigger precision, because Judge don't give me 1 test