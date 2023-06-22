using System;
using System.Diagnostics.Tracing;

namespace ConsoleApp_ExceptionHandling
{
    internal class Program
    {   
        static void A(){
            B();
        }
        static void B() {
            C();    
        }
        static void C() { 
            D();
        }
        static void D() { 
            E();
        
        }
        static void E() {
            D();
        }
        static void F() { 
            
            int x = 5;
            int y = 0;
            try { 
            int result x / y;
             
            }
            catch (DivideByZeroException de)            
            {
                Console.WriteLine(de.Message);
            }

        static void Main(string[] args)
        {   

            Console.WriteLine("Hello World!");
            A()
        }
    }
}
