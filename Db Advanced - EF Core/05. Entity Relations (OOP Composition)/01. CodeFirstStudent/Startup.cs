namespace _01._CodeFirstStudent
{
    using Models;
    using System;

    public class Program
    {
        public static void Main()
        {
            StudentContext db = new StudentContext();
            db.Database.EnsureCreated();
            ConsoleEFApp efApp = new ConsoleEFApp(db);
            Seed(db);

        }


        public static void PhotoInser(StudentContext db)
        {

        }

        public static void Seed(StudentContext db)
        {
            Student studentOne = new Student()
            {
                Name = "Pesho",
                PhoneNumber = "0889773636",
                Birthday = new DateTime(1990, 04, 21),
                RegistrationDate = new DateTime(2017, 10, 10),
            };

            Student studentTwo = new Student()
            {
                Name = "Ivan",
                PhoneNumber = "0889773911",
                Birthday = new DateTime(1980, 04, 21),
                RegistrationDate = new DateTime(2017, 10, 12),
            };

            Homework homeworkOne = new Homework()
            {
                Content = "Content Content",
                ContentType = "Math",
                SubmissionDate = new DateTime(2017, 10, 01)
            };

            Homework homeworkTwo = new Homework()
            {
                Content = "More Content",
                ContentType = "Geography",
                SubmissionDate = new DateTime(2016, 09, 01)
            };

            Course courseOne = new Course()
            {
                Name = "Math",
                Description = "Something goes here",
                StartDate = new DateTime(2017, 06, 06),
                EndDate = new DateTime(2018, 01, 01),
                Price = 277M
            };

            Course courseTwo = new Course()
            {
                Name = "Science",
                Description = "Something goes here",
                StartDate = new DateTime(2016, 06, 06),
                EndDate = new DateTime(2017, 01, 01),
                Price = 377M
            };

            Resource resourceOne = new Resource()
            {
                Name = "Library",
                TypeOfResource = "Paid",
                Url = "www.test.bg"
            };

            Resource resourceTwo = new Resource()
            {
                Name = "School",
                TypeOfResource = "Free",
                Url = "www.school.bg"
            };

            StudentCource sc = new StudentCource()
            {
                Course = courseOne,
                Student = studentOne
            };

            StudentCource scTwo = new StudentCource()
            {
                Course = courseTwo,
                Student = studentTwo
            };

            studentOne.Homeworks.Add(homeworkOne);
            studentTwo.Homeworks.Add(homeworkTwo);

            resourceOne.Course = courseOne;
            resourceTwo.Course = courseTwo;

            courseOne.Homeworks.Add(homeworkOne);
            courseTwo.Homeworks.Add(homeworkTwo);
            courseOne.Resources.Add(resourceOne);
            courseTwo.Resources.Add(resourceTwo);

            db.Students.AddRange(studentOne, studentTwo);
            db.Courses.AddRange(courseOne, courseTwo);
            db.Homeworks.AddRange(homeworkOne, homeworkTwo);
            db.Resources.AddRange(resourceOne, resourceTwo);
            db.StudentCources.AddRange(sc, scTwo);

            db.SaveChanges();
        }
    }
}