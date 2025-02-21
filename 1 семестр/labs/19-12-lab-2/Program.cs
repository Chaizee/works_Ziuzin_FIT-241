public class Animal
{
    public string Name { get; set; }

    public Animal(string name)
    {
        Name = name;
    }
}

public class Bird : Animal
{
    public string Habitat { get; set; }
    public string MigrationDestination { get; set; }

    public Bird(string name, string habitat, string migrationDestination)
        : base(name)
    {
        Habitat = habitat;
        MigrationDestination = migrationDestination;
    }

    public override string ToString()
    {
        return $"Наименование: {Name}, место обитания: {Habitat}, место зимовки: {MigrationDestination}";
    }
}

public class Mammal : Animal
{
    public string Habitat { get; set; }
    public double Weight { get; set; }

    public Mammal(string name, string habitat, double weight)
        : base(name)
    {
        Habitat = habitat;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"Наименование: {Name}, место обитания: {Habitat}, вес: {Weight}";
    }
}


class Program
{
    static void Main()
    {
        Console.Write("Введите количество птиц: ");
        int birdCount = int.Parse(Console.ReadLine());
        Bird[] birds = new Bird[birdCount];

        for (int i = 0; i < birdCount; i++)
        {
            Console.WriteLine($"Введите данные для птицы {i + 1}:");
            Console.Write("Наименование: ");
            string name = Console.ReadLine();
            Console.Write("Обитание: ");
            string habitat = Console.ReadLine();
            Console.Write("Место зимовки: ");
            string migrationDestination = Console.ReadLine();
            birds[i] = new Bird(name, habitat, migrationDestination);
        }

        Console.Write("Введите количество млекопитающих: ");
        int mammalCount = int.Parse(Console.ReadLine());
        Mammal[] mammals = new Mammal[mammalCount];

        for (int i = 0; i < mammalCount; i++)
        {
            Console.WriteLine($"Введите данные для млекопитающего {i + 1}:");
            Console.Write("Наименование: ");
            string name = Console.ReadLine();
            Console.Write("Обитание: ");
            string habitat = Console.ReadLine();
            Console.Write("Вес: ");
            double weight = double.Parse(Console.ReadLine());
            mammals[i] = new Mammal(name, habitat, weight);
        }

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Выборка по обитанию");
            Console.WriteLine("2. Выборка птиц по месту зимовки");
            Console.WriteLine("3. Выборка млекопитающих по весу");
            Console.WriteLine("4. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите место обитания: ");
                    string habitat = Console.ReadLine();

                    Console.WriteLine("Птицы:");
                    foreach (var bird in birds)
                    {
                        if (bird.Habitat == habitat)
                        {
                            Console.WriteLine(bird);
                        }
                    }

                    Console.WriteLine("Млекопитающие:");
                    foreach (var mammal in mammals)
                    {
                        if (mammal.Habitat == habitat)
                        {
                            Console.WriteLine(mammal);
                        }
                    }
                    break;

                case 2:
                    Console.Write("Введите место зимовки: ");
                    string migrationDestination = Console.ReadLine();

                    Console.WriteLine("Птицы:");
                    foreach (var bird in birds)
                    {
                        if (bird.MigrationDestination == migrationDestination)
                        {
                            Console.WriteLine(bird);
                        }
                    }
                    break;

                case 3:
                    Console.Write("Введите минимальный вес: ");
                    double minWeight = double.Parse(Console.ReadLine());

                    Console.WriteLine("Млекопитающие:");
                    foreach (var mammal in mammals)
                    {
                        if (mammal.Weight >= minWeight)
                        {
                            Console.WriteLine(mammal);
                        }
                    }
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}
