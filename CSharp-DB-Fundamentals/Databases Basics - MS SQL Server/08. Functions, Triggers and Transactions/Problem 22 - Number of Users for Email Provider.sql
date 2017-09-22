SELECT SUBSTRING(Email, 
					CHARINDEX('@', Email) + 1, 
					LEN(Email) - CHARINDEX('@', Email) + 1) 
					AS [Email Provider], 
		   COUNT(*) AS [Number Of Users] 
					FROM Users
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email) + 1)
ORDER BY [Number Of Users] DESC, [Email Provider]