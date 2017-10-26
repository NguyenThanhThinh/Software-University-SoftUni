namespace _11._BankSystem
{
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        public static void Main()
        {
            using (BankSystemContext db = new BankSystemContext())
            {
                db.Database.Migrate();
            }
        }
    }
}