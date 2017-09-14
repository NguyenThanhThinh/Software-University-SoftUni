SELECT TOP 5 EmployeeID, JobTitle, a.AddressID, a.AddressText 
      FROM Employees AS e
INNER JOIN Addresses AS a
        ON e.AddressID = a.AddressID
  ORDER BY a.AddressID