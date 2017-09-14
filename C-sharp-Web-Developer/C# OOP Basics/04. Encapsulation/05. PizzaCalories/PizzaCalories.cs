using System;
using System.Text;

public class PizzaCalories
{
    public static void Main()
    {
        var pizzaInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var pizza = new Pizza();
        var resultIfThereIsNoPizza = new StringBuilder();

        try
        {
            while (!pizzaInfo[0].Equals("END"))
            {
                if (pizzaInfo[0].Equals("Dough"))
                {
                    var dough = new Dough(pizzaInfo[1], pizzaInfo[2], double.Parse(pizzaInfo[3]));
                    pizza.DoughType = dough;
                    resultIfThereIsNoPizza.AppendLine($"{dough.CalculateCalories():F2}");
                }
                else if (pizzaInfo[0].Equals("Topping"))
                {
                    var topping = new Topping(pizzaInfo[1], double.Parse(pizzaInfo[2]));
                    resultIfThereIsNoPizza.AppendLine($"{topping.CalculateCalories():F2}");
                    pizza.AddToppingToTheList(topping);
                }
                else if (pizzaInfo[0].Equals("Pizza"))
                {
                    pizza = new Pizza(pizzaInfo[1], int.Parse(pizzaInfo[2]));
                }
                pizzaInfo = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            if (!string.IsNullOrEmpty(pizza.Name))
            {
                Console.WriteLine($"{pizza.Name} - {pizza.GetAllCaloriesPizzaHave():F2} Calories.");
            }
            else
            {
                Console.WriteLine(resultIfThereIsNoPizza);
            }
        }
        catch (ArgumentException ex)
        {
            if (string.IsNullOrEmpty(pizza.Name))
            {
                Console.Write(resultIfThereIsNoPizza);
            }
            Console.WriteLine(ex.Message);
        }
    }
}