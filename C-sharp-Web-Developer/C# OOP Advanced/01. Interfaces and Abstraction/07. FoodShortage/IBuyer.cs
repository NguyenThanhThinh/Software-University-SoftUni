namespace _07.FoodShortage
{
    public interface IBuyer
    {
        void BuyFood();
        string Name { get; set; }
        int Food { get; set; }
    }
}
