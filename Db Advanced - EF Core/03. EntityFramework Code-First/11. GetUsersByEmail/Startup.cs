using System.Linq;

namespace _11.GetUsersByEmail
{

    using System;

    public class Startup
    {
        public static void Main()
        {
            string emailProvider = Console.ReadLine();
            UsersContext context = new UsersContext();

            var users = context.Users.Where(u => u.Email.EndsWith(emailProvider));

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Username} {user.Email}");
            }
        }
    }
}