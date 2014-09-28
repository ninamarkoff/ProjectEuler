namespace _31.CoinSums
{
    using System;

    public class CoinSums
    {
        public static void Main()
        {
            int count = 0;
            DateTime p = DateTime.Now;

            for (int j = 0; j < 2; j++)
            {
                for (int k = 0; k < 5 - j; k++)
                {
                    for (int l = 0; l < 11 - j - k; l++)
                    {
                        for (int m = 0; m < 21 - j - k - l; m++)
                        {
                            for (int n = 0; n < 41 - j - k - l - m; n++)
                            {
                                for (int o = 0; o < 101 - j - k - l - m - n; o++)
                                {
                                    if (200 - j * 100 - k * 50 - l * 20 - m * 10 - n * 5 - o * 2 >= 0)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count + 2);
            Console.WriteLine(DateTime.Now - p);
        }
    }
}
