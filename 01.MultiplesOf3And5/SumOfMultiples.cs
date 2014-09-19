namespace _01.MultiplesOf3And5
{
    using System;

    public class SumOfMultiples
    {
        public static bool IsMultipleOf3Or5(int number)
        {
            if(number % 3 == 0 || number % 5 == 0)
            {
                return true;
            }
            return false;
        }

        public static void Main()
        {
            int sum = 0;

            for (int i = 1; i < 1000; i++)
            {
                if(IsMultipleOf3Or5(i))
                {
                    sum += i;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
