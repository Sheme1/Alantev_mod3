public delegate double Area();

class Programm
{
    static void Main(string[] args)
    {
        Figura circle = new Circle(5);
        Figura rectangle = new Rectangle(6,7);
        Figura triangle = new Triangle(4,8,9);

        Area circleDelegate = circle.Area_1;
        Area rectangleDelegate = rectangle.Area_1;
        Area triangleDelegate = triangle.Area_1;
        Console.WriteLine("Площадь круга: " + circleDelegate());
        Console.WriteLine("Площадь квадрата: " + rectangleDelegate());
        Console.WriteLine("Площадь треугольника " + triangleDelegate());
    }
}

public abstract class Figura
{
    public abstract double Area_1();
}

public class Circle : Figura//Дочерний класс "Круг"
{
    private double radius; // Поле радиуса

    public Circle(double radius) //Конструктор класса
    {
        this.radius = radius;
    }

    public override double Area_1()
    {
        return 2 * Math.PI * radius;
    }
}

class Rectangle : Figura
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double Area_1()
    {
        return width * height;
    }
}

class Triangle : Figura
{
    private double a;
    private double b;
    private double c;

    public Triangle(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public override double Area_1()
    {
        double p = (a + b + c) / 2;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}