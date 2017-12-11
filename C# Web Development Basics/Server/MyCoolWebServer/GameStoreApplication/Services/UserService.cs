namespace MyCoolWebServer.GameStoreApplication.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;

    public class UserService : IUserService
    {
        public bool Create(string email, string name, string password)
        {
            using (var db = new GameStoreDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                bool isAdmin = db.Users.Any();

                User user = new User()
                {
                    Email = email,
                    FullName = name,
                    Password = password,
                    IsAdmin = isAdmin
                };

                db.Add(user);
                db.SaveChanges();
            }

            return true;
        }

        public bool Find(string email, string password)
        {
            using (var db = new GameStoreDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);

                if (user == null || user.Password != password)
                {
                    return false;
                }

                return true;
            }
        }

        public bool IsAdmin(string email)
        {
            using (var db = new GameStoreDbContext())
            {
                return db.Users.Any(u => u.Email == email && u.IsAdmin);
            }
        }
    }
}