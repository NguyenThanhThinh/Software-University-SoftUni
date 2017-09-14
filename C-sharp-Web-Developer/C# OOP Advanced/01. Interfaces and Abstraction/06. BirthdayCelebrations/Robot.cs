namespace _05.BorderControl
{
    public class Robot : ICountable
    {
        private string id;
        private string model;

        public Robot(string id, string model)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}