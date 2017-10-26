namespace _08.Create_User
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            User user = new User()
            {
                Username = "Sevdalin",
                Age = 27,
                Email = "sedio_2g@abv.bg",
                IsDeleted = false,
                Password = "jdH726$",
                RegisteredOn = new DateTime(2017, 10, 12),
                RastTimeLoggedIn = new DateTime(2017, 10, 17)
            };

            UserContext context = new UserContext();
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}