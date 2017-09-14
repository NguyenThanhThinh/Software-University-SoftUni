using System;

class PrintCompanyInformation
{
    static void Main()
    {
        string companyName = Console.ReadLine();
        string companyAddress = Console.ReadLine();
        string phoneNumber = Console.ReadLine();
        string faxNumber = Console.ReadLine();
        string website = Console.ReadLine();
        string firstName = Console.ReadLine();
        string lastName = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string managerPhone = Console.ReadLine();

        Console.Write(Environment.NewLine + companyName + Environment.NewLine + "Address: {0}" + Environment.NewLine + "Phone number: {1}" + Environment.NewLine,
            companyAddress, phoneNumber);

        if (faxNumber == "")
        {
            Console.WriteLine("Fax: (no fax)");
        }
        else
        {
            Console.WriteLine("Fax: {0}", faxNumber);
        }

        Console.WriteLine("Web site: {0}" + Environment.NewLine + "Manager: {1} {2} (age: {3}, tel. {4})", website, firstName, lastName, age, managerPhone);
        Console.WriteLine();
    }
}
