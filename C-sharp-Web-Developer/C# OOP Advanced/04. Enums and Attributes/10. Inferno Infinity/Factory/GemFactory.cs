namespace _10.Inferno_Infinity.Factory
{
    public class GemFactory
    {
        public static Gem CreateGem(string input)
        {
            var splitInput = input.Split();
            var quality = splitInput[0];
            var type = splitInput[1];

            switch (type)
            {
                case "Ruby":
                    return new Ruby(quality);
                case "Emerald":
                    return new Emerald(quality);
                default:
                    return new Amethyst(quality);
            }
        }        
    }
}