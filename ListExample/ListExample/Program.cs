using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListExample
{
    class Program
    {
        static void Main()
        {
            //List<string> list = new List<string>();
            //list.Add("张三");
            //list.Add("李四");
            //list.Insert(0,"王五");
            //if (list.Contains("赵六") == false)
            //{
            //    list.Add("赵六");
            //}
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item);
            //}
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine("list[{0}] = {1}", i, list[i]);
            //}
            //list.Remove("张三");
            //Console.WriteLine("After remove:");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine("list[{0}] = {1}", i, list[i]);
            //}
            //list.Clear();
            //Console.WriteLine("After clear:");
            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine("list[{0}] = {1}", i, list[i]);
            //}

            List<int> list = new List<int>();
            list.AddRange(new int[] { 12, 8, 5, 20 });
            Console.WriteLine(list.Sum());
            Console.WriteLine(list.Average());
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());


            Console.ReadLine();
        }
    }
}
