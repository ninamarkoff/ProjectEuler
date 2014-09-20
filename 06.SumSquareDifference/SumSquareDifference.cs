namespace _06.SumSquareDifference
{
    using System;

    public class SumSquareDifference
    {
        public static void Main()
        {
            const int N = 100;
            ulong sumOfTheSquares = N * (N + 1) * (2 * N + 1) / 6;
            ulong squareOfTheSum = (N * (N + 1) / 2) * (N * (N + 1) / 2);
            Console.WriteLine(squareOfTheSum - sumOfTheSquares);
        }
    }
}
