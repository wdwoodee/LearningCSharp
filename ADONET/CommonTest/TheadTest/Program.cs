using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheadTest
{
    public class Program
    {
        private static Stopwatch stopWatch = new Stopwatch();
        static void Main(string[] args)
        {
            //Parallel.For(0, 100, i =>
            //{
            //    Console.Write(i + "\t");
            //});

            ParallelTest paraTest = new ParallelTest();
            //paraTest.ParallelBreak();
            paraTest.TestPLinq();
            
            ParallelDemo paraDemo = new ParallelDemo();
            paraDemo.ParallelInvokeMethod();

            //DateTime startTime;
            //TimeSpan resultTime;
            //List<entityA> source = new List<entityA>();
            //for (int i = 0; i < 100; i++)
            //{
            //    source.Add(new entityA
            //    {
            //        name = "悟空" + i,
            //        sex = i % 2 == 0 ? "男" : "女",
            //        age = i
            //    });
            //}
            //startTime = System.DateTime.Now;
            //stopWatch.Start();
            //loop1(source);
            //stopWatch.Stop();
            //Console.WriteLine("一般for循环耗时： " + stopWatch.ElapsedMilliseconds + " ms.");
            //resultTime = System.DateTime.Now - startTime;
            //Console.WriteLine("一般for循环耗时：" + resultTime);
            //startTime = System.DateTime.Now;
            //loop2(source);
            //resultTime = System.DateTime.Now - startTime;
            //Console.WriteLine("一般foreach循环耗时：" + resultTime);
            //startTime = System.DateTime.Now;
            //loop3(source);
            //resultTime = System.DateTime.Now - startTime;
            //Console.WriteLine("并行for循环耗时：" + resultTime.Milliseconds);
            //startTime = System.DateTime.Now;
            //loop4(source);
            //resultTime = System.DateTime.Now - startTime;
            //Console.WriteLine("并行foreach循环耗时：" + resultTime.Milliseconds);
            //Console.ReadLine();
        }

        //普通的for循环
        static void loop1(List<entityA> source)
        {
            int count = source.Count();
            for (int i = 0; i < count; i++)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        //普通的foreach循环
        static void loop2(List<entityA> source)
        {
            foreach (entityA item in source)
            {
                System.Threading.Thread.Sleep(100);
            }
        }

        //并行的for循环
        static void loop3(List<entityA> source)
        {
            int count = source.Count();
            Parallel.For(0, count, item =>
            {
                System.Threading.Thread.Sleep(100);
            });
        }

        //并行的foreach循环
        static void loop4(List<entityA> source)
        {
            Parallel.ForEach(source, item =>
            {
                System.Threading.Thread.Sleep(100);
            });
        }
    }

    //简单的实体
    class entityA
    {
        public string name { set; get; }
        public string sex { set; get; }
        public int age { set; get; }
    }
}
