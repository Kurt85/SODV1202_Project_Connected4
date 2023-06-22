using System;

namespace Interface_1
{
    public class Employee
    {   
        public int Id { get; set; } 
        public string Name { get; set; }
        public double Salary { get; set; }
        private static Random r;
        
        
        
        public Employee() 
        {
          
        
        }
        public static Employee GetARandom()
        { 
        }
    
    }
    internal class Program
    {
        static void Main(string[] args)
        {


            int[] x = { 1, 2, 3, 11, 22, 3, 1234, 54, 57 };


            Console.WriteLine("Hello World!");
        }
    }
}
