namespace _25._1000_digitFibonacciNumber
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class OneThousandDigitFibonacciNumber
    {
        public static int DigitsCount(BigInteger number)
        {
            int result = 0;
            while (number > 0)
            {
                number /= (BigInteger)10;
                result++;
            }
            return result;
        }

        public static void Main()
        {
            List<BigInteger> fibonacci = new List<BigInteger>();
            fibonacci.Add((BigInteger)1);
            fibonacci.Add((BigInteger)1);
            int i = 2;
            while (DigitsCount(fibonacci[i-1] + fibonacci[i-2]) < 1000)
            {
                fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
                i++;
            }
            Console.WriteLine(fibonacci.Count + 1);
        }
    }
}

