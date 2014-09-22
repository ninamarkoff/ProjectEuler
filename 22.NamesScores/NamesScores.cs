namespace _22.NamesScores
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class NamesScores
    {
        public static int SumOfLetters(string word)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict['a'] = 1; dict['g'] = 7; dict['m'] = 13; dict['s'] = 19; dict['y'] = 25;
            dict['b'] = 2; dict['h'] = 8; dict['n'] = 14; dict['t'] = 20; dict['z'] = 26;
            dict['c'] = 3; dict['i'] = 9; dict['o'] = 15; dict['u'] = 21;
            dict['d'] = 4; dict['j'] = 10; dict['p'] = 16; dict['v'] = 22;
            dict['e'] = 5; dict['k'] = 11; dict['q'] = 17; dict['w'] = 23;
            dict['f'] = 6; dict['l'] = 12; dict['r'] = 18; dict['x'] = 24;

            int sum = 0;
            for (int i = 1; i < word.Length - 1; i++)
            {
                sum += dict[word.ToLower()[i]];
            }

            return sum;
        }

        public static void Main()
        {
            string text = System.IO.File.ReadAllText(@"..\..\p022_names.txt");
            string[] names = text.Split(',');
            Array.Sort(names);
            BigInteger totalSum = 0;
            for (int i = 0; i < names.Length; i++)
            {
                totalSum += (i + 1) * SumOfLetters(names[i]);
            }

            Console.WriteLine(totalSum);
        }
    }
}
