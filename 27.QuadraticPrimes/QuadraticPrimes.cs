namespace _27.QuadraticPrimes
{
    using System;

    public class QuadraticPrimes
    {
        public static int QuadraticValue(int n, int a, int b)
        {
            return n * n + a * n + b;
        }

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

        public static void Main()
        {
            bool[] primes = PrimeNumbersUpTo(3000000);
            int max = 0;
            int product = 0;
            for (int i = -999; i < 1000; i++)
            {
                for (int j = -999; j < 1000; j++)
                {
                    int count = 0;
                    int n = 0;
                    while (primes[Math.Abs(QuadraticValue(n, i, j))])
                    {
                        count++;
                        n++;
                    }
                    if(count > max)
                    {
                        max = count;
                        product = i * j;
                    }
                }
            }
            Console.WriteLine(product);
        }
    }
}
