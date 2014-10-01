namespace _39.IntegerRightTriangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerRightTriangles
    {
        public static void Main()
        {
            var t = DateTime.Now;
            Dictionary<int, int> perimeters = new Dictionary<int, int>();
            for (int i = 12; i < 1001; i += 4)
            {
                for (int j = 3; j < 334; j++)
                {
                    for (int k = j; k < (i - j) / 2; k++)
                    {
                        if ((i - j - k) * (i - j - k) == j * j + k * k)
                        {
                            if (perimeters.ContainsKey(i))
                            {
                                perimeters[i]++;
                            }
                            else
                            {
                                perimeters.Add(i, 1);
                            }
                        }
                    }
                }
            }
            var n = perimeters.Max(p => p.Value);
            var answer = perimeters.First(q => q.Value == n).Key;
            Console.WriteLine(answer);
            Console.WriteLine(DateTime.Now - t);
        }
    }
}