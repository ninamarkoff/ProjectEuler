namespace _51.PrimeDigitReplacements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PrimeDigitReplacements
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

        public static bool Has3EqualDigits(int number) // We don't count the last digit, it cannot be replaed with 7 other variants
        {
            int[] digitsCount = new int[10];
            number /= 10;
            while (number > 0)
            {
                digitsCount[number % 10]++;
                number /= 10;
            }
            if (digitsCount.Any(p => p > 2))
            {
                return true;
            }

            return false;
        }

        public static bool IsProperDifference(int number1, int number2)
        {
            if (number1 % 10 != number2 % 10)
            {
                return false;
            }
            if(number1.ToString().Length != number2.ToString().Length)
            {
                return false;
            }
            int counterDifferents = 0;
            int[] num1 = new int[6];
            int[] num2 = new int[6];
            bool isFound = false;
            int num1DiffDigit = 0;
            int num2DiffDigit = 0;
            for (int i = 0; i < 6; i++)
            {
                num1[i] = number1 % 10;
                num2[i] = number2 % 10;
                number1 /= 10;
                number2 /= 10;
               
                if(!isFound && num1[i] != num2[i])
                {
                    num1DiffDigit = num1[i];
                    num2DiffDigit = num2[i];
                    isFound = true;
                    counterDifferents++;
                }
                else if(isFound && num1[i] != num2[i])
                {
                    if(num1[i] == num1DiffDigit && num2[i] == num2DiffDigit)
                    {
                        counterDifferents++;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return (counterDifferents == 3);
        }

        public static void Main()
        {
            var primesWithEqualDigits = PrimeNumbersUpTo(1000000).Where(p => p > 9999).Where(q => Has3EqualDigits(q)).ToArray();
            for (int j = 0; j < primesWithEqualDigits.Length - 1; j++)
            {
                List<int> answers = new List<int>();
                answers.Add(primesWithEqualDigits[j]);
                for (int k = j + 1; k < primesWithEqualDigits.Length; k++)
                {
                    bool isOk = true;
                    for (int i = 0; i < answers.Count; i++)
                    {
                        if (!IsProperDifference(answers[i], primesWithEqualDigits[k]))
                        {
                            isOk = false;
                            break;
                        }
                    }
                    if(isOk)
                    {
                        answers.Add(primesWithEqualDigits[k]);
                    }
                }
                if (answers.Count > 7)
                {
                    Console.WriteLine(answers[0]);
                    break;
                }
            }
        }
    }
}