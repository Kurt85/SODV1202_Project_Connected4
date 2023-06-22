using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static int GetANumber(string mag)
        { 
            Console.WriteLine(mag);
            int x;
            do
            {
                try
                {
                    x = int.Parse(Console.ReadLine());
                    return x;
                }
                catch (FormatException eObj)
                {
                    Console.WriteLine("Please Enter Number with valid interger formating: \n(Reasons:" + eObj.Message+" )");
                }

            } while (true);
           
           
        }

        static int GetDivisionResultWithoutErrors()
        {
            int x, y;
            int result = 0;
            do
            {
                x = GetANumber("Enter first number: ");
                y = GetANumber("Enter second number: ");
                try
                {
                    result = x / y;
                    return result;
                }
                catch (DivideByZeroException eObj)
                {
                    Console.WriteLine("Division by Zero Error in the input: \nPlease provide non-zero input for both denominators: ");
                }

            } while (true);


        }



        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //int x, y;
            //Console.WriteLine("Enter two numbers: ");
            
            int result = GetDivisionResultWithoutErrors();
            Console.WriteLine("Result: "+ result);

            /*
            try
            {
                x = GetANumber("Enter first number: ");
                y = GetANumber("Enter second number: ");
                Console.WriteLine(x / y);
            }
            catch (FormatException eObj) 
            { 
                Console.WriteLine(eObj.Message);
            
            }
            catch (DivideByZeroException eObj) 
            { 
                Console.WriteLine(eObj.Message);
            }
            catch (Exception eObj)
            { 
                Console.WriteLine(eObj.Message);
            }*/

            Console.WriteLine("I am still running.......");
            
        }
    }
}
