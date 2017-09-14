using System;
using System.Linq;
using System.Reflection;
using _02BlackBoxInteger;

namespace _02.Black_Box_Integer
{
    public class Startup
    {
        // get private constructor
        private static ConstructorInfo constructor = typeof(BlackBoxInt)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
        // create instance using the private constructor info from above
        private static BlackBoxInt instance = (BlackBoxInt)constructor.Invoke(null);
        // get all methods using the instance we created above
        private static MethodInfo[] blackBoxMethods = typeof(BlackBoxInt)
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);
        // get all fields from the instance of above
        private static FieldInfo[] blackBoxFields = typeof(BlackBoxInt)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

        public static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                var inputSplit = input.Split('_');
                var command = inputSplit[0];
                var value = int.Parse(inputSplit[1]);

                InvokeCurrentMethod(value, command);

                input = Console.ReadLine();
            }
        }

        private static void InvokeCurrentMethod(int value, string command)
        {
            //long currentValue;

            blackBoxMethods.First(m => m.Name.Contains(command)).Invoke(instance, new object[] {value});
            Console.WriteLine(blackBoxFields.First().GetValue(instance).ToString());

            //foreach (var blackBoxMethod in blackBoxMethods)
            //{
            //    if (blackBoxMethod.Name.Contains(command))
            //    {
            //        blackBoxMethod.Invoke(instance, new object[] { value });
            //        break;
            //    }
            //}

            //foreach (var blackBoxField in blackBoxFields)
            //{
            //    currentValue = long.Parse(blackBoxField.GetValue(instance).ToString());
            //    Console.WriteLine(currentValue);
            //    break;
            //}
        }
    }
}