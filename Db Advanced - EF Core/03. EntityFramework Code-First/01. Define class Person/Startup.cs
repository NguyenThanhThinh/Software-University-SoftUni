namespace _01.Define_class_Person
{
    using System;
    using System.Linq;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            Person first = new Person();
            first.Name = "Pesho";
            first.Age = 20;

            Person second = new Person()
            {
                Age = 20,
                Name = "Gosho"
            };

            // 2. Create Person Constructors
            //CreatePersonConstructors();

            // 3. Oldest Family Member
            //FindOldestFamilyMember();

            // 4. Students
            //Students();
        }

        private static void Students()
        {
            string input = Console.ReadLine();
            Student student = new Student(input);

            while (input != "End")
            {
                student = new Student(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(Student.Count);
        }

        private static void CreatePersonConstructors()
        {
            var input = Console.ReadLine();
            Person person = CreatePersonByDifferentCtors(input);
            Console.WriteLine(person);
        }

        private static void FindOldestFamilyMember()
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string input = Console.ReadLine();
                Person person = CreatePersonByDifferentCtors(input);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember());
        }

        public static Person CreatePersonByDifferentCtors(string input)
        {
            var splitInput = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string firstValue = string.Empty;
            string secondValue = String.Empty;
            int age;
            bool ageHasParsed;

            if (splitInput.Length == 0)
            {
                return new Person();
            }

            if (splitInput.Length == 1)
            {
                firstValue = splitInput[0];
                ageHasParsed = int.TryParse(firstValue, out age);

                if (ageHasParsed)
                {
                    return new Person(age);
                }

                return new Person(firstValue);
            }

            firstValue = splitInput[0];
            ageHasParsed = int.TryParse(firstValue, out age);

            if (ageHasParsed)
            {
                return new Person(secondValue, age);
            }

            secondValue = splitInput[1];
            age = int.Parse(secondValue);
            return new Person(firstValue, age);
        }
    }
}