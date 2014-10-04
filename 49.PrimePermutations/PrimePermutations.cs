namespace _49.PrimePermutations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PrimePermutations
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

        public static bool AreSameDigited(int number1, int number2, int number3)
        {
            int[] num1Digits = new int[10];
            int[] num2Digits = new int[10];
            int[] num3Digits = new int[10];

            while (number1 > 0)
            {
                num1Digits[number1 % 10]++;
                num2Digits[number2 % 10]++;
                num3Digits[number3 % 10]++;
                number1 /= 10;
                number2 /= 10;
                number3 /= 10;
            }

            bool result = true;
            for (int i = 0; i < 10; i++)
            {
                if(!(num1Digits[i] == num2Digits[i] && num2Digits[i] == num3Digits[i]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static void Main()
        {
            var primes = PrimeNumbersUpTo(10000);
            List<int> primes4Digits = new List<int>();
            Dictionary<int, int> primes4DigitsDict = new Dictionary<int, int>();
            for (int i = 1009; i < 10000; i++)
            {
                if(primes[i])
                {
                    primes4Digits.Add(i);
                    primes4DigitsDict.Add(i,i);
                }
            }
            List<int> triplePrimes = new List<int>();
            for (int i = 0; i < primes4Digits.Count; i++)
            {
                for (int j = i + 1; j < primes4Digits.Count; j++)
                {
                    if(primes4DigitsDict.ContainsKey(2 * primes4Digits[j] - primes4Digits[i]))
                    {
                        if (AreSameDigited(primes4Digits[i], primes4Digits[j], primes4DigitsDict[2 * primes4Digits[j] - primes4Digits[i]]))
                        {
                            triplePrimes.Add(primes4Digits[i]);
                            triplePrimes.Add(primes4Digits[j]);
                            triplePrimes.Add(primes4DigitsDict[2 * primes4Digits[j] - primes4Digits[i]]);
                        }
                    }
                }
            }
            StringBuilder result = new StringBuilder();
            result.Append(triplePrimes[3]);
            result.Append(triplePrimes[4]);
            result.Append(triplePrimes[5]);

            Console.WriteLine(result.ToString());
        }
    }
}