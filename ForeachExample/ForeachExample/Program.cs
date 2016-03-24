using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForeachExample
{
    class Program
    {
        static void Main()
        {
            //int[] i = { 1, 2, 3, 4 };
            //foreach(int x in i)
            //{
            //    Console.WriteLine("x value:{0}",x);
            //}
            //Console.ReadLine();
            SortedList<int, string> list = new SortedList<int, string>();
            list.Add(2, "str2");
            list.Add(1, "str2");
            list.Add(3, "str2");
            Console.WriteLine("index\tstring");
            foreach(int index in list.Keys)
            {
                Console.WriteLine(index + "\t" + list[index]);

            }
            Console.ReadLine();
        }
    }
}
