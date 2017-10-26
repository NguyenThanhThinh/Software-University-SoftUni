namespace _14.FirstLetter
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            GringottsContext gringottsContext = new GringottsContext();

            var wizards = gringottsContext.WizzardDeposits
                .Where(w => w.DepositGroup.Equals("Troll Chest"))
                .Select(w => w.FirstName.Substring(0, 1))
                .Distinct();

            foreach (var wiz in wizards)
            {
                Console.WriteLine(wiz);
            }
        }
    }
}