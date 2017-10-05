SELECT m.Id, m.ChatId, m.UserId FROM Messages AS [m]
WHERE (m.UserId NOT IN
(SELECT uc.UserId FROM Messages AS [m]
INNER JOIN UsersChats AS [uc]
ON uc.ChatId = m.ChatId
WHERE m.ChatId = 17)
AND m.ChatId = 17) OR m.UserId IS NULL
ORDER BY m.Id DESC