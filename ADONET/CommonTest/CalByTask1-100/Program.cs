using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalByTask1_100
{
    public class Program
    {
        static void Main(string[] args)
        {
            Task[] ts = new Task[10];
            int value = 0;
            int sum = 0;
            ts[0] = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    value++;
                    sum += value;
                }
            });
            ts[0].Start();
            for (int m = 0; m < 10 - 1; m++)
            {
                //ts[i+1]=new Task(
                ts[m + 1] = ts[m].ContinueWith(pt =>
                {
                    //上一个task结束后的value值
                    Console.WriteLine(value);
                    Console.WriteLine(sum);
                    if (value < 100)
                        for (int j = 0; j < 10; j++)
                        {
                            value++;
                            sum += value;
                        }
                });
            }
            Task.WaitAll(ts);
            Console.WriteLine(value);
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
