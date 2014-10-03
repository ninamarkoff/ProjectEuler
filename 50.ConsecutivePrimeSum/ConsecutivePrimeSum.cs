namespace _50.ConsecutivePrimeSum
{
    using System;
    using System.Collections.Generic;

    public class ConsecutivePrimeSum
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

        public static int SumOfConsecutivePrimes(List<int> primes, int startIndex, int count)
        {
            int result = 0;
            int ind = startIndex;
            while (ind < startIndex + count && result < 1000000)
            {
                result += primes[ind];
                ind++;
            }
            if(result < 1000000)
            {
                return result;
            }
            return -1;
        }

        public static void Main()
        {
            var primes = PrimeNumbersUpTo(1000000);
            bool isFound = false;
            int maxI = 0;
            int sum = 0;
            for (int i = 0; i < primes.Count; i++)
            {
                if(sum < 1000000)
                {
                    sum += primes[i];
                }
                else
                {
                    maxI = i - 2;
                    break;
                }
            }
            for (int i = maxI; i > 0; i-=2)
            {
                for (int j = 0; j < primes.Count - i + 1; j++)
                {
                    if ((SumOfConsecutivePrimes(primes, j, i) != -1) && primes.Contains(SumOfConsecutivePrimes(primes, j, i)))
                    {
                        Console.WriteLine(SumOfConsecutivePrimes(primes, j, i));
                        isFound = true;
                        break;
                    }
                }
                if(isFound)
                {
                    break;
                }
            }
        }
    }
}