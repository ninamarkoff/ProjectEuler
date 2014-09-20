namespace _02.SumOfEvenFibonacciNumbers
{
    using System;
    using System.Collections.Generic;

    public class SumOfEvenFibonacciMembers
    {
        public static void Main()
        {
            const int LIMIT = 4000000;
            int sum = 2;
            int i = 2;
            List<int> fibonacci = new List<int>();
            fibonacci.Add(1);
            fibonacci.Add(2);
            while (fibonacci[i - 1] + fibonacci[i - 2] < LIMIT)
            {
                fibonacci.Add(fibonacci[i - 1] + fibonacci[i - 2]);
                if(fibonacci[i] % 2 == 0)
                {
                    sum += fibonacci[i];
                }
                i++;
            }
            Console.WriteLine(sum);
        }
    }
}
