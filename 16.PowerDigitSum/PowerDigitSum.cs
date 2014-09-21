namespace _16.PowerDigitSum
{
    using System;
    using System.Numerics;

    public class PowerDigitSum
    {
        public static void Main()
        {
            BigInteger number = BigInteger.Pow(2, 1000);
            BigInteger sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
