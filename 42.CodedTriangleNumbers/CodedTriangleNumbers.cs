namespace _42.CodedTriangleNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class CodedTriangleNumbers
    {
        public static Dictionary<int, int> GetTriangleNumbersUpTo(int number)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 1; i <= number; i++)
            {
                result.Add((i * (i+1)) / 2, i);
            }
            return result;
        }
        public static void Main()
        {
            var p = GetTriangleNumbersUpTo(100);
            string text = string.Empty;
            using (StreamReader sr = new StreamReader(@"..\..\p042_words.txt"))
            {
                text = sr.ReadToEnd();
            }
            string[] words = text.Split(',');
            Dictionary<char, int> letterValues = new Dictionary<char, int>();
            for (int i = 0; i < 26; i++)
            {
                letterValues.Add((char)('A' + i), 'A' + i - 64);
            }
            int counter = 0;
            for (int i = 0; i < words.Length; i++)
            {
                int sum = 0;
                for (int j = 1; j < words[i].Length - 1; j++)
                {
                    sum += letterValues[words[i][j]];
                }
                if(p.ContainsKey(sum))
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}