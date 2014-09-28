namespace _36.DoubleBasePalindromes
{
    using System;
    using System.Collections.Generic;

    public class DoubleBasePalindromes
    {
        public static bool IsPalindrome(int number)
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

        public static bool IsPalindrome(List<int> digits )
        {
            for (int i = 0; i < digits.Count / 2; i++)
            {
                if (digits[i] != digits[digits.Count - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> Base2Reversed(int number)
        {
            List<int> digits = new List<int>();
            do
            {
                digits.Add(number % 2);
                number /= 2;
            }
            while (number != 0);
            return digits;
        }

        public static void Main()
        {
            long sum = 0;
            for (int i = 1; i < 1000000; i++)
            {
                if(IsPalindrome(i) && IsPalindrome(Base2Reversed(i)))
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}