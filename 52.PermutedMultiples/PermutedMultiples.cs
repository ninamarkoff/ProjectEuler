namespace _52.PermutedMultiples
{
    using System;

    public class PermutedMultiples
    {
        public static bool IsPermutedMultiple(int number)
        {
            for (int i = 0; i < 10; i++)
            {
                int counter = 0;
                for (int j = 1; j < 7; j++)
                {
                    counter ^= Digits(number * j)[i];
                }
                if(counter != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static int[] Digits(int number)
        {
           int[] digits = new int[10];
            while (number > 0)
            {
                digits[number % 10]++;
                number /= 10;
            }
            return digits;
        }

        public static void Main()
        {
            bool isFound = false;
            int number = 10;
            int len = number.ToString().Length;
            while (!isFound)
            {
                while (number < Math.Pow(10, len) / 6)
                {
                    //Console.WriteLine(number);
                    if(IsPermutedMultiple(number))
                    {
                        isFound = true;
                        Console.WriteLine("This is it: {0}", number);
                        break;
                    }
                    number++;
                }
                number = (int)Math.Pow(10, len);
                len++;
            }
        }
    }
}