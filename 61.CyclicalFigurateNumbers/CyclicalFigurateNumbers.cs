namespace CyclicalFigurateNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class CyclicalFigurateNumbers
    {
        private static int GetTriangle(int number)
        {
            return (number * (number + 1)) / 2;
        }

        private static int GetSquare(int number)
        {
            return number * number;
        }

        private static int GetPentagonal(int number)
        {
            return number * (3 * number - 1) / 2;
        }

        private static int GetHexagonal(int number)
        {
            return number * (2 * number - 1);
        }

        private static int GetHeptagonal(int number)
        {
            return number * (5 * number - 3) / 2;
        }

        private static int GetOctagonal(int number)
        {
            return number * (3 * number - 2);
        }

        private static int GetFirstPart(int number)
        {
            return number / 100;
        }

        private static int GetLastPart(int number)
        {
            return number % 100;
        }

        private static int NextNumber(List<List<int>> groupes, List<int> solution, bool[] allowedGroups, bool[][] allowedNumbers)
        {
            var currentNumber = solution.Last();
            for (int i = 0; i < 5; i++)
            {
                if (allowedGroups[i])
                {
                    var possibleNext = groupes[i].Where(p => GetFirstPart(p) == GetLastPart(currentNumber)).ToList();
                    for (int j = 0; j < possibleNext.Count(); j++)
                    {
                        var index = groupes[i].IndexOf(possibleNext[j]);
                        if (allowedNumbers[i][index])
                        {
                            allowedGroups[i] = false;
                            allowedNumbers[i][index] = false;
                            return possibleNext[j];
                        }
                    }
                }
            }

            return -1;
        }

        private static void MakeSelectable(bool[][] canBeSelected)
        {
            for (int k = 0; k < 5; k++)
            {
                for (int j = 0; j < canBeSelected[k].Length; j++)
                {
                    canBeSelected[k][j] = true;
                }
            }
        }

        public static void Main()
        {
            var dtNow = DateTime.Now;
            var triangles = new List<int>();
            var squares = new List<int>();
            var pentagonals = new List<int>();
            var hexagonals = new List<int>();
            var heptagonals = new List<int>();
            var octagonals = new List<int>();

            var currentValue = 0;
            for (int i = 1; i < 141; i++)
            {
                currentValue = GetTriangle(i);
                if (currentValue > 999 && currentValue < 10000 && currentValue % 100 > 9)
                {
                    triangles.Add(GetTriangle(i));
                }

                currentValue = GetSquare(i);
                if (currentValue > 999 && currentValue < 10000 && currentValue % 100 > 9)
                {
                    squares.Add(GetSquare(i));
                }

                currentValue = GetPentagonal(i);
                if (currentValue > 999 && currentValue < 10000 && currentValue % 100 > 9)
                {
                    pentagonals.Add(GetPentagonal(i));
                }

                currentValue = GetHexagonal(i);
                if (currentValue > 999 && currentValue < 10000 && currentValue % 100 > 9)
                {
                    hexagonals.Add(GetHexagonal(i));
                }

                currentValue = GetHeptagonal(i);
                if (currentValue > 999 && currentValue < 10000 && currentValue % 100 > 9)
                {
                    heptagonals.Add(GetHeptagonal(i));
                }

                currentValue = GetOctagonal(i);
                if (currentValue > 999 && currentValue < 10000 && currentValue % 100 > 9)
                {
                    octagonals.Add(GetOctagonal(i));
                }
            }

            var groupes = new List<List<int>>();
            groupes.Add(triangles);
            groupes.Add(squares);
            groupes.Add(pentagonals);
            groupes.Add(hexagonals);
            groupes.Add(heptagonals);
            groupes.Add(octagonals);

            var allowedGroups = new bool[] { true, true, true, true, true, true };
            var allowedNumbers = new bool[6][];
            for (int i = 0; i < 6; i++)
            {
                allowedNumbers[i] = new bool[groupes[i].Count];
                for (int j = 0; j < allowedNumbers[i].Length; j++)
                {
                    allowedNumbers[i][j] = true;
                }
                groupes.Add(groupes[i]);
            }

            bool isFound = false;
            for (int i = 0; i < groupes[5].Count; i++)
            {
                if (!isFound)
                {
                    var solution = new List<int>();
                    solution.Add(groupes[5][i]);
                    allowedGroups = new bool[] { true, true, true, true, true, true };

                    MakeSelectable(allowedNumbers);
                    allowedGroups[5] = false;
                    allowedNumbers[5][i] = false;
                    var nextNum = NextNumber(groupes, solution, allowedGroups, allowedNumbers);
                    while (solution.Count < 7)
                    {
                        if (nextNum > 0)
                        {
                            solution.Add(nextNum);
                            if (solution.Count == 6 && (GetLastPart(solution[5]) == GetFirstPart(solution[0])))
                            {
                                var str = String.Join(", ", solution);
                                Console.WriteLine(str + ", Sum = " + solution.Sum());
                                Console.WriteLine();
                                isFound = true;
                                Console.WriteLine(DateTime.Now - dtNow);
                                break;
                            }
                            nextNum = NextNumber(groupes, solution, allowedGroups, allowedNumbers);
                        }
                        else if (solution.Count > 1)
                        {
                            int counter = 0;
                            while (counter < 5)
                            {
                                if (groupes[counter].Contains(solution[solution.Count - 1]))
                                {
                                    allowedGroups[counter] = true;
                                    break;
                                }
                                counter++;
                            }

                            solution.RemoveAt(solution.Count - 1);
                            var str = String.Join(", ", solution);
                            Console.WriteLine(str);
                            nextNum = NextNumber(groupes, solution, allowedGroups, allowedNumbers);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}