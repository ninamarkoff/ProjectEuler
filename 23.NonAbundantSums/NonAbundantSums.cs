namespace _23.NonAbundantSums
{
    using System;
    using System.Collections.Generic;

    public class NonAbundantSums
    {
        public static int DivisorsSum(int number)
        {
            int result = 0;
            for (int i = 1; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    result += i;
                }
            }

            return result;
        }
        public static void Main()
        {
            const int N = 28123;
            List<int> abundantNumbers = new List<int>();
            for (int i = 1; i <= N; i++)
            {
                if (DivisorsSum(i) > i)
                {
                    abundantNumbers.Add(i);
                }
            }

            bool[] isAbundantSum = new bool[N + 1];

            for (int i = 0; i < abundantNumbers.Count; i++)
            {
                for (int j = i; j < abundantNumbers.Count; j++)
                {
                    if (abundantNumbers[i] + abundantNumbers[j] <= N)
                    {
                        isAbundantSum[abundantNumbers[i] + abundantNumbers[j]] = true;
                    }
                }
            }

            int sum = 0;

            for (int i = 0; i < N; i++)
            {
                if (!isAbundantSum[i])
                {
                    sum += i;
                }
            }
            Console.WriteLine(DivisorsSum(sum));
        }
    }
}