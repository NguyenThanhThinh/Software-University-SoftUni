CREATE FUNCTION udf_GetReportsCount(@employeeId int, @statusId int)
RETURNS int
AS
BEGIN
	DECLARE @Sum int = (SELECT COUNT(*) FROM Reports as [r]
	WHERE r.EmployeeId = @employeeId AND r.StatusId = @statusId)

	RETURN @Sum
END