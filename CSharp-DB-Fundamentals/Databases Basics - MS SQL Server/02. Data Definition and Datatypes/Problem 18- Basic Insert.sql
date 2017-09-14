INSERT INTO Towns (Name)
VALUES ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

INSERT INTO Addresses (AddressText, TownId)
VALUES ('asd', 1), ('asdd', 2), ('adsd', 3), ('awsd', 4)

INSERT INTO Departments (Name)
VALUES ('asd'), ('asdd'), ('adsd'), ('awsd')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
VALUES ('Sevdalin', 'Stoynov', 'Paunov', 'RTS', 4, '07/07/2017', 1333.33, 2)