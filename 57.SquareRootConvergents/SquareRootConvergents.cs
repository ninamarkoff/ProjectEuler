namespace _57.SquareRootConvergents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class SquareRootConvergents
    {
        public static void Main()
        {
            const int limit = 1000;
            int count = 0;
            BigInteger[] numbers = new BigInteger[2];
            numbers[0] = 17;
            numbers[1] = 12;
            for (int j = 3; j < limit; j++)
            {
                BigInteger nom = numbers[0] + 2 * numbers[1];
                numbers[1] += numbers[0];
                numbers[0] = nom;
                if((int)BigInteger.Log10(numbers[0]) > (int)BigInteger.Log10(numbers[1]))
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}