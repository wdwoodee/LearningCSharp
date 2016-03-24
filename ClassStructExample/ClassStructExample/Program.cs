using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassStructExample
{
    class Program
    {
        static void Main()
        {
            ClassPoint[] p = new ClassPoint[10];
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new ClassPoint(i, i);
                Console.Write("({0},{1})",p[i].x, p[i].y);
            }
            Console.WriteLine();
            StructPoint[] sp = new StructPoint[10];
            Console.WriteLine(sp.Length);
            for (int i = 0; i < sp.Length; i++)
            {
                sp[i].x = sp[i].y = i;
                Console.Write("({0},{1})", sp[i].x, sp[i].y);
            }
            Console.ReadLine();
        }
    }
}
