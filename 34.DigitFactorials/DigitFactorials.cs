namespace _34.DigitFactorials
{
    using System;
    using System.Collections.Generic;

    public class DigitFactorials
    {
        public static int SumOfFactorialDigits(Dictionary<int,int> factorials, int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += factorials[number % 10];
                number /= 10;
            }
            return sum;
        }

        public static void Main()
        {
            Dictionary<int, int> factorials = new Dictionary<int, int>();
            factorials.Add(0, 1);
            factorials.Add(1, 1);
            factorials.Add(2,2);
            factorials.Add(3,6);
            factorials.Add(4,24);
            factorials.Add(5,120);
            factorials.Add(6,720);
            factorials.Add(7,5040);
            factorials.Add(8,40320);
            factorials.Add(9,362880);

            long sum = 0;
            for (int i = 10; i < 2540160; i++)
            {
                if(SumOfFactorialDigits(factorials, i) == i)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}