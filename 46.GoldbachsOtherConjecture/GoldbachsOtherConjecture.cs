namespace _46.GoldbachsOtherConjecture
{
    using System;

    public class GoldbachsOtherConjecture
    {
        public static bool IsSquare(int number)
        {
            double comparisonNumber = Math.Sqrt(number);
            return comparisonNumber == (int)comparisonNumber;
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
            primes[1] = false;
            return primes;
        }

        public static void Main()
        {
            var primes = PrimeNumbersUpTo(1000000);
            bool isFound = false;
            int nonPrimeIndex = 9;
            int answer = 0;
            while (!isFound)
            {
                int primeIndex = nonPrimeIndex - 1;
                if (!primes[nonPrimeIndex])
                {
                    while (primeIndex > 0)
                    {
                        if (primes[primeIndex])
                        {
                            if (IsSquare((nonPrimeIndex - primeIndex) / 2))
                            {
                                isFound = true;
                                break;
                            }
                        }
                        primeIndex--;
                    }

                }

                if (!isFound && (primeIndex + 1) != nonPrimeIndex)
                {
                    answer = nonPrimeIndex;
                    break;
                }
                nonPrimeIndex += 2;
                isFound = false;
            }
            Console.WriteLine(answer);
        }
    }
}