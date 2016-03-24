using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndexExample
{
    class DayCollection 
    {
        string[] days = { "Sun", "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
        public int this[string day]
        {
            get 
            {
                return (GetDay(day));
            }
        }
        public string this[int i]
        {
            get 
            {
                return (days[i]);
            }
        }
        private int GetDay(string testDay)
        {
            int i = 0;
            foreach (string day in days)
            {
                if (day == testDay)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
     }
    class Program
    {
        static void Main(string[] args)
        {
            DayCollection week = new DayCollection();
            Console.WriteLine(week[1]);
            Console.WriteLine(week["Fri"]);
            Console.WriteLine(week["Other Day"]);
            Console.ReadLine();
        }
    }
}
