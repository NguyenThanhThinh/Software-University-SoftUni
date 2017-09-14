using System;
using System.Text;

public class Student : Human
{
    private string facilityNumber;

    public Student(string firstName, string lastName, string facilityNumber) 
        : base(firstName, lastName)
    {
        this.FacilityNumber = facilityNumber;
    }

    public string FacilityNumber
    {
        get { return facilityNumber; }

        set
        {
            if (value.Length < 5 || value.Length > 10)
            {
                throw new  ArgumentException("Invalid faculty number!");
            }
            facilityNumber = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {LastName}");
        sb.AppendLine($"Faculty number: {facilityNumber}");

        return sb.ToString();
    }
}