Rectangle r = new(height: 3, width: 4.5);
Console.WriteLine($"Rectangle H : {r.Height}, W : {r.Width}, Area : {r.Area}");

Square s = new(5);
Console.WriteLine($"Square H : {s.Height}, W : {s.Width}, Area : {s.Area}");

Circle c = new(2.5);
Console.WriteLine($"Circle H : {c.Height}, W : {c.Width}, Area : {c.Area}");

class Shape
{
    public double Height { get; set; }
    public double Width { get; set; }
    public double Area {  get; set; }
}

class Rectangle : Shape
{
    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
        Area = height * width;
    }
}

class Square : Shape
{
    public Square(double height)
    {
        Height = height;
        Width = height;
        Area = height * Width;
    }
}

class Circle : Shape
{
    public double Radius {  get; set; }
    const double PI = 3.14f;

    public Circle(double radius)
    {
        Height = radius * 2;
        Width = radius * 2;
        Radius = radius;
        Area = PI * Radius * Radius;
    }
}
