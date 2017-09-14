SELECT usages.ContinentCode, usages.CurrencyCode, usages.usage FROM
	(SELECT c1.ContinentCode, c1.CurrencyCode, COUNT(*) AS [usage] FROM Countries AS [c1]
	GROUP BY c1.ContinentCode, c1.CurrencyCode) AS usages
INNER JOIN 
	(SELECT totalUsage.ContinentCode, MAX(totalUsage.usage) AS [Usage] FROM
		(SELECT c.ContinentCode, c.CurrencyCode, COUNT(*) AS [usage] FROM Countries AS [c]
		GROUP BY c.ContinentCode, c.CurrencyCode) AS [totalUsage]
	GROUP BY totalUsage.ContinentCode) AS lastUsage
ON usages.usage = lastUsage.Usage AND usages.ContinentCode = lastUsage.ContinentCode
WHERE usages.usage > 1
ORDER BY usages.ContinentCode