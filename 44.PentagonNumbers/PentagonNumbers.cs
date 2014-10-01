namespace _44.PentagonNumbers
{
    using System;
    
    public class PentagonNumbers
    {
        public static bool IsPentagonal(long number)
        {
            double comparisonNumber = (1 + Math.Sqrt(number * 24 + 1)) / 6;
            return comparisonNumber == (int)comparisonNumber;

        }

        public static void Main()
        {
            bool isFound = false;
            int i = 5;
            int counterI = 2;
            int D = 0;
            while (!isFound && i < 10000000)
            {
                int counterJ = counterI -1;
                int j = i - counterJ * 3 - 1;
                while (j > 0)
                {
                    if (IsPentagonal(i + j) && IsPentagonal(i - j))
                    {
                        isFound = true;
                        D = i - j;
                        break;
                    }
                    counterJ--;
                    j = j - counterJ * 3 - 1;
                    
                }
                i += counterI * 3 + 1;
                counterI++;
            }
            Console.WriteLine("isFound: {0}, D = {1}", isFound, D);
        }
    }
}
