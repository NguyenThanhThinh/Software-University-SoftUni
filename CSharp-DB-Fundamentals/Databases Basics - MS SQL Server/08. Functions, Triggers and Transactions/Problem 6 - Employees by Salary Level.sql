CREATE PROC usp_EmployeesBySalaryLevel (@SalaryLevel varchar(7))
AS
SELECT e.FirstName, e.LastName FROM Employees AS [e]
WHERE [dbo].[ufn_GetSalaryLevel](e.Salary) = @SalaryLevel