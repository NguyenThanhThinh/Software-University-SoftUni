namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        private const string model = "488-Spider";
        private string driver;

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public string Model
        {
            get { return model; }
        }

        public string PushBrakes()
        {
            return "Brakes!";
        }

        public string PushGaz()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{PushBrakes()}/{PushGaz()}/{this.Driver}";
        }
    }
}