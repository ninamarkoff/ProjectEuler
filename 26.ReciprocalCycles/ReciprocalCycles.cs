namespace _26.ReciprocalCycles
{
    using System;
    using System.Collections.Generic;

    public class ReciprocalCycles
    {
        public static int DigitsCount(int number)
        {
            int result = 0;
            while (number > 0)
            {
                number /= 10;
                result++;
            }
            return result;
        }

        private static int LongestRecurrentCycleUpTo(int limit)
        {

            int result = 0;
            int maxRecurrLength = 0;

            for (int i = 2; i < limit; i++)
            {
                int nominator = (int)Math.Pow(10, DigitsCount(i));
                List<int> nominatorsList = new List<int>();
                int recurrLength = 0;
                int currNominator = nominator;
                bool[] nominators = new bool[10 * nominator];
                while (!nominators[currNominator])
                {
                    if (currNominator % i == 0)
                    {
                        recurrLength = 0;
                        break;
                    }
                    recurrLength++;
                    nominatorsList.Add(currNominator);
                    nominators[currNominator] = true;
                    currNominator = (currNominator % i) * 10;
                }
                if (recurrLength != 0)
                {
                    recurrLength -= nominatorsList.IndexOf(currNominator);
                    if (recurrLength > maxRecurrLength)
                    {
                        maxRecurrLength = recurrLength;
                        result = i;
                    }
                }
            }
            return result;
        }

        public static void Main()
        {
            const int LIMIT = 1000;
            var result = LongestRecurrentCycleUpTo(LIMIT);
            Console.WriteLine(result);
        }
    }
}
