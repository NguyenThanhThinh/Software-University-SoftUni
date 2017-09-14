using System;
using Ninject;

public class Startup
{
    public static void Main()
    {
        KernelBase kernel = new StandardKernel();
        kernel.Bind<ICalculationalable>().To<AdditionStrategy>();
        kernel.Bind<ICalculationalable>().To<DivideStrategy>();
        kernel.Bind<ICalculationalable>().To<MultiplyStrategy>();
        kernel.Bind<ICalculationalable>().To<SubtractionStrategy>();

        var primitiveCalculator = kernel.Get<PrimitiveCalculator>();

        var input = Console.ReadLine();

        while (!input.Equals("End"))
        {
            var splitInput = input.Split();

            if (splitInput[0].Equals("mode"))
            {
                char sign = splitInput[1][0];
                primitiveCalculator.ChangeStrategy(sign);
            }
            else
            {
                var firstNum = int.Parse(splitInput[0]);
                var secondNum = int.Parse(splitInput[1]);
                Console.WriteLine(primitiveCalculator.PerformCalculation(firstNum, secondNum));
            }

            input = Console.ReadLine();
        }

        Console.WriteLine();
    }
}