namespace _03.LargestPrimeFactor
{
    using System;
    using System.Collections.Generic;

    public class LargestPrimeFactor
    {
        public static List<int> PrimeNumbersUpToSqrt(long number)
        {
            long limitOfPrimes = (long)(Math.Truncate(Math.Sqrt(number)));
            List<int> listOfPrimes = new List<int>();
            bool[] primes = new bool[limitOfPrimes];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i < (long)(Math.Truncate(Math.Sqrt(limitOfPrimes))) + 1; i++)
            {
                if (primes[i])
                {
                    for (int j = i * i; j < limitOfPrimes; j += i)
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
            const long NUMBER = 600851475143;
            List<int> listOfPrimes = PrimeNumbersUpToSqrt(NUMBER);

            for (int i = listOfPrimes.Count - 1; i >= 0; i--)
            {
                if(NUMBER % listOfPrimes[i] == 0)
                {
                    Console.WriteLine(listOfPrimes[i]);
                    break;
                }
            }
        }
    }
}
