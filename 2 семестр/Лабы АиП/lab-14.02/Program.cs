using System.Runtime.ConstrainedExecution;

namespace interf
{

    public interface IFormuls
    {
        double Perimetr();
        double Surface();

    }



    class Figure
    {
        public string Name { get; set; }

    }

    class Circle : Figure, IFormuls
    {

        public double Radius { get; set; }

        public double Perimetr()
        {
            return 2 * Math.PI * Radius;
        }

        public double Surface()
        {
            return Math.PI * Radius * Radius;
        }

    }

    class Square : Figure, IFormuls
    {
        public double Lenght { get; set; }

        public double Perimetr()
        {
            return 4 * Lenght;
        }

        public double Surface()
        {
            return Lenght * Lenght;
        }
    }

    class Triangle : Figure, IFormuls
    {
        public double Lenght { get; set; }

        public double Perimetr()
        {
            return 3 * Lenght;
        }

        public double Surface()
        {
            return Lenght * Lenght * Math.Sqrt(3) / 4;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            circle.Radius = 1;
            Console.WriteLine("Периметр окружности: "+circle.Perimetr());
            Console.WriteLine("Площадь окружности: " + circle.Surface() + "\n");

            Square square = new Square();
            square.Lenght = 1;
            Console.WriteLine("Периметр квадрата: " + square.Perimetr());
            Console.WriteLine("Площадь квадрата: " + square.Surface() + "\n");

            Triangle triangle = new Triangle();
            triangle.Lenght = 1;
            Console.WriteLine("Периметр треугольника: " + triangle.Perimetr());
            Console.WriteLine("Площадь треугольника: " + triangle.Surface() + "\n"); 
        }
    }
}
    