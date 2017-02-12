using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace GouZao
{
    class Program
    {
        static void Main(string[] args)
        {
            Type t = typeof(int);
            Console.WriteLine("t:{0}", t);
            MethodInfo[] methods = t.GetMethods();
            foreach (var m in methods)
            {
                Console.WriteLine(m.Name);
            }


            B b1 = new B();
            B b2 = new B(10);
            Console.ReadKey();
        }
    }

    public class A
    {
        //未赋值，初始化为0
        protected int age;
        public A()
        {
            Console.WriteLine("A: {0}", age);
        }

        public A(int age)
        {
            this.age = age;
            Console.WriteLine("A: {0}", age);
        }
    }

    public class B : A
    {
        public B() : base()
        {
            Console.WriteLine("B: {0}", age);
        }

         public B(int age) : base(age)
        {
            age = 5;
            Console.WriteLine("B: {0}", age);
        }
    }
}
