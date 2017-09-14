using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int coins;
    private IList<CoffeeType> coffeesSold;

    public CoffeeMachine()
    {
        this.coffeesSold = new List<CoffeeType>();
    }

    public int Coins
    {
        get { return this.coins; }
        private set { this.coins = value; }
    }

    public void BuyCoffee(string size, string type)
    {
        int coinsNeeded = (int)Enum.Parse(typeof(CoffeePrice), size);

        if (this.Coins >= coinsNeeded)
        {
            this.coffeesSold.Add((CoffeeType)Enum.Parse(typeof(CoffeeType), type));
            this.Coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        this.Coins += (int)Enum.Parse(typeof(Coin), coin);
    }

    public IEnumerable<CoffeeType> CoffeesSold
    {
        get { return this.coffeesSold; }
    }
}