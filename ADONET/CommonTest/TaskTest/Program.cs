using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTest
{
    class Program
    {
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
            Task.Factory.StartNew<string>(() => { return "One"; }).ContinueWith(ss => { Console.WriteLine(ss.Result); });
            #endregion



            Console.Read();
        }
    }
}
