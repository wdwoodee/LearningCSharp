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
            List<People> people = new List<People>();
            People p1 = new People(21, "zhangsan");
            People p2 = new People(20, "lisi");
            People p3 = new People(23, "wangwu");
            People p4 = new People(24, "mazi");
            People p5 = new People(25, "shiwan");
            People p6 = new People(18, "baqian");
            people.Add(p1);
            people.Add(p2);
            people.Add(p3);
            people.Add(p4);
            people.Add(p5);
            people.Add(p6);

            //匿名方法
            //IEnumerable<People> results = people.Where(delegate(People p) { return p.age > 20; });

            //Lambda
            IEnumerable < People > results = people.Where(People => People.age > 20); 
            IEnumerator
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
