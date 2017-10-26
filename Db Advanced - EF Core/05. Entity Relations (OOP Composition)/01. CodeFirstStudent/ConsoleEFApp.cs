namespace _01._CodeFirstStudent
{
    using System;
    using System.Linq;

    public class ConsoleEFApp
    {
        public ConsoleEFApp(StudentContext db)
        {
            this.Db = db;
        }

        private StudentContext Db { get; }

        public void GetSpecificInformationAboutEachStudent()
        {
            var studentsInfo = this.Db.Students
                .Select(s => new
                {
                    s.Name,
                    NumberOfCourses = s.Courses.Count,
                    CoursesTotalPrice = s.Courses.Sum(c => c.Course.Price),
                    CourseAvaragePrice = s.Courses.Count > 0 ? s.Courses.Average(c => c.Course.Price) : 0
                })
                .OrderByDescending(s => s.CoursesTotalPrice)
                .ThenByDescending(s => s.NumberOfCourses)
                .ThenBy(s => s.Name)
                .ToList();

            Console.WriteLine($"Students Info: {Environment.NewLine}");

            foreach (var student in studentsInfo)
            {
                Console.WriteLine($"Student {student.Name}");
                Console.WriteLine($"Partiscipate in {student.NumberOfCourses} courses");
                Console.WriteLine($"Total price: {student.CoursesTotalPrice}");
                Console.WriteLine($"Avarage Price: {student.CourseAvaragePrice}");
                Console.WriteLine("------------------------");
            }
        }

        public void ListAllCoursesWhichWereActiveOnGivenDate()
        {
            Console.Write("Type given date in format (yyyy,mm,dd): ");
            string input = Console.ReadLine();
            DateTime givenDate = DateTime.Parse(input);

            var courses = this.Db.Courses
                .Where(c => c.StartDate.CompareTo(givenDate) <= 0 && c.EndDate.CompareTo(givenDate) >= 0)
                .Select(c => new
                {
                    StudentsEnrolled = c.Students.Count,
                    CourseName = c.Name,
                    c.StartDate,
                    c.EndDate,
                    CourceDuration = c.EndDate.Subtract(c.StartDate)
                })
                .OrderByDescending(c => c.StudentsEnrolled)
                .ThenByDescending(c => c.CourceDuration)
                .ToList();

            Console.WriteLine("Results:");
            Console.WriteLine("*************");

            foreach (var course in courses)
            {
                Console.WriteLine($"Course Name: {course.CourseName}");
                Console.WriteLine($"Course StartDate <-> EndDate: {course.StartDate} <-> {course.EndDate}");
                Console.WriteLine($"Course Duration in days: {course.CourceDuration}");
                Console.WriteLine($"Students Enrolled: {course.StudentsEnrolled}");
                Console.WriteLine("--------------------------");
            }
        }

        public void ListAllCoursesWithMoreThenFiveResources()
        {
            var courses = this.Db.Courses
                .Where(c => c.Resources.Count > 5)
                .OrderByDescending(c => c.Resources.Count)
                .ThenByDescending(c => c.StartDate)
                .Select(c => new
                {
                    c.Name,
                    ResourcesCount = c.Resources.Count
                });

            foreach (var course in courses)
            {
                Console.WriteLine($"Course name: {course.Name}");
                Console.WriteLine($"Course Resorces: {course.ResourcesCount}");
            }
        }

        public void ListAllStudentsAndThereHomeworkSubmissions()
        {
            var students = this.Db.Students
                .Select(s => new
                {
                    s.Name,
                    Homeworks = s.Homeworks
                        .Select(h => new
                        {
                            h.Content,
                            h.ContentType
                        })
                })
                .ToList();

            foreach (var student in students)
            {
                int index = 1;
                Console.WriteLine($"Student {student.Name}");
                foreach (var hw in student.Homeworks)
                {
                    Console.WriteLine($"Homework {index}:");
                    Console.WriteLine($"Content Type: {hw.ContentType}");
                    Console.WriteLine($"Content: {hw.Content}");
                    index++;
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public void ListAllCoursesWithCorespondingResources()
        {
            var courses = this.Db.Courses
                .OrderBy(c => c.StartDate)
                .ThenByDescending(c => c.EndDate)
                .Select(c => new
                {
                    c.Name,
                    c.Description,
                    c.Resources
                })
                .ToList();

            foreach (var course in courses)
            {
                int index = 1;
                Console.WriteLine($"Course {course.Name} with description: {course.Description}");
                Console.WriteLine($"Resources:");
                foreach (var resource in course.Resources)
                {
                    Console.WriteLine($"{index}. {resource.Name}");
                    Console.WriteLine($"Type of resource: {resource.TypeOfResource}");
                    Console.WriteLine($"URL: {resource.Url}");
                }
                Console.WriteLine("---------------------------");
            }
        }
    }
}