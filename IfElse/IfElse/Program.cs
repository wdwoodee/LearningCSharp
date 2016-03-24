using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IfElse
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please input a number:");
            string i = Console.ReadLine();
            int x = Convert.ToInt32(i);
            int y;
            if (x > 0)
                y = 1;
            else if (x == 0)
                y = 0;
            else y = -1;
            Console.WriteLine("Value of y:{0}", y);
            Console.ReadLine();
        }
    }
}
