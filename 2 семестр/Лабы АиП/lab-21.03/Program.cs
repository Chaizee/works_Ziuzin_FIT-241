//task 1
class Dot
{
    public double x { get; set; }
    public double y { get; set; }

    public Dot(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
}

delegate void CompletionHandler();

class CompletionEvent
{
    public event CompletionHandler Event;

    public void OnSomeEvent()
    {
        if (Event != null)
        {
            Event();
        }
    }
}

class Program
{
    static void Handler()
    {
        Console.WriteLine("Точка вышла за пределы поля");
        return;
    }

    static void Main(string[] args)
    {
        Random randomMove = new Random();

        Dot A = new Dot(1, 1);
        Dot B = new Dot(1, 5);
        Dot C = new Dot(5, 5);
        Dot D = new Dot(5, 1);

        Dot startDot = new Dot(2, 2);

        CompletionEvent evt = new CompletionEvent();
        evt.Event += Handler;

        for (; ; )
        {
            startDot.x += randomMove.NextDouble();
            startDot.y += randomMove.NextDouble();

            if (startDot.x < A.x || startDot.x > D.x || startDot.y < A.y || startDot.y > C.y)
            {
                evt.OnSomeEvent();
                break;
            }

            Thread.Sleep(200);
        }
    }
}

//task 2
class Horse
{
    public double Position { get; set; }
    public int Name { get; set; }
    public Horse(int name, double position)
    {
        this.Name = name;
        Position = position;
    }
}

delegate void complitionHandle(int horsenumber);

class ComplitionEvent
{
    public event complitionHandle Event;

    public void OnSomeEvent(int horsenumber)
    {
        if (Event != null)
        {
            Event(horsenumber);
        }
    }
}
class Program
{
    static void Handler(int horseNumber)
    {
        Console.WriteLine($"Лошадь {horseNumber} победила");
        Environment.Exit(0);
    }

    static void Main(string[] args)
    {
        ComplitionEvent evt = new ComplitionEvent();
        evt.Event += Handler;

        List<Horse> horses = new List<Horse>();
        int HorseCount = 5;
        double finishPosition = 1000;
        for (int i = 1; i <= HorseCount; i++)
        {
            horses.Add(new Horse(i, 0));
        }

        for (; ; )
        {
            for (int i = 0; i < HorseCount; i++)
            {
                //лошадь каждые 10 секунд меняет скорость

                Random randomMove = new Random();
                double speed = randomMove.Next(1, 30); //скорость от 1 до 30 км/ч

                horses[i].Position += (speed * 1000 / 3600) * 10;

                if (horses[i].Position >= finishPosition)
                {
                    evt.OnSomeEvent(horses[i].Name);
                    break;
                }
            }
        }
    }



}


