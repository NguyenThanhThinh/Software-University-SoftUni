using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace _03.Employees_Full_Info
{
    using System;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            /* Each Method is different task from the homework. It is created this way for timesave and less space.
             * All methods use SoftUni Database */

            //EmployeesFullInfo();
            //EmployeesWithSalaryOver5k();
            //EmployeesFromResearchAndDevelopment();
            //AddingNewAddressAndUpdatingEmployee();
            //FindEmployeesInPeriod();
            //AddressesByTownName();
            //EmployeeWithId147();
            //DepartmentsWithMoreThanFiveEmployees();
            //FindLatestTenProjects();
            //IncreaseSalaries();
            //FindEmployeesByFirstNameStartingWithSA();
            //DeleteProjectById();
            //RemoveTowns();
            //ExecuterForPrintNamesWithNativeQueryAndPrintNamesWithLinq();
        }

        private static void ExecuterForPrintNamesWithNativeQueryAndPrintNamesWithLinq()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var timer = new Stopwatch();
            timer.Start();
            PrintNamesWithLinq(softUniContext);
            timer.Stop();
            Console.WriteLine($"Linq: {timer.Elapsed}");

            timer.Restart();
            PrintNamesWithNativeQuery(softUniContext);
            timer.Stop();
            Console.WriteLine($"Native Query: {timer.Elapsed}");
        }

        private static void PrintNamesWithNativeQuery(SoftUniContext softUniContext)
        {
            string query = File.ReadAllText("../../Query.sql");

            var employeesName = softUniContext.Database.SqlQuery<CustomQuery>(query).ToList();

            Console.WriteLine($"PrintNamesWithNativeQuery employees count result: {employeesName.Count}");
        }

        private static void PrintNamesWithLinq(SoftUniContext softUniContext)
        {
            List<string> employeesName = softUniContext.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year == 2002))
                .Select(e => e.FirstName)
                .OrderBy(e => e)
                .ToList();

            Console.WriteLine($"PrintNamesWithLinq employees count result: {employeesName.Count}");
        }

        private static void RemoveTowns()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            string town = Console.ReadLine();
            Town townToRemove = softUniContext.Towns.FirstOrDefault(t => t.Name.Equals(town));

            var addressesByTown = softUniContext.Addresses.Where(a => a.Town.Name.Equals(town)).ToList();

            foreach (var address in addressesByTown)
            {
                var employeesToUpdate = address.Employees;
                foreach (var emp in employeesToUpdate)
                {
                    emp.AddressID = null;
                }
            }

            softUniContext.Addresses.RemoveRange(addressesByTown);

            if (townToRemove != null)
            {
                softUniContext.Towns.Remove(townToRemove);
            }

            softUniContext.SaveChanges();

            int addressesCount = addressesByTown.Count;

            Console.WriteLine(addressesCount == 1
                ? $"{addressesCount} address in {town} was deleted"
                : $"{addressesCount} addresses in {town} were deleted");
        }

        private static void DeleteProjectById()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Project projectToRemove = softUniContext.Projects.FirstOrDefault(p => p.ProjectID == 2);

            foreach (Employee emp in projectToRemove.Employees)
            {
                emp.Projects.Remove(projectToRemove);
            }

            softUniContext.Projects.Remove(projectToRemove);
            softUniContext.SaveChanges();

            var projects = softUniContext.Projects
                .Take(10)
                .Select(p => p.Name);

            foreach (var project in projects)
            {
                Console.WriteLine(project);
            }
        }

        private static void FindEmployeesByFirstNameStartingWithSA()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var employees = softUniContext.Employees
                .Where(e => e.FirstName.StartsWith("SA"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                });

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary})");
            }
        }

        private static void IncreaseSalaries()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var employees = softUniContext.Employees.Where(e => e.Department.Name.Equals("Engineering")
                                                                || e.Department.Name.Equals("Tool Design")
                                                                || e.Department.Name.Equals("Marketing")
                                                                || e.Department.Name.Equals("Information Services"));

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12M;
                Console.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary})");
            }

            /* run this command, only if you want to save the changes, it's already done, so we will not increase salary any more*/
            //softUniContext.SaveChanges();
        }

        private static void FindLatestTenProjects()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var projects = softUniContext.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate,
                    p.EndDate
                })
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Name} {project.Description} {project.StartDate} {project.EndDate}");
            }
        }

        private static void DepartmentsWithMoreThanFiveEmployees()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            // this is another solution of the problem

            //var deparments = softUniContext.Departments
            //    .Where(d => d.Employees.Count > 5)
            //    .OrderBy(d => d.Employees.Count)
            //    .Select(d => new
            //    {
            //        d.Name,
            //        managerFirstName = d.Manager.FirstName,
            //        employees = d.Employees
            //            .Select(e => new
            //            {
            //                e.FirstName,
            //                e.LastName,
            //                e.JobTitle
            //            })
            //    })
            //    .ToList();

            //foreach (var depart in deparments)
            //{
            //    Console.WriteLine($"{depart.Name} {depart.managerFirstName}");
            //    foreach (var emp in depart.employees)
            //    {
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
            //    }
            //}

            var departTest = softUniContext.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count);

            foreach (var depart in departTest)
            {
                Console.WriteLine($"{depart.Name} {depart.Manager.FirstName}");
                foreach (var emp in depart.Employees)
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                }
            }
        }

        private static void EmployeeWithId147()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var employee = softUniContext.Employees
                .Where(e => e.EmployeeID == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    projects = e.Projects.OrderBy(p => p.Name)
                        .Select(p => p.Name)
                })
                .ToList();

            foreach (var emp in employee)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
                foreach (var project in emp.projects)
                {
                    Console.WriteLine(project);
                }
            }
        }

        private static void AddressesByTownName()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var addresses = softUniContext.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    townName = a.Town.Name,
                    employeesCount = a.Employees.Count
                })
                .ToList();

            foreach (var addr in addresses)
            {
                Console.WriteLine($"{addr.AddressText}, {addr.townName} - {addr.employeesCount} employees");
            }
        }

        private static void FindEmployeesInPeriod()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var employees = softUniContext.Employees
                .Where(e => e.Projects
                    .Any(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003))
                .Take(30)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    managerFirstName = e.Manager.FirstName,
                    e.Projects
                })
                .ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.managerFirstName}");
                foreach (var project in emp.Projects)
                {
                    Console.WriteLine($"--{project.Name} {project.StartDate} {project.EndDate}");
                }
            }
        }

        private static void AddingNewAddressAndUpdatingEmployee()
        {
            SoftUniContext softUniContext = new SoftUniContext();
            Address nakovAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            softUniContext.Employees
                .FirstOrDefault(e => e.LastName.Equals("Nakov"))
                .Address = nakovAddress;

            softUniContext.SaveChanges();

            var employees = softUniContext.Employees
                .OrderByDescending(e => e.AddressID)
                .Take(10)
                .Select(e => e.Address)
                .ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.AddressText);
            }
        }

        private static void EmployeesFromResearchAndDevelopment()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var employees = softUniContext.Employees
                .Where(e => e.Department.Name.Equals("Research and Development"))
                .Select(e => new
                {
                    e.Salary,
                    e.FirstName,
                    e.LastName,
                    DeparmentName = e.Department.Name,
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.DeparmentName} - ${emp.Salary:F2}");
            }
        }

        private static void EmployeesWithSalaryOver5k()
        {
            SoftUniContext softUniContext = new SoftUniContext();

            var employees = softUniContext.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName
                })
                .ToList();

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName}");
            }
        }

        private static void EmployeesFullInfo()
        {
            SoftUniContext softUniEntities = new SoftUniContext();

            var employees = softUniEntities.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.MiddleName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeID
                })
                .ToList()
                .OrderBy(e => e.EmployeeID);

            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary}");
            }
        }
    }
}