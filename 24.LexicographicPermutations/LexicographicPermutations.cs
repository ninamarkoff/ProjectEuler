namespace _24.LexicographicPermutations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LexicographicPermutations
    {
        public static List<string> Permutation(int n)
        {
            int[] numbers = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                numbers[i] = i;
            }
            List<string> result = new List<string>();
            StringBuilder startValue = new StringBuilder();
            for (int i = 0; i < n + 1; i++)
            {
                startValue.Append(numbers[i]);
            }
            result.Add(startValue.ToString());
            bool isEndReached = false;
            while (!isEndReached)
            {
                int k = n - 1;
                int l = n;
                int swapHelperValue;
                while (k >= 0 && numbers[k] > numbers[k + 1])
                {
                    k--;
                }
                if (k < 0)
                {
                    isEndReached = true;
                    break;
                }
                while (numbers[l] < numbers[k])
                {
                    l--;
                }
                swapHelperValue = numbers[k];
                numbers[k] = numbers[l];
                numbers[l] = swapHelperValue;
                int[] reversedTail = new int[n - k];
                for (int i = 0; i < n - k; i++)
                {
                    reversedTail[i] = numbers[n - i];
                }
                for (int i = k + 1; i < n + 1 ; i++)
                {
                    numbers[i] = reversedTail[i - k - 1];
                }

                StringBuilder temp = new StringBuilder();
                for (int i = 0; i < n + 1; i++)
                {
                    temp.Append(numbers[i]);
                }
                result.Add(temp.ToString());
            }
            
            return result;
        }


        public static void Main()
        {
            Console.WriteLine(Permutation(9)[999999]);
        }
    }
}
