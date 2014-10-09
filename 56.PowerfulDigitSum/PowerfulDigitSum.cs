namespace _56.PowerfulDigitSum
{
    using System;
    using System.Numerics;

    public class PowerfulDigitSum
    {
        public static BigInteger DigitalSum(BigInteger number)
        {
            BigInteger result = 0;
            while (number > 0)
            {
                result += (number % 10);
                number /= 10;
            }
            return result;
        }

        public static int DigitsCount(BigInteger number)
        {
            int result = 0;
            while (number > 0)
            {
                result++;
                number /= 10;
            }
            return result;
        }

        public static void Main()
        {
            BigInteger maxSum = 0;
            BigInteger currentSum = 0;
            for (BigInteger i = 99; i > 1; i--)
            {
                for (int j = 99; j > 0; j--)
                {
                    currentSum = DigitalSum(BigInteger.Pow(i, j));
                    if(currentSum> maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine(maxSum);
        }
    }
}