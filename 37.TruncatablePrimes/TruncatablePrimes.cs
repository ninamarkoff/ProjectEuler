namespace _37.TruncatablePrimes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            var primes = PrimeNumbersUpTo(10000000);
            int start1 = 3;
            int start2 = 7;
            int counter = 0;
            List<int> numbers = new List<int>();
            int[] allowedDigits = { 1, 3, 7, 9 };
            int addedNums = 0;
            int sum = 0;
            List<int> answers = new List<int>();
            while (counter < 11)
            {
                for (int i = 0; i < allowedDigits.Length; i++)
                {
                    if (primes[start1 * 10 + allowedDigits[i]])
                    {
                        numbers.Add(start1 * 10 + allowedDigits[i]);
                        addedNums++;
                        if (i == 1 || i == 2)
                        {
                            int count = numbers[numbers.Count - 1].ToString().Length - 1;
                            while (count > 0 && primes[numbers[numbers.Count - 1] % (int)Math.Pow(10, count)])
                            {
                                count--;
                            }
                            if (count == 0)
                            {
                                counter++;
                                sum += numbers[numbers.Count - 1];
                                answers.Add(numbers[numbers.Count - 1]);
                            }
                        }
                    }
                    if (primes[start2 * 10 + allowedDigits[i]])
                    {
                        numbers.Add(start2 * 10 + allowedDigits[i]);
                        addedNums++;
                        if (i == 1 || i == 2)
                        {
                            int count = numbers[numbers.Count - 1].ToString().Length - 1;
                            while (count > 0 && primes[numbers[numbers.Count - 1] % (int)Math.Pow(10, count)])
                            {
                                count--;
                            }
                            if (count == 0)
                            {
                                counter++;
                                sum += numbers[numbers.Count - 1];
                                answers.Add(numbers[numbers.Count - 1]);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(sum);
            Console.WriteLine(answers);
        }
    }
}
