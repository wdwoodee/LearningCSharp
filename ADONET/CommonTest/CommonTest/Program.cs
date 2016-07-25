using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();
            People p1 = new People(21, "zhangsan");
            People p2 = new People(20, "lisi");
            People p3 = new People(23, "wangwu");
            People p4 = new People(24, "mazi");
            People p5 = new People(25, "shiwan");
            People p6 = new People(18, "baqian");
            peoples.Add(p1);
            peoples.Add(p2);
            peoples.Add(p3);
            peoples.Add(p4);
            peoples.Add(p5);
            peoples.Add(p6);

            //匿名方法
            //IEnumerable<People> results = peoples.Where(delegate(People p) { return p.age > 20; });

            //Lambda
            IEnumerable <People> results = peoples.Where(People => People.age > 20);

            Console.WriteLine("传统的委托代码示例：");
            LambdaTest.FindListDelegate();
            Console.Write("\n");

            Console.WriteLine("使用匿名方法的示例：");
            LambdaTest.FindListAnonymousMethod();
            Console.Write("\n");

            Console.WriteLine("使用Lambda的示例：");
            LambdaTest.FindListLambdaExpression();    
        }
    }
    public class People
    {
        public int age{get; set;}
        public string name{get; set;}
        public People(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
    }
}
