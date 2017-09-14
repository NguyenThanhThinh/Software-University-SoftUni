SELECT u.UserName AS [Username], 
	   SUBSTRING(u.Email, CHARINDEX('@', u.Email) + 1, LEN(u.Email)) 
	   AS [Email Provider] 
  FROM Users AS [u]
ORDER BY [Email Provider], u.UserName