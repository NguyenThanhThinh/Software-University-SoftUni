INSERT INTO Messages(Content, ChatId, UserId, SentOn)
SELECT 
CONCAT(Age, '-', Gender, '-', l.Latitude, '-', l.Longitude),
CASE 
	WHEN Gender = 'F' THEN CEILING(SQRT(Age * 2))
	WHEN Gender = 'M' THEN CEILING(POWER((Age / 18), 3))
END, 
u.Id,
'2016-12-15'
FROM Users as [u]
INNER JOIN Locations AS [l]
ON l.Id = u.LocationId
WHERE u.Id BETWEEN 10 AND 20