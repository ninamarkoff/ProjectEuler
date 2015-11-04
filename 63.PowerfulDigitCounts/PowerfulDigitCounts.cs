namespace PowerfulDigitCounts
{
    using System;
    using System.Linq;
    using System.Numerics;
    public class PowerfulDigitCounts
    {
        private static BigInteger ToThePowerOfN(BigInteger number, int N)
        {
            if (N == 0)
            {
                return 1;
            }

            BigInteger result = 1;

            for (int i = 0; i < N; i++)
            {
                result *= number;
            }

            return result;
        }

        private static int CountOfDigits(BigInteger number)
        {
            return number.ToString().Count();
        }

        public static void Main()
        {
            var dtNow = DateTime.Now;
            var count = 0;

            for (int i = 1; i < 10; i++)
            {
                var power = 1;
                while (i >= ToThePowerOfN(10 / i, power - 1) && CountOfDigits(ToThePowerOfN(i, power)) >= power)
                {
                    if (CountOfDigits(ToThePowerOfN(i, power)) == power)
                    {
                        count++;
                    }
                    power++;
                }
            }
            Console.WriteLine("Answer: " + count);
            Console.WriteLine(DateTime.Now - dtNow);
        }
    }
}