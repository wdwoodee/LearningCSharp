using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interface
{
    /*
    这就是继承中的向上转型。父类 FL=new 子类()；只不过这里的父类就是interface接口。(个人认为这里不管是class的override还是interface的重写，都是一样的用法)
    可以把实现某一接口类创建的对象的引用赋给该接口声明的接口变量，那么该 
接口变量就可以调用被类实现的接口中的方法。实际上，当接口变量调用被类实现的接口 
中的方法时，就是通知相应的对象调用接口方法
    通过上面的例子，我们不难看出，接口对象的实例化实际上是一个接口对象作为一个引用 
，指向实现了它方法的那个类中的所有方法
     */
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
            //Ifunction1 f1 = new MyTest();
            //MyTest test = new MyTest();
            //Ifunction3 f3 = new MyTest();
            //Console.WriteLine(f1.Sum(20, 30));
            //Console.WriteLine(f3.Sum2(20, 10));
            //Console.WriteLine(test.Sum(20, 100));
            //Ifunction2 f2 = new MyTest("How are you!");
            //Console.WriteLine(f2.myString);

            num n = null;//声明类对象引用
            Itemp tm = null;//声明接口对象引用
            tm = new num(1.1, 2.2);//接口回调(向上转型)
            Console.WriteLine(tm.plus());
            Console.ReadKey();
        }
    }

    interface Itemp
    {
        double plus();
    }
    public class num : Itemp
    {
        double aa, bb;
        public num(double a, double b)
        {
            this.bb = b;
            this.aa = a;
        }
        public double plus()
        {
            return (aa * bb);
        }
    }
}
