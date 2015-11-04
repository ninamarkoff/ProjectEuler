namespace CubicPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class CubicPermutations
    {
        private static BigInteger GetCube(BigInteger number)
        {
            return number * number * number;
        }

        private static string GetCubeHash(BigInteger number)
        {
            var numberAsString = number.ToString();
            return String.Concat(numberAsString.OrderBy(p => p));
        }

        public static void Main()
        {
            var dtNow = DateTime.Now;
            var smallestCubes = new Dictionary<string, int>();
            var counts = new Dictionary<string, int>();
            var results = new List<int>();
            int iterator = 1;

            while (true)
            {
                var hash = GetCubeHash(GetCube(iterator));
                if (results.Count != 0)
                {
                    if (GetCube(iterator).ToString().Count() > GetCube(results.Last()).ToString().Count())
                    {
                        break;
                    }
                }
                if (!smallestCubes.ContainsKey(hash))
                {
                    smallestCubes.Add(hash, iterator);
                    counts.Add(hash, 1);
                }
                else
                {
                    counts[hash]++;
                    if (counts[hash] == 5)
                    {
                        results.Add(smallestCubes[hash]);
                    }
                }
                iterator++;
            }

            
            var result = results.Min();
            Console.WriteLine("The number is: {0}", result);
            Console.WriteLine(DateTime.Now - dtNow);
            Console.WriteLine();
        }
    }
}