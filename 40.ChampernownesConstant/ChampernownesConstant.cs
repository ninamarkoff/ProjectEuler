namespace _40.ChampernownesConstant
{
    using System;
    using System.Collections.Generic;

    public class ChampernownesConstant
    {
        public static int DigitD(int index) // for d > 10
        {
            Dictionary<int, int> countOfDigits = new Dictionary<int, int>();
            for (int i = 1; i < 7; i++)
            {
                countOfDigits.Add(i, 9 * i * (int)Math.Pow(10, i - 1));
            }

            int j = 1;
            int countOfPrecedingDigits = countOfDigits[j];
            
            while (countOfPrecedingDigits < index)
            {
                j++;
                countOfPrecedingDigits += countOfDigits[j];
            }
           countOfPrecedingDigits -= countOfDigits[j];

            if((index - countOfPrecedingDigits) % j != 0 )
            {
                return ((index - countOfPrecedingDigits) / j + index / 10) / (int)Math.Pow(10, j - (index - countOfPrecedingDigits) % j) % 10;
            }
            return ((index - countOfPrecedingDigits) / j + index / 10) % 10;
        }
        public static void Main()
        {
            Console.WriteLine(DigitD(100) * DigitD(1000) * DigitD(10000) * DigitD(100000) * DigitD(1000000));
        }
    }
}