namespace _04.LargestPalindromeProduct
{
    using System;

    public class LargestPalindromeProduct
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
        public static void Main()
        {
            const int Palindrome_Upper_Limit = 997799; // First palindrome number, less than 999 * 999 = 998 001
            const int Palindrome_Lower_Limit = 10001; // 100 * 100
            bool isFound = false;
            int i = Palindrome_Upper_Limit;
            while (!isFound && i >= Palindrome_Lower_Limit)
            {
                if (IsPalindrome(i))
                {
                    for (int j = 999; j >= 100; j--)
                    {
                        if (i % j == 0 && i / j >= 100 && i / j <= 999)
                        {
                            Console.WriteLine("The largest palindrome is: {0}, product of {1} * {2}", i, j, i/j);
                            isFound = true;
                            break;
                        }
                    }
                }
                i--;
            }
        }
    }
}
