namespace _41.PandigitalPrime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PandigitalPrime
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

        public static bool IsPandigital(int number)
        {
            int countOfDigits = 0;
            int copyOfNumber = number;
            while (copyOfNumber > 0)
            {
                countOfDigits++;
                copyOfNumber /= 10;
            }
            copyOfNumber = number;
            bool[] digits = new bool[countOfDigits + 1];
            while (copyOfNumber % 10 <= countOfDigits && copyOfNumber % 10 != 0 && !digits[copyOfNumber % 10] && copyOfNumber > 0)
            {
                digits[copyOfNumber % 10] = true;
                copyOfNumber /= 10;
            }
            if(copyOfNumber > 0)
            {
                return false;
            }
           
            return true;
        }

        public static void Main()
        {
            //A bit of maths:
            //Since a pandigital 9-digit number has sum of it's digits 45, it will be divisible by 9,
            //so there is no way it can be prime. Same for a 8-digit numver, sum 36.
            //That leads to a 7-digit number as a largest possibility. (number up to 7 654 321)

            var primes = PrimeNumbersUpTo(7654322);
            int largestPandigital = 0;
            for (int i = 7654321; i > 0; i -= 2)
            {
                if(IsPandigital(i))
                {
                    if(primes[i])
                    {
                        largestPandigital = i;
                        break;
                    }
                }
            }
            Console.WriteLine(largestPandigital);
           
            
        }
    }
}
