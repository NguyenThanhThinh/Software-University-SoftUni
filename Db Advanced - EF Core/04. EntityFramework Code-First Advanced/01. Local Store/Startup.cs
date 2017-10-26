namespace _01.Local_Store
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            StoreContext context = new StoreContext();
            context.Database.Initialize(true);
        }
    }
}