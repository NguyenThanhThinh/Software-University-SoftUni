public class GoldenEditionBook : Book
{
    private double price;

    public GoldenEditionBook(string title, string author, double price)
        : base(title, author, price)
    {
    }

    public override double Price
    {
        get { return price; }
        set
        {
            price = value * 1.3;
        }
    }
}