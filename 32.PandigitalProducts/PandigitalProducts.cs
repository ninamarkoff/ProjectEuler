namespace _32.PandigitalProducts
{
    using System;
    using System.Collections.Generic;

    public class PandigitalProducts
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

        public static bool IsPandigital(int number)
        {
            Dictionary<int, int> digits = new Dictionary<int, int>();

            while (number > 0 && !digits.ContainsKey(number % 10) && number % 10 != 0)
            {
                digits.Add(number % 10, number % 10);
                number /= 10;
            }
            if (number > 0)
            {
                return false;
            }
            return true;
        }

        public static bool IsPandigital9(int number)
        {
            if (IsPandigital(number) && number > 123456789)
            {
                return true;
            }
            return false;
        }

        public static List<int> Divisors(int number)
        {
            List<int> result = new List<int>();
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        public static void Main()
        {
            int sum = 0;
            bool[] primes = PrimeNumbersUpTo(9877);
            Dictionary<int, int> nonPrimeAndPandigital = new Dictionary<int, int>();
            for (int i = 1; i <= 9876; i++)
            {
                if (IsPandigital(i) && !primes[i])
                {
                    nonPrimeAndPandigital.Add(i, i);
                }
            }

            for (int i = 1234; i < 9877; i++)
            {
                if (nonPrimeAndPandigital.ContainsKey(i))
                {
                    for (int j = 0; j < Divisors(i).Count; j++)
                    {
                        if (IsPandigital9(int.Parse(i.ToString() + Divisors(i)[j].ToString() + (i / Divisors(i)[j]).ToString())))
                        {
                            sum += i;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}