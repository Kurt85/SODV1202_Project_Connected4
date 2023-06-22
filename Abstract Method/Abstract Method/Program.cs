using System;
using System.Collections.Generic;

public abstract class Shape
{
    public abstract double Area();

    public override string ToString()
    {
        return $"The area of the shape object is {Area()}";
    }

    public virtual string shapeType()
    {
        return "Unkown";
    }






}
public class Square : Shape
{
    public int side;
    public Square(int s) { side = s; }
    public override double Area() { return side * side; }
}

public class Circle : Shape
{
    public int radius;
    public Circle(int r) { radius = r; }
    public override double Area()
    {
        return System.Math.PI * radius * radius;
    }
}
class ShapeTest
{
    static void Main(string[] args)
    {
        Shape sq = new Square(10);
        Shape circle = new Circle(5);

        List<Shape> myList = new List<Shape>();

        myList.Add(sq);
        myList.Add(circle);

        myList.Add(new Square(7));
        myList.Add(new Circle(7));
        myList.Add(new Square(17));
        myList.Add(new Circle(9));
        myList.Add(new Square(3));

        for(int i = 0; i < myList.Count; i++) 
        {   
            Console.WriteLine(myList[i]);
            if (myList[i] is Circle)
            {
                Circle c = (Circle)myList[i] as Circle;
                c.radius = c.radius * 2;
                
            }
        }
        Console.WriteLine("\n\nAfter doubling the radius of every circle type: ");
        foreach (var shape in myList)
        {
            Console.WriteLine(shape);
        }

        Shape s = sq;

        Square sq2 = s as Square;
        Console.WriteLine(sq2.side); // access child object

     



        System.Console.WriteLine("Area of square= " + sq.Area());
        System.Console.WriteLine("Area of circle= " + circle.Area());
        Console.Read();
    }
}
