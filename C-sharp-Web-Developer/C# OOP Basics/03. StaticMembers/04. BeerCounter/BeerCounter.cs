public class BeerCounter
{
    private static int beerInStock;
    private static int beersDrankCount;

    static BeerCounter()
    {
        beerInStock = 0;
        beersDrankCount = 0;
    }

    public static int BeerInStock
    {
        get { return beerInStock; }
    }

    public static int BeersDrankCount
    {
        get { return beersDrankCount; }
    }

    public static void BuyBeer(int bottlesCount)
    {
        beerInStock += bottlesCount;
    }

    public static void DrinkBeer(int bottlesCount)
    {
        beersDrankCount += bottlesCount;
        beerInStock -= bottlesCount;
    }
}