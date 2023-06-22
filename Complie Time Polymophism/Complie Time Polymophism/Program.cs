using System;
public class Summation
{
    public void ShowMessage(int n)
    {
        Console.Write("The Summation of {0} integer numbers is: ", n);
    }

    public double ShowMessage(double n)// changing parameter type can overload a method
    {
        Console.WriteLine("The Summation of {0} numbers is: ", n);


        return 0.0;

    }

    public long ShowMessage(long n)// changing parameter type can overload a method
    {
        Console.WriteLine("The Summation of {0} numbers is: ", n);


        return 0;

    }


    public int GetSummation(int a, int b)
    {
        ShowMessage(2);
        return a + b;
    }
    public int GetSummation(int a, int b, int c)
    {
        ShowMessage(3);
        return a + b + c;
    }
    public int GetSummation(int a = 0, int b = 0, int c=0, int d=0)
    {
        ShowMessage(4);
        return a + b + c + d;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Summation obj = new Summation();
        Console.WriteLine(obj.GetSummation(1, 3, 5, 7));
        Console.WriteLine(obj.GetSummation(4, 5));
        Console.WriteLine(obj.GetSummation(1, 2, 3));

        //long result = obj.ShowMessage(56866767687);


        Console.WriteLine(obj.GetSummation(1));//skip 
        Console.Read();
    }
}

