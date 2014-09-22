namespace _19.CountingSundays
{
    using System;

    public class CountingSundays
    {
        public static void Main()
        {
            DateTime currentDay = new DateTime(1901, 1, 1);
            DateTime lastDay = new DateTime(2000, 12, 31);
            int counter = 0;
            while (currentDay <= lastDay)
            {
                if(currentDay.DayOfWeek == DayOfWeek.Sunday)
                {
                    counter++;
                }
                currentDay = currentDay.AddMonths(1);
            }

            Console.WriteLine(counter);
            
        }
    }
}
