namespace _55.LychrelNumbers
{
    using System;
    using System.Linq;
    using System.Numerics;

    public class LychrelNumbers
    {
        public static bool IsPalindrome(BigInteger number)
        {
            string numberAsString = number.ToString();
            for (int i = 0; i < numberAsString.Length / 2; i++)
            {
                if (numberAsString[i] != numberAsString[numberAsString.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static BigInteger Reversed(BigInteger number)
        {
            string numberAsString = number.ToString();
            string reversed = new string(numberAsString.Reverse().ToArray());
            BigInteger result = BigInteger.Parse(reversed);
            return result;
        }

        public static void Main()
        {
            int count = 0;
            const int limit = 10000;
            for (BigInteger i = 1; i < limit; i++)
            {
                int innerLimit = 50;
                int inner = 1;
                BigInteger argument = i + Reversed(i);
                while (inner < innerLimit && !IsPalindrome(argument))
                {
                    inner++;
                    argument += Reversed(argument);
                }
                if(inner == innerLimit)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}