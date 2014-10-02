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

        public static long Pentagonal(int number)
        {
            return (number * (3 * number - 1)) / 2;
        }

        public static void Main()
        {
            bool isFound = false;
            int counterI = 2;
            long i = Pentagonal(counterI);
            long D = 0;
            while (!isFound)
            {
                int counterJ = counterI -1;
                long j = i - counterJ * 3 - 1;
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
            Console.WriteLine(D);
        }
    }
}