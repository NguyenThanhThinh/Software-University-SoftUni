namespace _01.Define_class_Person.Models
{
    public class Calculation
    {
        public const double Planck = 0d;
        public const double Pi = 3.14159d;

        public static double ReducePlanck()
        {
            return Planck / (2 * Pi);
        }
    }
}