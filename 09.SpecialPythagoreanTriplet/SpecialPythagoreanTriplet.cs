namespace _09.SpecialPythagoreanTriplet
{
    using System;

    public class SpecialPythagoreanTriplet
    {
        public static void Main()
        {
            var p = DateTime.Now;
            bool isFound = false;
            int a = 333, b = a + 1; //Consider a<b<c => 3a < 1000 => a < 334
            while (a > 0 && !isFound)
            {
                while (b < 999 - a)
                {
                    if (1000 * (a + b) - a * b == 500000)
                    {
                        Console.WriteLine(a * b * (1000 - a - b));
                        Console.WriteLine("a={0}, b={1}, c={2}", a, b, 1000 - a - b);
                        isFound = true;
                        break;
                    }
                    b++;
                }
                a--;
                b = a + 1;
            }
            Console.WriteLine(DateTime.Now - p);
        }
    }
}
