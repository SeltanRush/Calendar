using System;

namespace Calendar
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the date in format YYYY.MM : ");
            string s = Console.ReadLine();
            string[] arr = s.Split(".");
            long year = Convert.ToInt32(arr[0]);
            long month = Convert.ToInt32(arr[1]);
            if (year <= 0 || (month <= 0 || month > 12))
            {
                Console.WriteLine("Invalid date has entered !");
                return;
            }
            Console.WriteLine("MON TUE WED THU FRI SAT SUN");
            long days = ((year - 1) * 365);
            for (int i = 1; i < year; i++)
            {
                if (Leap(i) == true)
                    days++;
            }
            for (int i = 1; i < month; i++)
            {
                days += DaysInMonths(i, year);
            }
            if ((year >= 1752 && month > 9) || (year > 1752)) ;
            {
                days = days - 11;
            }
            long WeekD = ((days + 5) % 7);
            int g = 0;
            if (year == 1752 && month == 9)
            {
                for (int i = 1 - Convert.ToInt32(WeekD); i <= DaysInMonths(month, year); i++)
                {
                    if (i == 3)
                    {
                        i = 14;
                        g = g + 3;
                    }
                    if (i <= 0)
                    {
                        Console.Write("    ");
                        g++;
                    }
                    if ((i + g) % 7 == 1 && i != 0 && i != 1)
                    {
                        Console.Write("\n");
                    }
                    if (i > 0 && i < 10)
                    {
                        Console.Write("  {0} ", i);
                    }
                    if (i > 0 && i > 9)
                    {
                        Console.Write(" {0} ", i);
                    }
                }
            }
            else
            {

                for (int i = 1 - Convert.ToInt32(WeekD); i <= DaysInMonths(month, year); i++)
                {
                    if (i <= 0)
                    {
                        Console.Write("    ");
                        g++;
                    }
                    if ((i + g) % 7 == 1 && i > 1)
                    {
                        Console.Write("\n");
                    }
                    if (i > 0 && i < 10)
                    {
                        Console.Write("  {0} ", i);
                    }
                    if (i > 0 && i > 9)
                    {
                        Console.Write(" {0} ", i);
                    }
                }
            }
            Console.WriteLine();
        }
        static bool Leap(long year1)
        {
            if (year1 < 1752)
                return (year1 % 4 == 0 && year1 % 100 != 0) || (year1 % 400 == 0) || (year1 % 100 == 0);
            else
                return (year1 % 4 == 0 && year1 % 100 != 0) || (year1 % 400 == 0);
        }
        static int DaysInMonths(long month1, long year1)
        {
            if (month1 == 2)
            {
                if (Leap(year1) == true)
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
            if (month1 < 8)
            {
                if (month1 % 2 == 1)
                    return 31;
                else return 30;
            }
            else
            {
                if (month1 % 2 == 0)
                    return 31;
                else return 30;
            }
        }
    }
}
