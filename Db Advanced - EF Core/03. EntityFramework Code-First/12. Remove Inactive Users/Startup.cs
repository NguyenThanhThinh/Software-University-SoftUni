namespace _12.Remove_Inactive_Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            string givenDate = Console.ReadLine();
            UserContext context = new UserContext();

            DateTime parsedDate = ConvertStringToDateTimeObject(givenDate);

            List<User> foundedUsers = context.Users.Where(u => u.RastTimeLoggedIn.CompareTo(parsedDate) < 0).ToList();

            SetIsDeletedToTrue(foundedUsers);

            DeleteUsersWithIsDeletedSetToTrue(foundedUsers, context);
        }

        public static DateTime ConvertStringToDateTimeObject(string givenDate)
        {
            string[] splitGivenDate =
                givenDate.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            int day = int.Parse(splitGivenDate[0]);
            int month = (int)Enum.Parse(typeof(Months), splitGivenDate[1]);
            int year = int.Parse(splitGivenDate[2]);

            DateTime date = new DateTime(year, month, day);

            return date;
        }

        public static void SetIsDeletedToTrue(List<User> foundedUsers)
        {
            foreach (var user in foundedUsers)
            {
                user.IsDeleted = true;
            }
        }

        private static void DeleteUsersWithIsDeletedSetToTrue(List<User> foundedUsers, UserContext context)
        {
            int usersForDelete = foundedUsers.Count;

            Console.WriteLine(usersForDelete > 0 ? $"{usersForDelete} users have been deleted" : "No users have been deleted");
            context.Users.RemoveRange(foundedUsers);
        }
    }
}