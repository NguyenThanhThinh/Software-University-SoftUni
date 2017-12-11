namespace GameStore.App.Services
{
    using System.Linq;
    using Contracts;
    using Data;
    using Data.Models;

    public class UserService : IUserService
    {
        private readonly GameStoreDbContext db;

        public UserService(GameStoreDbContext db)
        {
            this.db = db;
        }

        public bool Create(string email, string password, string name)
        {
            using (this.db)
            {
                bool emailExists = db.Users.Any(u => u.Email == email);

                if (emailExists)
                {
                    return false;
                }

                User user = new User
                {
                    Email = email,
                    Fullname = name,
                    Password = password
                };

                if (db.Users.Any())
                {
                    user.IsAdmin = true;
                }

                this.db.Users.Add(user);
                this.db.SaveChanges();
                return true;
            }
        }

        public bool UserExists(string email, string password)
        {
            return this.db.Users.Any(u => u.Email == email && u.Password == password);
        }
    }
}