using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForExample
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.Title = "For testing";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Beep();
            for (int i = 1; i < 10; i += 2)
            {
                Console.SetCursorPosition(40 - i / 2, i);
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
            }
            Console.ReadLine();
        }
    }
}
