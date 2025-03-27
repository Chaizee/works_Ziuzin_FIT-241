// Задача 1
namespace Delegates
{

    public class Calculate
    {
        public int a;
        public int b;

        public Calculate(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public int Add()
        {
            return a + b;
        }

        public int Subtract()
        {
            return a - b;
        }

        public int Multiply()
        {
            return a * b;
        }

        public int Divide()
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Деление на ноль невозможно");
            }
            return a / b;
        }
    }

    public delegate int OperationDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            Calculate Obj1 = new Calculate(10, 5);

            OperationDelegate delegate1 = () =>
            {
                int FirstAction1 = Obj1.Add();

                int SecondAction1 = new Calculate(FirstAction1, Obj1.b).Multiply();

                int LastAction1 = new Calculate(SecondAction1, Obj1.b).Divide();

                return LastAction1;
            };

            int result1 = delegate1();

            Console.WriteLine($"Результат работы первого действия: {result1}");

            Calculate Obj2 = new Calculate(6, 2);

            OperationDelegate delegate2 = () =>
            {
                int FirstAction2 = Obj2.Divide();

                int SecondAction2 = new Calculate(FirstAction2, Obj2.b).Subtract();

                int LastAction2 = new Calculate(SecondAction2, Obj2.b).Multiply();

                return LastAction2;
            };

            int result2 = delegate2();
            Console.WriteLine($"Результат работы второго действия: {result2}");
        }
    }
}

// Задача 2

class Car
{
    public string Year { get; set; }
    public string Model { get; set; }
    public string Color { get; set; } 
    public bool IsWashed { get; set; } 

    public Car (string year, string model, string color, bool isWashed)
    {
        Year = year;
        Model = model;
        Color = color;
        IsWashed = isWashed;
    }
}

class Garage
{
    public List<Car> Cars;
}

class Washing
{
    public static void washCar(Car car)
    {
        if (car.IsWashed == true)
        {
            Console.WriteLine($"Машина: {car.Model} чистая");
        }
        else
        {
            car.IsWashed = true;
            Console.WriteLine($"Машина: {car.Model} помыта");
        }
    }
}

delegate void CarWashing(Car car);
class Program
{
    static void Main(string[] args)
    {
        CarWashing carWashing = new CarWashing(Washing.washCar);

        Garage garage = new Garage();
        garage.Cars = new List<Car>();

        Console.Write("Введите количество машин: ");
        int CarsCount = Convert.ToInt32(Console.ReadLine());
        
        for(int i=0; i < CarsCount; i++)
        {
            Console.Write("Введите модель машины: ");
            string Model = Console.ReadLine();
            Console.Write("Введите год выпуска: ");
            string Year = Console.ReadLine();
            Console.Write("Введите цвет машины: ");
            string Color = Console.ReadLine();
            Console.WriteLine("Машина помыта или нет? (Введите 1 - если да, 0 - если нет)");
            bool CarIsWashed = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));

            garage.Cars.Add(new Car(Year, Model, Color, CarIsWashed));
        }

        for (int i =0; i <CarsCount; i++)
        {
            carWashing(garage.Cars[i]);
        }
    }
}
