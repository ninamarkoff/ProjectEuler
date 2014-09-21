namespace _14.LongestCollatzSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestCollatzSequence
    {
        public static void Main()
        {
            List<ulong> terms = new List<ulong>();
            terms.Add(0);
            terms.Add(0);
            for (ulong i = 2; i < 1000000; i++)
            {
                ulong number = i;
                ulong counter = 1;
                while (number != 1)
                {
                    if (number <= (ulong)(terms.Count - 1))
                    {
                        counter = counter + terms[(int)number] - 1;
                        number = 1;
                    }
                    else if (number % 2 == 0)
                    {
                        number /= 2;
                        counter++;
                    }
                    else if (number % 2 == 1)
                    {
                        number = 3 * number + 1;
                        counter++;
                    }
                }
                terms.Add(counter);
            }
            int result = terms.IndexOf(terms.Max());
            Console.WriteLine(result);
        }
    }
}

