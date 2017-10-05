SELECT s1.Title, s2.Content FROM
	(SELECT TOP 1 Id, Title FROM Chats
	ORDER BY StartDate DESC) AS [s1]
  LEFT JOIN (SELECT ChatId, m.Content FROM Messages AS [m]) AS s2
	ON s1.Id = s2.ChatId