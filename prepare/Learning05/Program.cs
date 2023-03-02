using System;

class Program
{
    static void Main(string[] args)
    {
       List<Shape> shapes = new List<Shape>();
       Square s1 = new Square ("Red", 3);
       shapes.Add(s1);

       Rectangels s2 = new Rectangels ("Blue", 4, 5);
       shapes.Add(s2);

       Circle s3 = new Circle ("Green", 6);
       shapes.Add(s3);

       foreach (Shape s in shapes)
       {
        string color = s.GetColor();
        double area = s.GetArea();

        Console.WriteLine($"{color} shape has an area of {area}.");
       }

    }
}