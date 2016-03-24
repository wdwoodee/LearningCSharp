using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RandomExample
{
    class Program
    {
        static void Main()
        {
            int[] num = new int[10];
            Random r = new Random();
            for (int i = 0; i < num.Length; i++)
            {
                num[i] = r.Next(101);

            }
            foreach (int n in num)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        }
    }
}
