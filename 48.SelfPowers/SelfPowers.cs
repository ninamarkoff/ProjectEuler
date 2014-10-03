namespace _48.SelfPowers
{
    using System;

    public class SelfPowers
    {
        public static void Main()
        {
            long remainder = 10405071317;
            long mod = 10000000000;
            for (int i = 11; i < 1001; i++)
            {
                long currentRemainder = 1;
                for (int j = 0; j < i; j++)
                {
                    currentRemainder *= (i % mod);
                    currentRemainder %= mod;
                }
                remainder += currentRemainder;
                remainder %= mod;
            }
            Console.WriteLine(remainder);
        }
    }
}