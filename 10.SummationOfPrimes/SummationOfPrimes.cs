namespace _10.SummationOfPrimes
{
    using System;
    using System.Collections.Generic;

    public class SummationOfPrimes
    {
        public static List<int> PrimeNumbersUpTo(long number)
        {
            List<int> listOfPrimes = new List<int>();
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

            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i])
                {
                    listOfPrimes.Add(i);
                }
            }

            return listOfPrimes;
        }
        public static void Main()
        {
            long sum = 0;
            foreach (var p in PrimeNumbersUpTo(2000000))
            {
                sum += p;
            }
            Console.WriteLine(sum);
        }
    }
}
