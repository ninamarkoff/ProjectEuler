namespace _37.TruncatablePrimes
{
    using System;
    using System.Collections.Generic;

    public class TruncatablePrimes
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

        public static void Main()
        {
            var primes = PrimeNumbersUpTo(1000000);
            int sum = 0;
            List<int> numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(7);
            int lastChildrenCount = 4;
            int currentChildrenCount = 0;
            int counter = 0;
            int[] allowedDigits = {1, 3, 7, 9 };
            List<int> answers = new List<int>();
            while (counter < 11)
            {
                for (int i = numbers.Count - lastChildrenCount - currentChildrenCount; i < numbers.Count - currentChildrenCount ; i++)
                {
                    for (int j = 0; j < allowedDigits.Length; j++)
                    {
                        if(primes[10 * numbers[i] + allowedDigits[j]])
                        {
                            numbers.Add(10 * numbers[i] + allowedDigits[j]);
                            currentChildrenCount++;
                            if(j == 1 || j == 2)
                            {
                                int len = numbers[numbers.Count - 1].ToString().Length - 1;
                                bool isPrime = true;
                                while (len > 0 && isPrime)
                                {
                                    if(primes[int.Parse(numbers[numbers.Count - 1].ToString().Substring(len))])
                                    {
                                        len--;
                                    }
                                    else
                                    {
                                        isPrime = false;
                                    }
                                }
                                if(isPrime)
                                {
                                    counter++;
                                    answers.Add(numbers[numbers.Count - 1]);
                                    sum += numbers[numbers.Count - 1];
                                }
                            }
                        }
                    }
                }
                lastChildrenCount = currentChildrenCount;
                currentChildrenCount = 0;
            }
            Console.WriteLine(sum);
        }
    }
}