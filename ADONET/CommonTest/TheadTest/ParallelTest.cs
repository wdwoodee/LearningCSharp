using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TheadTest
{
    public class ParallelTest
    {
        public Stopwatch stopWatch = new Stopwatch();
        public void ParallelBreak()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            stopWatch.Start();
            Parallel.For(0, 1000, (i, state) =>
            {
                if (bag.Count == 300)
                {
                    state.Stop();
                    //state.Break();
                    return;

                }
                bag.Add(i);
            });
            stopWatch.Stop();
            Console.WriteLine("Bag count is " + bag.Count + ", " + stopWatch.ElapsedMilliseconds);
        }

        public void TestPLinq()
        {
            Stopwatch sw = new Stopwatch();
            List<Custom> customs = new List<Custom>();
            for (int i = 0; i < 2000000; i++)
            {
                customs.Add(new Custom() { Name = "Jack", Age = 21, Address = "NewYork" });
                customs.Add(new Custom() { Name = "Jime", Age = 26, Address = "China" });
                customs.Add(new Custom() { Name = "Tina", Age = 29, Address = "ShangHai" });
                customs.Add(new Custom() { Name = "Luo", Age = 30, Address = "Beijing" });
                customs.Add(new Custom() { Name = "Wang", Age = 60, Address = "Guangdong" });
                customs.Add(new Custom() { Name = "Feng", Age = 25, Address = "YunNan" });
            }

            sw.Start();
            var result = customs.Where<Custom>(c => c.Age > 26).ToList();
            sw.Stop();
            Console.WriteLine("Linq time is {0}.", sw.ElapsedMilliseconds);

            sw.Restart();
            sw.Start();
            var result2 = customs.AsParallel().Where<Custom>(c => c.Age > 26).ToList();
            sw.Stop();
            Console.WriteLine("Parallel Linq time is {0}.", sw.ElapsedMilliseconds);
        }
    }

    public class Custom
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }

    public class ParallelDemo
    {
        //ParallelDemo m_paraDemo;
        //public ParallelDemo Initial
        //{
        //    get
        //    {
        //        if (m_paraDemo == null)
        //        {
        //            m_paraDemo = new ParallelDemo();
        //            return m_paraDemo;
        //        }
        //    };
        //    set
        //    {m_paraDemo = value};
        //}
        public Stopwatch stopWatch = new Stopwatch();

        public void Run1()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 is cost 2 sec");
            throw new Exception("Exception in task 1");
        }
        public void Run2()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task 2 is cost 3 sec");
            throw new Exception("Exception in task 2");
        }

        public void ParallelInvokeMethod()
        {
            stopWatch.Start();
            try
            {
                Parallel.Invoke(Run1, Run2);
            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            stopWatch.Stop();
            Console.WriteLine("Parallel run " + stopWatch.ElapsedMilliseconds + " ms.");

            stopWatch.Reset();
            stopWatch.Start();
            try
            {
                Run1();
                Run2();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            stopWatch.Stop();
            Console.WriteLine("Normal run " + stopWatch.ElapsedMilliseconds + " ms.");
        }
    }
}