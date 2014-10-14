namespace _58.SpiralPrimes
{
    using System;
    using System.Collections.Generic;

    public class SpiralPrimes
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

        public static bool IsPrime(int number, List<int> primes)
        {
            bool isPrime = true;
            int i = 0;
            while (primes[i] < Math.Sqrt(number))
            {
                if (number % primes[i] == 0)
                {
                    isPrime = false;
                    break;
                }
                i++;
            }
            return isPrime;
        }

        public static void Main()
        {
            var primes = PrimeNumbersUpTo(100000);
            int N = 7;
            double ratio = 0.62d;
            int countOfPrimes = 8;
            int upperLeftCorner = 37;
            int upperRightCorner = 31;
            int lowerLeftcorner = 43;
            while (ratio >= 0.1)
            {
                upperLeftCorner += 4 * N;
                upperRightCorner += 4 * N - 2;
                lowerLeftcorner += 4 * N + 2;
                if(IsPrime(upperLeftCorner, primes))
                {
                    countOfPrimes++;
                }
                if (IsPrime(upperRightCorner, primes))
                {
                    countOfPrimes++;
                }
                if (IsPrime(lowerLeftcorner, primes))
                {
                    countOfPrimes++;
                }
                N += 2;
                ratio = (double)countOfPrimes/(2 * N - 1);
            }
            Console.WriteLine(N);
        }
    }
}