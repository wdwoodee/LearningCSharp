using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    interface Ifunction1
    {
        int Sum(int x, int y);
    }
    interface Ifunction2
    {
        string myString{get; set;}
    }
    interface Ifunction3
    {
        int Sum2(int x, int y);
    }
    public class MyTest : Ifunction1, Ifunction2, Ifunction3
    {
        private string myStr;
        public MyTest()
        { }
        public MyTest(string str)
        {
            myStr = str;
        }
        public int Sum(int x, int y)
        {
            return x + y;
        }
        int Ifunction3.Sum2(int x, int y)
        {
            return x + y;
 
        }
        
        public string myString
        {
            get
            {
                return myStr;
            }
            set 
            {
                myStr = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Ifunction1 f1 = new MyTest();
            MyTest test = new MyTest();
            Ifunction3 f3 = new MyTest();
            Console.WriteLine(f1.Sum(20, 30));
            Console.WriteLine(f3.Sum2(20, 10));
            Console.WriteLine(test.Sum(20, 100));
            Ifunction2 f2 = new MyTest("How are you!");
            Console.WriteLine(f2.myString);
            Console.ReadKey();
        }
    }
}
