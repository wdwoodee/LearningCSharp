using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shuxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Persone p1 = new Persone();
            Console.WriteLine("Age is:{0}", p1.Age);
            p1.Age = 30;
            Console.WriteLine("Age is:{0}", p1.Age);
            p1.Age = -30;
            Console.WriteLine("Age is:{0}", p1.Age);
            Console.ReadKey();
        }
    }

    class Persone
    {
        private int age =10;
        
        
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                this.age = value;
            }

          
        }
    }
}
