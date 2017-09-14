SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation
  FROM Mountains AS [m]
INNER JOIN Peaks AS [p]
ON m.Id = p.MountainId
AND p.Elevation > 2835
INNER JOIN MountainsCountries AS [mc]
ON m.Id = mc.MountainId
AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC