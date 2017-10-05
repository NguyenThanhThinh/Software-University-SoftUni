DELETE FROM Locations
 WHERE Id NOT IN
	   (SELECT l.Id FROM Users AS [u]
		INNER JOIN Locations AS [l]
		ON u.LocationId = l.Id)