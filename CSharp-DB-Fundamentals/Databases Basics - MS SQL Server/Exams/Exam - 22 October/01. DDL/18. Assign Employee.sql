CREATE PROCEDURE usp_AssignEmployeeToReport(@employeeId int, @reportId int)
AS

	DECLARE @EmployeeDep int;
	DECLARE @ReportDep int;

	SET @EmployeeDep = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
	
	SET @ReportDep = (SELECT c.DepartmentId FROM Reports as [r]
					   INNER JOIN Categories as [c] ON c.Id = r.CategoryId
					   WHERE r.Id = @reportId)

	IF(@EmployeeDep = @ReportDep)
	BEGIN
	UPDATE Reports
	SET EmployeeId = @employeeId
	END

	ELSE
	BEGIN
	RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
	END