namespace _33.DigitCancelingFractions
{
    using System;
    using System.Numerics;

    public class DigitCancelingFractions
    {
        public static bool[] PrimeNumbersUpTo(long number)
        {
            bool[] primes = new bool[number];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i < (long)(Math.Truncate(Math.Sqrt(number))) + 1; i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j < number; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
            return primes;
        }

        public static bool HasCommonDigit(int number1, int number2)
        {
            string num1 = number1.ToString();
            string num2 = number2.ToString();
            if (num1.Contains("0") || num2.Contains("0"))
            {
                return false;
            }
            else if (num1.Contains(num2[0].ToString()) ^ num1.Contains(num2[1].ToString()))
            {
                return true;
            }
            return false;
        }

        public static int[] DistinctDigitsFraction(int number1, int number2)
        {
            if (HasCommonDigit(number1, number2))
            {
                string num1 = number1.ToString();
                string num2 = number2.ToString();
                if (num1[0] == num2[0] || num1[0] == num2[1])
                {
                    num2 = num2.Remove(num2.IndexOf(num1[0]), 1);
                    num1 = num1[1].ToString();
                }
                else
                {
                    num2 = num2.Remove(num2.IndexOf(num1[1]), 1);
                    num1 = num1[0].ToString();
                }
                return new int[] { int.Parse(num1), int.Parse(num2) };
            }
            return new int[] { -1, -1 };
        }

        public static void Main()
        {
            bool[] primes = PrimeNumbersUpTo(100);
            BigInteger nominator = new BigInteger(1);
            BigInteger denominator = new BigInteger(1);

            for (int i = 12; i < 99; i++)
            {
                for (int j = i + 1; j < 100; j++)
                {
                    if (!primes[j])
                    {
                        if ((decimal)DistinctDigitsFraction(i, j)[0] / DistinctDigitsFraction(i, j)[1] == (decimal)i / j)
                        {
                            nominator *= DistinctDigitsFraction(i, j)[0];
                            denominator *= DistinctDigitsFraction(i, j)[1];
                        }
                    }
                }

            }
            BigInteger result = new BigInteger();
            result = denominator / BigInteger.GreatestCommonDivisor(nominator, denominator);
            Console.WriteLine(result);
        }
    }
}