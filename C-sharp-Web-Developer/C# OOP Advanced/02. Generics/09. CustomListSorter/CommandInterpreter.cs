using System.Text;
using _09.CustomListSorter;

namespace _08.CistomList
{
    public static class CommandInterpreter
    {
        private static DataStructure<string> data = new DataStructure<string>();
        private static StringBuilder result = new StringBuilder();

        public static DataStructure<string> Data
        {
            get { return data; }
            set { data = value; }
        }

        public static StringBuilder Result
        {
            get { return result; }
            set { result = value; }
        }

        public static void Command(string[] input)
        {
            var command = input[0];
            var value = string.Empty;

            if (input.Length > 1)
            {
                value = input[1];
            }
            var secondValue = 0;

            if (input.Length == 3)
            {
                secondValue = int.Parse(input[2]);
            }


            switch (command)
            {
                case "Add":
                    Data.Add(value);
                    break;
                case "Remove":
                    Data.Remove(int.Parse(value));
                    break;
                case "Contains":
                    Result.AppendLine(Data.Contains(value).ToString());
                    break;
                case "Swap":
                    Data.Swap(int.Parse(value), secondValue);
                    break;
                case "Greater":
                    Result.AppendLine(Data.CountGreaterThan(value).ToString());
                    break;
                case "Max":
                    Result.AppendLine(Data.Max());
                    break;
                case "Min":
                    Result.AppendLine(Data.Min());
                    break;
                case "Print":
                    Result.AppendLine(Data.ToString());
                    break;
                case "Sort":
                    var newData = Sorter<string>.Sort(data);
                    break;
            }
        }
    }
}