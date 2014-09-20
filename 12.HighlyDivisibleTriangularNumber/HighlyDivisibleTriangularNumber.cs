namespace _12.HighlyDivisibleTriangularNumber
{
    using System;

    public class HighlyDivisibleTriangularNumber
    {
        public static long TriangularNumber(int number)
        {
            return number * (number + 1) / 2;
        }

        public static int DivisorsCount(long number)
        {
            int result = 0;
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    result++;
                }
            }
            if(number % Math.Sqrt(number) == 0)
            {
                return result * 2 - 1;
            }
            return result * 2;
        }

        public static void Main()
        {
            int number = 1;
            while (DivisorsCount(TriangularNumber(number)) <= 500)
            {
                number++;
            }
            Console.WriteLine(TriangularNumber(number));
        }
    }
}
