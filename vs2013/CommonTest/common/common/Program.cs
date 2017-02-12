using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Animal();
            animal.Eat();
            animal.Talk();
            Console.WriteLine("base\r\n");

            Cat cat = new Cat();
            cat.Walk();
            cat.Eat();
            cat.Talk();
            Console.WriteLine("derived\r\n");

            //限定父类的行为和数据
            Animal catAnimal = new Cat();            
            catAnimal.Eat();

            //重写后，调用的子类方法
            catAnimal.Talk();


            Console.ReadKey();
        }
    }

    public class Animal
    {
        public Animal()
        {
            Console.WriteLine("Base: Hello, Animal!");
        }
        public void Eat()
        {
            Console.WriteLine("Base: Eating!");
        }

        public virtual void Talk()
        {
            Console.WriteLine("Base: Talking!");
        }
    }

    public class Cat : Animal
    {
        public Cat()
        {
            Console.WriteLine("Derived: Hello, Cat!");
        }

        public void Walk()
        {
            Console.WriteLine("Derived: Walk!");
        }

        public void Eat()
        {
            Console.WriteLine("Derived: Eating!");
        }

        public override void Talk()
        {
            Console.WriteLine("Derived: Talking!");
        }
    }
}
