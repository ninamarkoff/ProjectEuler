namespace _21.AmicableNumbers
{
    using System;

    public class AmicableNumbers
    {
        public static int SumOfProperDivisors(int number)
        {
            int sum = 0;
            for (int i = 1; i <= number/2; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        public static void Main()
        {
            int sumOfNumbers = 0;
            for (int i = 1; i < 10000; i++)
            {
                if(SumOfProperDivisors(SumOfProperDivisors(i)) == i && i != SumOfProperDivisors(i))
                {
                        sumOfNumbers += i;
                }
            }
           
            Console.WriteLine(sumOfNumbers);
        }
    }
}