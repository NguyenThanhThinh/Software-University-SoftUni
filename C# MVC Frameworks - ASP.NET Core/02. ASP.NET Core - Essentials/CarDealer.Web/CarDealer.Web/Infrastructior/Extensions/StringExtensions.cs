namespace CarDealer.Web.Infrastructior.Extensions
{
    public static class StringExtensions
    {
        public static string ToPrice(this double number)
        {
            string value = number.ToString("F2");
            return value;
        }

        public static string ToPrice(this double? number)
        {
            if (number != null)
            {
                double value = (double)number;

                return value.ToString("F2");
            }
            return null;
        }
    }
}