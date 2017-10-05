SELECT m.ModelId, 
	   m.Name, 
	   CONCAT(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)), ' ', 'days') AS [Average Service Time] 
  FROM Models AS [m]
 INNER JOIN Jobs AS [j]
	ON m.ModelId = j.ModelId
GROUP BY m.ModelId, m.Name
ORDER BY AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate))