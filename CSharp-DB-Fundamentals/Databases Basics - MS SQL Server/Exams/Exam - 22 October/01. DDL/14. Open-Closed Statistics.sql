/*
DECLARE @open int;
DECLARE @closed int;

SET @open = (SELECT
  CASE WHEN YEAR(r.OpenDate) = 2016 THEN 1
  ELSE 0
  END
  FROM Employees as [e]
 INNER JOIN Reports as [r] ON e.Id = r.EmployeeId AND (YEAR(r.OpenDate) = 2016 OR YEAR(r.CloseDate) = 2016))

 SET @closed = (SELECT
  CASE WHEN YEAR(r.OpenDate) = 2016 THEN 1
  ELSE 0
  END
  FROM Employees as [e]
 INNER JOIN Reports as [r] ON e.Id = r.EmployeeId AND (YEAR(r.OpenDate) = 2016 OR YEAR(r.CloseDate) = 2016))
*/




DECLARE @open int = 0;
DECLARE @closed int = 0;
DECLARE @firstName nvarchar;
DECLARE @secondName nvarchar;

DECLARE MY_CURSOR CURSOR 
  LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR 
SELECT (Name, closed)
FROM 
(SELECT e.FirstName + ' ' + e.LastName AS [Name],
  CASE WHEN YEAR(r.CloseDate) = 2016 THEN 1
  ELSE 0 END AS [closed],
  CASE WHEN YEAR(r.OpenDate) = 2016 THEN 1
  ELSE 0 END AS [open]
  FROM Employees as [e]
 INNER JOIN Reports as [r] ON e.Id = r.EmployeeId AND (YEAR(r.OpenDate) = 2016 OR YEAR(r.CloseDate) = 2016)
 ORDER BY Name, e.Id) as [s1]

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @CurrentCloseDate
WHILE @@FETCH_STATUS = 0
BEGIN 
    --Do something with Id here
    IF( IS NOT NULL)
	BEGIN
	UPDATE Reports
	SET StatusId = 3
	WHERE Id IN (SELECT Id FROM inserted)
	END
    FETCH NEXT FROM MY_CURSOR INTO @CurrentCloseDate
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR

