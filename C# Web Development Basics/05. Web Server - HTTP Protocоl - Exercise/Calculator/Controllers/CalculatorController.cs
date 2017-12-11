namespace Calculator.Controllers
{
    using ByTheCake.ByTheCakeApplication.Infrastructure;
    using ByTheCake.Server.HTTP.Contracts;

    public class CalculatorController : Controller
    {
        public IHttpResponse Calculate()
        {
            return this.FileViewResponse(@"\calculator.html");
        }

        public IHttpResponse Calculate(string firstNumber, string sign, string secondNumber)
        {
            long result = 0;
            int firstNum = int.Parse(firstNumber);
            int secondNum = int.Parse(secondNumber);

            switch (sign)
            {
                case "*": result = firstNum * secondNum; break;
                case "-": result = firstNum - secondNum; break;
                case "+": result = firstNum + secondNum; break;
                case "/": result = firstNum / secondNum; break;
            }

            return this.FileViewResponse(result.ToString());
        }
    }
}