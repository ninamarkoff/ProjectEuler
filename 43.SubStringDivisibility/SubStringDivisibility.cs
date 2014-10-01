namespace _43.SubStringDivisibility
{
    using System;
    using System.Text;

    public class SubStringDivisibility
    {
        public static bool IsPandigital(long number)
        {
            int countOfDigits = 0;
            long copyOfNumber = number;
            while (copyOfNumber > 0)
            {
                countOfDigits++;
                copyOfNumber /= 10;
            }
            copyOfNumber = number;
            bool[] digits = new bool[countOfDigits + 1];
            while (!digits[copyOfNumber % 10] && copyOfNumber > 0)
            {
                digits[copyOfNumber % 10] = true;
                copyOfNumber /= 10;
            }
            if (copyOfNumber > 0)
            {
                return false;
            }
            return true;
        }

        public static void Main()
        {
            long sum = 0;

            for (int i = 10; i < 100; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 9; k += 2)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            if ((100 * j + 10 * k + l) % 3 == 0)
                            {
                                for (int m = 0; m < 6; m += 5)
                                {
                                    for (int n = 0; n < 10; n++)
                                    {
                                        if ((100 * l + 10 * m + n) % 7 == 0)
                                        {
                                            for (int o = 0; o < 987; o += 17)
                                            {
                                                if ((100 * m + 10 * n + o / 100) % 11 == 0 && (100 * n + o / 10) % 13 == 0)
                                                {
                                                    StringBuilder number = new StringBuilder();
                                                    number.Append(i);
                                                    number.Append(j);
                                                    number.Append(k);
                                                    number.Append(l);
                                                    number.Append(m);
                                                    number.Append(n);
                                                    if (o < 100)
                                                    {
                                                        number.Append('0' + o);
                                                    }
                                                    else
                                                    {
                                                        number.Append(o);
                                                    }
                                                    if (IsPandigital(long.Parse(number.ToString())))
                                                    {
                                                        sum += long.Parse(number.ToString());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}