public class MathUtil
{
    public static string Sum(double firstNumber, double secondNumber)
    {
        return string.Format($"{firstNumber + secondNumber:F2}");
    }

    public static string Subtract(double firstNumber, double secondNumber)
    {
        return string.Format($"{firstNumber - secondNumber:F2}");
    }

    public static string Multiply(double firstNumber, double secondNumber)
    {
        return string.Format($"{firstNumber * secondNumber:F2}");
    }

    public static string Divide(double dividend, double divisor)
    {
        return string.Format($"{dividend / divisor:F2}");
    }

    public static string Percentage(double totalNumber, double percentOfTotalNumber)
    {
        return string.Format($"{(percentOfTotalNumber / 100) * totalNumber:F2}");
    }
}