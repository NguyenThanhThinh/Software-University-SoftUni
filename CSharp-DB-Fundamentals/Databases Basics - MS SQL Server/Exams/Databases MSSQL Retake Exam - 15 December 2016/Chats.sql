SELECT Title, IsActive FROM Chats AS[c]
 WHERE (c.IsActive = 0 AND LEN(c.Title) < 5) OR (SUBSTRING(c.Title, 3, 2) = 'tl')
 ORDER BY c.Title DESC