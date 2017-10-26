namespace _07.Gringotts_Database
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            WizardDeposit dumbledore = new WizardDeposit()
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2006, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 2000.24M,
                DepositCharge = 0.2,
                IsDepositExpired = false
            };

            GringotsContext context = new GringotsContext();
            context.WizardDeposits.Add(dumbledore);
            context.SaveChanges();
        }
    }
}