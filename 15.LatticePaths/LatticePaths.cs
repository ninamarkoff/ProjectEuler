namespace _15.LatticePaths
{
    using System;

    public class LatticePaths
    {
        //Great recursion, but works only for ~15 :-)
        //public static ulong FindPathsDownRight(int i, int j)
        //{
        //    if(i == 0 && j == 0)
        //    {
        //        return 1;
        //    }
        //    else if (i == 0 && j != 0)
        //    {
        //        return FindPathsDownRight(i, j - 1);
        //    }
        //    else if(i != 0 && j == 0)
        //    {
        //        return FindPathsDownRight(i - 1, j);
        //    }
        //    else
        //    {
        //        return FindPathsDownRight(i, j - 1) + FindPathsDownRight(i - 1, j);
        //    }
        //}

        public static void Main()
        {
            const int N = 20;
            long[,] matrix = new long[N + 1, N + 1];
            for (int i = 0; i <= N; i++)
            {
                for (int j = i; j <= N; j++)
                {
                    if(i != 0)
                    {
                        matrix[i, j] = matrix[i, j - 1] + matrix[i - 1, j];
                        matrix[j, i] = matrix[j, i - 1] + matrix[j - 1, i];
                    }
                    else
                    {
                        matrix[i, j] = 1;
                        matrix[j, i] = 1;
                    }
                }
            }
            Console.WriteLine(matrix[20,20]);
        }
    }
}
