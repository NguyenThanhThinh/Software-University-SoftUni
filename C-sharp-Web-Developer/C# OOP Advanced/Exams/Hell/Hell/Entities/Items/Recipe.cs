using System.Collections.Generic;

public class Recipe : Item, IRecipe
{
    private IList<string> requiredItems;

    public Recipe(string name, string heroName, long strengthBonus, long agilityBonus, long intelligenceBonus, long hitPointsBonus, long damageBonus,
            params string[] requiredItems)
        : base(name, heroName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = requiredItems;
    }

    public IList<string> RequiredItems
    {
        get { return this.requiredItems; }
        protected set { this.requiredItems = value; }
    }
}