namespace PrimePairSets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class PrimePairSets
    {
        /* Problem 60
         * The primes 3, 7, 109, and 673, are quite remarkable. By taking any two primes and concatenating them 
         * in any order the result will always be prime. For example, taking 7 and 109, both 7109 and 1097 are prime.
         * The sum of these four primes, 792, represents the lowest sum for a set of four primes with this property.
         * Find the lowest sum for a set of five primes for which any two primes concatenate to produce another prime.
         */

        const int KnownPrimesLimit = 100000000;
        const int PrimeLimit = 10000;

        private static HashSet<int> PrimeNumbersUpTo(long number)
        {
            HashSet<int> primes = new HashSet<int>();
            bool[] primesArray = new bool[number];
            for (int i = 0; i < primesArray.Length; i++)
            {
                primesArray[i] = true;
            }

            for (int i = 2; i < (long)(Math.Truncate(Math.Sqrt(number))) + 1; i++)
            {
                if (primesArray[i])
                {
                    for (int j = i * i; j < number; j += i)
                    {
                        primesArray[j] = false;
                    }
                }
            }
            //2 won't satisfy the conditions for concatenating two primes, so we begin from 3
            for (int i = 3; i < primesArray.Length; i++)
            {
                if (primesArray[i])
                {
                    primes.Add(i);
                }

            }

            return primes;
        }

        private static bool IsPrime(int number, HashSet<int>  primesUnder10000000)
        {
            if (primesUnder10000000.Contains(number))
            {
                return true;
            }
            return false;
        }

        private static bool IsConcatenatedPrime(int first, int second, HashSet<int> primesUnder10000000)
        {
            string concatenatedString = first.ToString() + second;
            int concatenated = int.Parse(concatenatedString);
            string concatenatedStringReversed = second.ToString() + first;
            int concatenatedReversed = int.Parse(concatenatedStringReversed);

            if (IsPrime(concatenated, primesUnder10000000) && IsPrime(concatenatedReversed, primesUnder10000000))
            {
                return true;
            }
            return false;
        }

        public static List<List<int>> FindPairSets(List<List<int>> sets, HashSet<int> primesUnder100000000, int primesInSet)
        {
            var newSets = new List<List<int>>();
            for (int i = 0; i < sets.Count; i++)
            {
                for (int j = primesInSet - 2; j < sets[i].Count - 1; j++)
                {
                    var list = new List<int>();
                    for (int k = 0; k < primesInSet - 2; k++)
                    {
                        list.Add(sets[i][k]);
                    }
                    list.Add(sets[i][j]);
                    
                    for (int k = j + 1; k < sets[i].Count; k++)
                    {
                        if (IsConcatenatedPrime(sets[i][j], sets[i][k], primesUnder100000000))
                        {
                            list.Add(sets[i][k]);
                        }
                    }
                    if (list.Count > 4)
                    {
                        newSets.Add(list);
                    }
                }
            }

            return newSets;
        }


        public static void Main()
        {
            //Assumed that all 5 numbers are < 10000
            var primesUnderHundredMills = PrimeNumbersUpTo(KnownPrimesLimit);
            var couples = FindPairSets(new List<List<int>> { primesUnderHundredMills.Where(p => p < PrimeLimit).ToList() }, primesUnderHundredMills, 2);
            var triples = FindPairSets(couples, primesUnderHundredMills, 3);
            var quartets = FindPairSets(triples, primesUnderHundredMills, 4);
            var quintets = FindPairSets(quartets, primesUnderHundredMills, 5);

            var minSum = 5 * PrimeLimit;
            var index = 0;
            for (int i = 0; i < quintets.Count; i++)
            {
                if (quintets[i].Sum() < minSum)
                {
                    minSum = quintets[i].Sum();
                    index = i;
                }
            }

            Console.WriteLine((String.Join(", ", quintets[index])) + "; Sum = " + quintets[index].Sum());
            Console.ReadKey();
        }
    }
}