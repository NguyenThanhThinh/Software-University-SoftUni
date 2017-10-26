SELECT distinct u.Username FROM Users as [u]
INNER JOIN Reports as [r] ON r.UserId = u.Id
WHERE (u.Username LIKE '[0-9]%' AND CAST(r.CategoryId AS nvarchar) IN (LEFT(LTRIM(u.Username), 1), LEFT(LTRIM(u.Username), 2), LEFT(LTRIM(u.Username), 3)))
		OR (u.Username LIKE '%[0-9]' AND CAST(r.CategoryId AS nvarchar) IN (RIGHT(RTRIM(u.Username), 1), RIGHT(RTRIM(u.Username), 2), RIGHT(RTRIM(u.Username), 3)))
		GROUP BY u.Username
ORDER BY u.Username