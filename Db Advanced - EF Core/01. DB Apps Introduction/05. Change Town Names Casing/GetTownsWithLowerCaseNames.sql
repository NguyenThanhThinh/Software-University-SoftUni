﻿SELECT t.Name FROM Towns AS [t]
INNER JOIN Countries AS [c]
ON t.CountryId = c.Id
WHERE c.Name = @GivenCountryName AND t.Name <> UPPER(t.Name) COLLATE SQL_Latin1_General_CP1_CS_AS