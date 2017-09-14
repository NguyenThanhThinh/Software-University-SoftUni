SELECT TOP (50) g.Name, FORMAT(Start, 'yyyy-MM-dd') AS [Start] 
 FROM Games AS [g]
WHERE DATEPART(year, Start) = 2011 OR DATEPART(year, Start) = 2012
ORDER BY g.Start, g.Name