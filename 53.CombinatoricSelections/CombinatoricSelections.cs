namespace _53.CombinatoricSelections
{
    using System;

    public class CombinatoricSelections
    {
        public static bool IsCombinationGreaterThan1Million(int n, int k)
        {
            const int limit = 1000000;
            long nominator = 1;
            long denominator = 1;
            for (int i = 0; i < k; i++)
            {
                nominator *= (long)(n - i);
                denominator *= (long)(k - i);
            }
            return (nominator / denominator > limit);
        }

        public static void Main()
        {
            int counter = 0;
            for (int i = 23; i < 101; i++)
            {
                int j = 1;
                while (j <= i /2)
                {
                    if(IsCombinationGreaterThan1Million(i, j))
                    {
                        counter += (i / 2 - j + 1) * 2 + i % 2 - 1;
                        break;
                    }
                    j++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}