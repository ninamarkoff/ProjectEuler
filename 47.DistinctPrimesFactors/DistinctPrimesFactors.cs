namespace _47.DistinctPrimesFactors
{
    using System;

    public class DistinctPrimesFactors
    {
        public static bool[] PrimeNumbersUpTo(long number)
        {
            bool[] primes = new bool[number];
            for (int i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(number) + 1; i++)
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

        public static bool HasFourDistinctPrimeDivisors(bool[] primes, int number)
        {
            var counter = 0;
            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                if (number % i == 0 && counter < 4)
                {
                    if(primes[i])
                    {
                        counter++;
                    }
                    if(primes[number / i])
                    {
                        counter++;
                    }
                    if (counter > 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static void Main()
        {
            var primes = PrimeNumbersUpTo(1000000);
            int start = 210;
            while (start < 1000000)
            {
                if (HasFourDistinctPrimeDivisors(primes, start) && HasFourDistinctPrimeDivisors(primes, start + 1)
                    && HasFourDistinctPrimeDivisors(primes, start + 2) && HasFourDistinctPrimeDivisors(primes, start + 3))
                {
                    Console.WriteLine(start);
                    break;
                }
                start++;
                while (primes[start] || primes[start + 1] || primes[start + 2] || primes[start + 3])
                {
                    start++;
                }
            }
        }
    }
}