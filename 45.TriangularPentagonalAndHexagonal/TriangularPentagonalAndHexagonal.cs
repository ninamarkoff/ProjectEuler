namespace _45.TriangularPentagonalAndHexagonal
{
    using System;

    public class TriangularPentagonalAndHexagonal
    {
        public static bool IsPentagonal(long number)
        {
            double comparisonNumber = (1 + Math.Sqrt(number * 24 + 1)) / 6;
            return comparisonNumber == (int)comparisonNumber;
        }

        public static bool IsTriangular(long number)
        {
            double comparisonNumber = (Math.Sqrt(number * 8 + 1) - 1) / 2;
            return comparisonNumber == (int)comparisonNumber;
        }

        public static long Pentagonal(long number)
        {
            return number * (2 * number - 1);
        }

        public static void Main()
        {
            bool isFound = false;
            long counter = 144;
            long i = Pentagonal(counter);
            long result = 0;
            while (!isFound)
            {
                if (IsPentagonal(i) && IsTriangular(i))
                {
                    isFound = true;
                    result = i;
                    Console.WriteLine(result);
                    break;
                }
                i = i + 4 * counter + 1;
                counter++;
            }
        }
    }
}