namespace _29.DistinctPowers
{
    using System;

    public class DistinctPowers
    {
        public static int FindDistincts(int upperLimit, int maxPower)
        {
            int[] distincts = new int[upperLimit * maxPower + 1];
            for (int i = 0; i < distincts.Length; i++)
            {
                distincts[i] = 0;
            }
            
            for (int i = 1; i <= maxPower; i++)
            {
                for (int j = 2 * i; j <= upperLimit * i; j += i)
                {
                    distincts[j]++;
                }
            }
            int count = 0;
            for (int i = 0; i < distincts.Length; i++)
            {
                if (distincts[i] != 0)
                {
                    count++;
                }
            }
            return count;
        }
        
        public static void Main()
        {
            // A bit of Maths:
            // 81 of 99 numbers with 99 distinct powers.
            // 18 numbers - 2,3,4,5,6,7,8,9,10,16,25,27,32,36,49,64,81,100 with duplicate powers
           
            int sum = 0;
            sum += 81 * 99 + FindDistincts(100,6) + FindDistincts(100,4) + 4 * FindDistincts(100,2);
            Console.WriteLine(sum);
        }
    }
}