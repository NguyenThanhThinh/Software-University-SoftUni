using System;
using System.Linq;
using System.Reflection;

public class PizzaTime
{
    public static void Main()
    {
        MethodInfo[] methods = typeof(Pizza).GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Contains("SortedDictionary"));
        if (!containsMethod)
        {
            throw new Exception();
        }

        var input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        var pizzas = new Pizza();
        pizzas.PizzaMethod(input);
    }
}