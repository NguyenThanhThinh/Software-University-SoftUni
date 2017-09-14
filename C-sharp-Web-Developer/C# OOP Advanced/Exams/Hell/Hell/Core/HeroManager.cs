using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HeroManager : IManager
{
    private Dictionary<string, IHero> heroes;

    public HeroManager(Dictionary<string, IHero> heroes)
    {
        this.Heroes = heroes;
    }

    public Dictionary<string, IHero> Heroes
    {
        get { return this.heroes; }
        set { this.heroes = value; }
    }

    public string AddHero(IList<String> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });

            this.Heroes[heroName] = hero;
            result = string.Format(Constants.HeroCreateMessage, heroType, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItemToHero(IList<String> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        if (arguments.Count > 7)
        {
            string[] requiredItems = arguments.Skip(7).ToArray();
            IRecipe newRecipe = new Recipe(itemName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);

            this.Heroes[heroName].Inventory.AddRecipeItem(newRecipe);
            result = string.Format(Constants.RecipeCreatedMessage, newRecipe.Name, heroName);
        }

        else
        {
            IItem newItem = new CommonItem(itemName, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
                damageBonus);

            this.Heroes[heroName].Inventory.AddCommonItem(newItem);
            result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        }

        return result;
    }

    public string Inspect(IList<String> arguments)
    {
        string heroName = arguments[0];

        return this.Heroes[heroName].ToString();
    }

    public string Quit()
    {
        StringBuilder sb = new StringBuilder();
        int index = 1;

        foreach (var hero in this.Heroes.OrderByDescending(h => h.Value.PrimaryStats)
            .ThenByDescending(h => h.Value.SecondaryStats))
        {

            sb.AppendLine($"{index}. {hero.Value.GetType().Name}: {hero.Value.Name}")
                .AppendLine($"###HitPoints: {hero.Value.HitPoints}")
                .AppendLine($"###Damage: {hero.Value.Damage}")
                .AppendLine($"###Strength: {hero.Value.Strength}")
                .AppendLine($"###Agility: {hero.Value.Agility}")
                .AppendLine($"###Intelligence: {hero.Value.Intelligence}");

            sb.AppendLine(hero.Value.Items.Count == 0
                ? "###Items: None"
                : $"###Items: {String.Join(", ", hero.Value.Items.Select(x => x.Name).ToList())}");

            index++;
        }

        return sb.ToString();
    }
}