using System;

//program is working, but Judge gives 0/100 I don't know why
public class RecursiveFibonacci
{
    private static long[] memo;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        memo = new long[n + 1];
        Console.WriteLine((RecursiveFibonacciWithMemoization(n)));
    }

    // Recursive fibonacci without DP
    //private static long RecursiveFibonaccimethod(int n)
    //{
    //    if (n <= 1)
    //    {
    //        return 1;
    //    }

    //    return RecursiveFibonaccimethod(n - 1) + RecursiveFibonaccimethod(n - 2);
    //}

    // Top down DP: recursion + memoization
    private static long RecursiveFibonacciWithMemoization(int n)
    {
        if (n <= 1)
        {
            return 1;
        }

        if (memo[n] != 0)
        {
            return memo[n];
        }

        memo[n] =
                RecursiveFibonacciWithMemoization(n - 1) +
                        RecursiveFibonacciWithMemoization(n - 2);
        return memo[n];
    }

    // Bottom up DP
    //private static long FibonacciWithBottomUpDP(int n)
    //{
    //    long[] fibonacciNumbers = new long[n + 1];

    //    fibonacciNumbers[0] = 1;
    //    fibonacciNumbers[1] = 1;
    //    for (int i = 2; i <= n; i++)
    //    {
    //        fibonacciNumbers[i] =
    //                fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
    //    }

    //    return fibonacciNumbers[n];
    //}
}

/*
public class RecursiveFibonacci
{

    private static long[] fibNumbers = new long[100];

    public static void Main()
    {
        fibNumbers = fibNumbers.Select(x => x = -1).ToArray();

        var n = int.Parse(Console.ReadLine());

        Console.WriteLine(GetFibonnaciNum(n));
    }

    public static long GetFibonnaciNum(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        if (fibNumbers[n] != -1)
        {
            return fibNumbers[n];
        }

        fibNumbers[n] = GetFibonnaciNum(n - 1) + GetFibonnaciNum(n - 2);
        return fibNumbers[n];
    }
}
*/