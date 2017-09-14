public class Number
{
    private int currentNumber;
    private bool prime;

    public Number(int currentNumber, bool prime)
    {
        this.CurrentNumber = currentNumber;
        this.Prime = prime;
    }

    public bool Prime
    {
        get { return PrimeOrNot(currentNumber); }
        set { prime = value; }
    }

    public int CurrentNumber
    {
        get { return currentNumber; }
        set { currentNumber = value; }
    }

    public int NextPrimeNumber()
    {
        int nextPrime = currentNumber + 1;

        while (PrimeOrNot(nextPrime) != true)
        {
            nextPrime++;
        }
        return nextPrime;
    }

    public bool PrimeOrNot(int num)
    {
        for (int i = 2; i < num; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }
}