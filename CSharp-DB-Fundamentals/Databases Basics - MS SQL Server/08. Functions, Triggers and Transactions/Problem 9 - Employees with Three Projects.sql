CREATE PROC usp_AssignProject(@emloyeeId int, @projectID int)
AS
BEGIN TRANSACTION

DECLARE @projectsCount int;

SET @projectsCount = (SELECT pc.count FROM
(SELECT ep.EmployeeID, COUNT(*) AS [count] FROM EmployeesProjects AS [ep]
WHERE ep.EmployeeID = @emloyeeId
GROUP BY ep.EmployeeID) AS [pc])

if(@projectsCount >= 3)
BEGIN
RAISERROR('The employee has too many projects!', 16, 1)
ROLLBACK
END

INSERT INTO EmployeesProjects
VALUES (@emloyeeId, @projectID)

COMMIT