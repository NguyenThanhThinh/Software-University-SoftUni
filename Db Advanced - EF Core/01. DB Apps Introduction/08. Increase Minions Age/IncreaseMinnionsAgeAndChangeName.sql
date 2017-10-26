UPDATE Minnions
   SET Age += 1,
  Name = s1.newName FROM
  (SELECT
	 CASE WHEN LEFT(Name, 1) = LOWER(LEFT(Name, 1)) COLLATE SQL_Latin1_General_CP1_CS_AS 
			THEN UPPER(LEFT(Name,1))+LOWER(SUBSTRING(Name,2,LEN(Name)))
	 ELSE LOWER(Name) END AS [newName] FROM Minnions WHERE Id = @GivenId) AS [s1]
WHERE Id = @GivenId