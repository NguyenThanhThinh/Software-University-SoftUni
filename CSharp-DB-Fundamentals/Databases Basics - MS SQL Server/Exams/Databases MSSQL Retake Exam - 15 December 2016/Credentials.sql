SELECT Nickname, Email, Password FROM Users AS [u]
 INNER JOIN Credentials AS [c]
	ON u.CredentialId = c.Id
   AND c.Email LIKE '%co.uk'
 ORDER BY c.Email