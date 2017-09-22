CREATE PROC usp_GetTownsStartingWith (@TownName nvarchar(20))
AS
SELECT t.Name FROM Towns AS [t]
WHERE t.Name LIKE @TownName + '%'