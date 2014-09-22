namespace _20.FactorialDigitSum
{
    using System;
    using System.Numerics;

    public class FactorialDigitSum
    {
        public static void Main()
        {
            const int N = 100;
            int counter = N;
            BigInteger factorial = new BigInteger(1);

            while (counter > 1)
            {
                factorial *= counter;
                counter--;
            }

            BigInteger sum = 0;

            while (factorial > 0)
            {
                sum += factorial % 10;
                factorial /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
