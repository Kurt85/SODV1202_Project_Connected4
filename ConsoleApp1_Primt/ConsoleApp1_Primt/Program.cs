using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1_Primt
{
    internal class Program
    {
        static string PrintInHexadecimal(int n)
        { 
            List<int> rl = new List<int>();
            
            while (n !=0) { 
            
                rl.Add(n%16);
                n = n / 16;
            }
            rl.Reverse();
            string result = "";
            foreach (var val in rl)
            {
                if (val <= 9) result += val;
                else if (val <= 10) result += "A";
                else if (val <= 11) result += "B";
                else if (val <= 12) result += "C";
                else if (val <= 13) result += "D";
                else if (val <= 14) result += "E";  
            }
            return result;
        }

        static string PrintOutHexadecimal(int n)
        {
            LinkedList<int> rl = new LinkedList<int>();
            while (n !=0)
            {
                rl.AddLast(n%8);
            }
            rl.Reverse();
            string result = "";
            foreach (var val in rl)
            { 
                if (val <= 9) result += val;
                else if (val <= 10) result += "A";
                else if (val <= 11) result += "B";
                else if (val <= 12) result += "C";
                else if (val <= 13)
            
            
            }

        }

        static void Prnt(int n, int b = 10) 
        {

            if (b == 10)
            {
                Console.WriteLine(n);
            }
            else if (b == 16)
            {
                Console.WriteLine(PrintInHexadecimal(n));
            }
            else if (b == 8)
            {
                //Console.WriteLine(PrintInOct(value));
            }
            else if (b == 2)
            { 
                //Console.WriteLine(PrintInBinary(value));
            }
        
        }

        static void Main(string[] args)
        {
            Prnt(10000,16);
        }
    }
}
