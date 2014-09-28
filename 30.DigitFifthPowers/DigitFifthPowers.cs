namespace _30.DigitFifthPowers
{
    using System;

    public class DigitFifthPowers
    {
        public static int FifthPower(int number)
        {
            return number * number * number * number * number;
        }

        public static int SumOfDigitsToThe5ThPower(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += FifthPower(number % 10);
                number /= 10;
            }
            return sum;
        }

        public static void Main()
        {
            //The biggest number, that can be written with K digits and K * 9^5 is K digited, is 354294.
            //Bigger numbers than 354294 cannot be reached as a sum of 
            //it's digits to the fifth power, even if they are are nines

            int sum = 0;

            for (int i = 2; i < 354295; i++)
            {
                if(SumOfDigitsToThe5ThPower(i) == i)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
        }
    }
}