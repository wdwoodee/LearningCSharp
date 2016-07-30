using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
        public delegate string MyDelegate(object data);
        static void Main(string[] args)
        {
            #region Create Task
            //var task1 = new Task(() =>
            //{
            //    Console.WriteLine("Hello,task");
            //});
            //task1.Start();

            //var task2 = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Hello,task started by task factory");
            //});
            #endregion

            #region status
            //task1.Wait();就是等待任务执行完成，我们可以看到最后task1的状态变为Completed。
            //var task1 = new Task(() =>
            //{
            //    Console.WriteLine("Begin");
            //    System.Threading.Thread.Sleep(2000);
            //    Console.WriteLine("Finish");
            //});
            //Console.WriteLine("Before start:" + task1.Status);
            //task1.Start();
            //Console.WriteLine("After start:" + task1.Status);
            //task1.Wait();
            //Console.WriteLine("After Finish:" + task1.Status);
            #endregion

            #region waitall

            //waitall就是等待所有的任务都执行完成
            //var task1 = new Task(() =>
            //{
            //    Console.WriteLine("Task 1 Begin");
            //    System.Threading.Thread.Sleep(2000);
            //    Console.WriteLine("Task 1 Finish");
            //});
            //var task2 = new Task(() =>
            //{
            //    Console.WriteLine("Task 2 Begin");
            //    System.Threading.Thread.Sleep(3000);
            //    Console.WriteLine("Task 2 Finish");
            //});

            //task1.Start();
            //task2.Start();
            ////Task.WaitAll(task1, task2);

            ////等待任何一个任务完成就继续向下执行
            //Task.WaitAny(task1, task2);
            //Console.WriteLine("All task finished!");


            #endregion

            #region ContinueWith
            //ContinueWith 就是在第一个Task完成后自动启动下一个Task，实现Task的延续
            //var task1 = new Task(() =>
            //{
            //    Console.WriteLine("Task 1 Begin");
            //    System.Threading.Thread.Sleep(2000);
            //    Console.WriteLine("Task 1 Finish");
            //});
            //var task2 = new Task(() =>
            //{
            //    Console.WriteLine("Task 2 Begin");
            //    System.Threading.Thread.Sleep(3000);
            //    Console.WriteLine("Task 2 Finish");
            //});


            //task1.Start();
            //task2.Start();
            //var result = task1.ContinueWith<string>(task =>
            //{
            //    Console.WriteLine(task1.Status);
            //    Console.WriteLine("task1 finished!");
            //    return "This is task result!";
            //});

            //Console.WriteLine(result.Result.ToString());
            #endregion

            #region
            //在每次调用ContinueWith方法时，每次会把上次Task的引用传入进来，以便检测上次Task的状态，比如我们可以使用上次Task的Result属性来获取返回值。
            //var SendFeedBackTask = Task.Factory.StartNew(() => { Console.WriteLine("Get some Data!"); })
            //                .ContinueWith<bool>(s => { return true; })
            //                .ContinueWith<string>(r =>
            //                {
            //                    if (r.Result)
            //                    {
            //                        return "Finished";
            //                    }
            //                    else
            //                    {
            //                        return "Error";
            //                    }
            //                });
            //Console.WriteLine(SendFeedBackTask.Result);

            //其实上面的写法简化一下，可以这样写：
            //Task.Factory.StartNew<string>(() => { return "One"; }).ContinueWith(ss => { Console.WriteLine(ss.Result); });
            #endregion

            #region 死锁处理
            //Task[] tasks = new Task[2];
            //tasks[0] = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Task 1 Start running...");
            //    while (true)
            //    {
            //        System.Threading.Thread.Sleep(1000);
            //    }
            //    Console.WriteLine("Task 1 Finished!");
            //});
            //tasks[1] = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("Task 2 Start running...");
            //    System.Threading.Thread.Sleep(2000);
            //    Console.WriteLine("Task 2 Finished!");
            //});

            //Task.WaitAll(tasks, 5000);
            //for (int i = 0; i < tasks.Length; i++)
            //{
            //    if (tasks[i].Status != TaskStatus.RanToCompletion)
            //    {
            //        Console.WriteLine("Task {0} Error!", i + 1);
            //    }
            //}
            //Console.Read();
            #endregion

            #region spinlock
            //SpinLock slock = new SpinLock(false);
            //long sum1 = 0;
            //long sum2 = 0;
            //long sum3 = 0;
            //Parallel.For(1, 100001, i =>
            //{
            //    //Console.WriteLine(i);
            //    sum1 += i;
            //    //Console.WriteLine(sum1);
            //});
            //for (int i = 1; i < 100001; i++)
            //{
            //    sum3 += i;
            //}

            //Parallel.For(1, 100001, i =>
            //{
            //    bool lockTaken = false;
            //    try
            //    {
            //        slock.Enter(ref lockTaken);
            //        sum2 += i;
            //    }
            //    finally
            //    {
            //        if (lockTaken)
            //            slock.Exit(false);
            //    }
            //});

            //Console.WriteLine("Num1的值为:{0}", sum1);
            //Console.WriteLine("Num2的值为:{0}", sum2);
            //Console.WriteLine("Num3的值为:{0}", sum3);

            #endregion

            #region continuewith
            //Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 100);
            //t.Start();
            //t.Wait();
            //Console.WriteLine(t.Result);

            //Task<Int32> t = new Task<Int32>(n => Sum((Int32)n), 1000);
            //t.Start();
            ////t.Wait();
            //var cwt = t.ContinueWith<string>(task => { Console.WriteLine("The result is {0}", t.Result); return "task2 finish"; });
            //Console.WriteLine(cwt.Result);
            #endregion

            #region 委托的异步调用：BeginInvoke() 和 EndInvoke()
            MyDelegate mydelegate = new MyDelegate(TestMethod);
            IAsyncResult result = mydelegate.BeginInvoke("Thread Param", TestCallback, "Callback Param");

            //异步执行完成
            string resultstr = mydelegate.EndInvoke(result);
            #endregion


            Console.Read();
        }

        private static Int32 Sum(Int32 n)
        {
            Int32 sum = 0;
            for (; n > 0; --n)
                checked { sum += n; } //结果太大，抛出异常
            return sum;
        }

        //线程函数
        public static string TestMethod(object data)
        {
            string datastr = data as string;
            return datastr;
        }

        //异步回调函数
        public static void TestCallback(IAsyncResult data)
        {
            Console.WriteLine(data.AsyncState);
        }
    }
}
