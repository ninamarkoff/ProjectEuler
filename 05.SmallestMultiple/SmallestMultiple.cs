namespace _05.SmallestMultiple
{
    using System;
    using System.Numerics;

    public class SmallestMultiple
    {
        public static void Main()
        {
           
            BigInteger lcm = 1;
            const int N = 20;
            for (BigInteger i = 2; i < N + 1; i++)
            {
                lcm = (lcm * i) / BigInteger.GreatestCommonDivisor(lcm, i);
            }
            Console.WriteLine(lcm);
        }
    }
}
