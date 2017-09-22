CREATE PROC dbo.usp_GetEmployeesSalaryAboveNumber (@Ammount money)
AS
SELECT FirstName, LastName FROM Employees AS [e]
WHERE e.Salary >= @Ammount