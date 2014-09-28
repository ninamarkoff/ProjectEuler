namespace _35.CircularPrimes
{
    using System;

    public class CircularPrimes
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

        public static bool IsCircularPrime(bool[] primes, int number)
        {
            string num = number.ToString();
            int count = 0;
            string rotated = num;
            do
            {
                rotated = rotated.Substring(1) + rotated[0].ToString();
                if(primes[int.Parse(rotated)])
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            while (rotated != num);
            if(count == num.Length)
            {
                return true;
            }
            return false;
        }

        public static void Main()
        {
            var primes = PrimeNumbersUpTo(1000000);
            int counter = 13;

            for (int i = 100; i < 1000000; i++)
            {
                if(primes[i])
                {
                    if(IsCircularPrime(primes, i))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}