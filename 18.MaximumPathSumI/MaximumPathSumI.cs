namespace _18.MaximumPathSumI
{
    using System;
    using System.Collections.Generic;

    //Dynamic programming used

    public class MaximumPathSumI
    {
        public static int[][] ReadLineOfNumbers(string[] lines)
        {
            List<string[]> linesStr = new List<string[]>();

            for (int i = 0; i < lines.Length; i++)
            {
                linesStr.Add(lines[i].Split(' '));
            }

            int[][] result = new int[linesStr.Count][];
            for (int i = 0; i < result.Length; i++)
            {
               result[i] = new int[linesStr[i].Length];
                for (int j = 0; j <= i; j++)
                {
                    result[i][j] = int.Parse(linesStr[i][j]);
                }
                    
            }
            return result;
        }

        public static void Main()
        {
            string[] input =
                {
                    "75", "95 64", "17 47 82", "18 35 87 10", "20 04 82 47 65", "19 01 23 75 03 34",
                    "88 02 77 73 07 63 67", "99 65 04 28 06 16 70 92", "41 41 26 56 83 40 80 70 33",
                    "41 48 72 33 47 32 37 16 94 29", "53 71 44 65 25 43 91 52 97 51 14",
                    "70 11 33 28 77 73 17 78 39 68 17 57", "91 71 52 38 17 14 91 43 58 50 27 29 48",
                    "63 66 04 68 89 53 67 30 73 16 69 87 40 31", "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23"
                };

            var matrix = ReadLineOfNumbers(input);

            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    matrix[i - 1][j] += Math.Max(matrix[i][j], matrix[i][j + 1]);
                }
            }

            Console.WriteLine(matrix[0][0]);
        }
    }
}
