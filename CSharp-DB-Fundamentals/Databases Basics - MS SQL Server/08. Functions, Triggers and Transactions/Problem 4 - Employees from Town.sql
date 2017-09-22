CREATE PROC dbo.usp_GetEmployeesFromTown (@TownName nvarchar(20))
AS
SELECT e.FirstName, e.LastName FROM Employees AS [e]
INNER JOIN Addresses AS [a]
ON a.AddressID = e.AddressID
INNER JOIN Towns AS [t]
ON t.TownID = a.TownID
WHERE t.Name = @TownName