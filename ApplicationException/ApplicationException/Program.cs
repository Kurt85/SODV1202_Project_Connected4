
using System;

namespace abc
{




    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int x=1;
            bool flag = true;
            do
            {
                flag = int.TryParse(Console.ReadLine(), out x);
                try
                {
                    if (x > 20) throw new FireHazardExcception ("Danger!!!!! Smoke Waring Exceeded Threshold!!!!");
                }
                catch(FireHazardExcception fhe) 
                { 
                    fhe.CombatFireHazard();
                    Console.WriteLine(fhe.Message);
                }
            } while (!flag);

        }
    }
}
