using System.Collections.Generic;
using _09.Hospital_Database.Models;

namespace _09.Hospital_Database
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Patient patient = new Patient()
            {
                FirstName = "Sev",
                LastName = "Pau",
                Address = "str.32 blg.4, Sofia",
                Email = "sev2@abv.bg",
                DateOfBirth = new DateTime(1989, 06, 02),
                MedicalInsurance = false,
                Medicaments = new List<string> { "Asperin", "Analgin", "Vitamin" }
            };

            Diagnose diagnose = new Diagnose()
            {
                Name = "GoodBacteria"
            };

            Doctor doctor = new Doctor()
            {
                Name = "Petrov",
                Specialty = "Sergary"
            };

            Visitation visitation = new Visitation()
            {
                VisitDate = new DateTime(2017, 10, 10),
                Doctor = doctor
            };

            patient.Diagnoses.Add(diagnose);
            patient.Visitations.Add(visitation);

            HospitalContext context = new HospitalContext();
            context.Patients.Add(patient);
            context.SaveChanges();
        }
    }
}