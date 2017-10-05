UPDATE Chats
   SET StartDate = s1.SentOn FROM (SELECT m.SentOn, m.ChatId FROM Chats AS [c]
		INNER JOIN Messages AS [m]
		ON c.Id = m.ChatId
		WHERE DATEDIFF(minute, c.StartDate, m.SentOn) < 0) AS [s1]
 WHERE s1.ChatId = Chats.Id