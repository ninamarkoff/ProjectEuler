namespace _28.NumberSpiralDiagonals
{
    using System;

    public class NumberSpiralDiagonals
    {
        public static void WriteMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,8}", matrix[i,j].ToString());
                }
                Console.WriteLine();
            }
        }

        public static long SumOfDiagonals(int[,] matrix)
        {
            long sum = 0;
            int N = matrix.GetLength(0);
            for (int i = 0; i < N; i++)
            {
                sum += matrix[i, i] + matrix[i, N - i - 1];
            }
            return sum - 1;
        }

        public static void Main()
        {
            const int N = 1001;
            int[,] matrix = new int[N, N];
            string direction = "down";
            int row = N / 2;
            int col = N / 2;
            matrix[row, col] = 1;
            col++;
            matrix[row, col] = 2;
            int counter = 2;

            while (true)
            {
                if (direction == "down")
                {
                    while (row != col)
                    {
                        row++;
                        counter++;
                        matrix[row, col] = counter;
                    }
                    direction = "left";
                }

                if (direction == "left")
                {
                    while (col + row > N - 1)
                    {
                        counter++;
                        col--;
                        matrix[row, col] = counter;
                    }
                    direction = "up";
                }

                if (direction == "up")
                {
                    while (row != col)
                    {
                        counter++;
                        row--;
                        matrix[row, col] = counter;
                    }
                    direction = "right";
                }

                if (direction == "right")
                {
                    while (col + row < N && counter != (N * N))
                    {
                        counter++;
                        col++;
                        matrix[row, col] = counter;
                    }
                    if (counter == N * N)
                    {
                        break;
                    }
                    direction = "down";
                }
            }
            Console.WriteLine(SumOfDiagonals(matrix));
        }
    }
}