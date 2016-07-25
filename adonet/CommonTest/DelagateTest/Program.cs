using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelagateTest
{
    //步骤：1、声明一个delegate类型
    public delegate string MyDelegate(string name);
    class Program
    {
        //2、定义准备被委托调用的方法
        public static string FunctionA(string name)
        {
            return "A say hello to " + name;
        }

        public static string FunctionB(string name)
        {
            return "B say hello to " + name;
        }
        
        //3、定义delegate类型的处理函数，并在此函数中通过delegate类型调用定义的方法
        public static void MethodA(MyDelegate me)
        {
            Console.WriteLine(me("zhangsan"));
        }


        static void Main(string[] args)
        {
            //4、创建实例，传入准备调用的方法名
            MyDelegate a = new MyDelegate(FunctionA);
            MyDelegate b = new MyDelegate(FunctionB);
            MethodA(a);
            MethodA(b);
        }
    }
}
