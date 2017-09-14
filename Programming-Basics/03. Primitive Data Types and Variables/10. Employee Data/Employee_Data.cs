using System;

class Employee_Data
{
    static void Main()
    {
        string firstName = "Sevdalin";
        string lastName = "Paunov";
        int age = 26;
        char gender = 'm';
        object idNumber = 8306112507;
        long employeeNumber = 27569999;

        Console.WriteLine("First Name: {0}", firstName);
        Console.WriteLine("Last Name: {0}", lastName);
        Console.WriteLine("Age: {0}", age);
        Console.WriteLine("Gender: {0}", gender);
        Console.WriteLine("Personal ID: {0}", idNumber);
        Console.WriteLine("Unique Employee number: {0}", employeeNumber);
    }
}
