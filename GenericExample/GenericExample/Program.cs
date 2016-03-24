using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericExample
{
    class Program
    {
        public static void Swap<T>(ref T item1, ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }
        static void Main()
        {
            double d1 = 0, d2 = 2;
            Console.WriteLine("交换前:{0}, {1}", d1, d2);
            Swap(ref d1, ref d2);
            Console.WriteLine("交换前:{0}, {1}", d1, d2);
            Console.ReadLine();
        }
    }
}
