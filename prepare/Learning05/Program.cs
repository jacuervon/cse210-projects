using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square squareShape = new Square("Red", 3);
        shapes.Add(squareShape);

        Rectangle rectangleShape = new Rectangle("Blue", 4, 5);
        shapes.Add(rectangleShape);

        Circle circle = new Circle("Green", 6);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"[Color: {color} - Area: {area}]");
        }
    }
}