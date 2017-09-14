SELECT mc.CountryCode, COUNT(m.MountainRange) FROM Mountains AS [m]
INNER JOIN MountainsCountries AS [mc]
ON m.Id = mc.MountainId
AND mc.CountryCode IN ('BG', 'RU', 'US')
GROUP BY mc.CountryCode