using System;

namespace ConsoleApp_Assignment2
{
    public class Base
    {
        public Base()
        {
            Console.WriteLine("Base Constructor");
            Console.WriteLine("0");
        }

        public virtual void Func()
        {
            Console.WriteLine("Base Func");
            Console.WriteLine("1");
        }
    }

    public class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("Derived Constructor");
            Console.WriteLine("2");
        }

        public override void Func()
        {
            Console.WriteLine("Derived Func");
            Console.WriteLine("3");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var b = new Base();
            b.Func();
            var d = new Derived();
            d.Func();
        }
    }

}
