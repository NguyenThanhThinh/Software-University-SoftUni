namespace _10.Inferno_Infinity.Factory
{
    public class WeaponFactory
    {
        public static Weapon CreateWeapon(string input)
        {
            var inputParts = input.Split(';');
            var rarityAndType = inputParts[1].Split();
            var rarity = rarityAndType[0];
            var type = rarityAndType[1];
            var name = inputParts[2];

            switch (type)
            {
                case "Axe":
                    return new Axe(name, rarity);
                case "Knife":
                    return new Knife(name, rarity);
                default:
                    return new Sword(name, rarity);
            }
        }
    }
}