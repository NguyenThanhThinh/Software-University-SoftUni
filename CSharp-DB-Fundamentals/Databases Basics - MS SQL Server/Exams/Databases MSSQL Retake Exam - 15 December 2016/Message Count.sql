SELECT TOP 5 c.Id, COUNT(*) AS [TotalMessages] FROM Chats AS [c]
INNER JOIN Messages AS [m]
ON c.Id = m.ChatId
WHERE m.Id < 90
GROUP BY c.Id
ORDER BY COUNT(*) DESC, c.Id