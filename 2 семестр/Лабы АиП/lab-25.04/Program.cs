class Phone
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string Country { get; set; }

    public Phone(string name, int year, string country)
    {
        Name = name;
        Year = year;
        Country = country;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Phone> phoneList = new List<Phone>();
        phoneList.Add(new Phone("Apple", 2005, "Russia"));
        phoneList.Add(new Phone("Sex", 2005, "Kombodga"));
        for (; ; )
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Добавить телефон в БД");
            Console.WriteLine("2. Сгруппировать телефоны по стране");
            Console.WriteLine("3. Поиск телефонов по году выпуска");
            Console.WriteLine("4. Сгруппировать телефоны по марке");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");
            int Choice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (Choice)
            {
                case 1:
                    Console.Write("Введите модель телефона: ");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Введите год выпуска: ");
                    int Year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите страну: ");
                    string Country = Console.ReadLine();
                    phoneList.Add(new Phone(Name, Year, Country));

                    break;
                
                case 2:
                    var countryPhone = from phone in phoneList
                                       group phone by phone.Country;
                    foreach (var phones in countryPhone)
                    {
                        Console.WriteLine($"Телефоны сгруппированные по стране телефона {phones.Key}:");
                        foreach (var phone in phones)
                        {
                            Console.WriteLine(phone.Name + " " + phone.Year + " " + phone.Country);
                        }
                        Console.WriteLine(" ");
                    }
                    break;
                
                case 3:
                    Console.Write("Введите год выпуска: ");
                    int year = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    var yearPhone = from phone in phoneList
                                    where phone.Year == year
                                    select phone;
                    if (yearPhone.Count() == 0)
                    {
                        Console.WriteLine("Телефонов выпущенных в этом году не найдено \n");
                        break;
                    }
                    foreach (var phone in yearPhone)
                    {
                        Console.WriteLine(phone.Name);
                    }    
                    Console.WriteLine();
                    break;

                case 4:
                    var namePhone = from phone in phoneList
                                    group phone by phone.Name;
                    foreach (var phones in namePhone)
                    {
                        Console.WriteLine($"телефоны сгруппированные по марке {phones.Key}");
                        foreach (var phone in phones)
                        {
                            Console.WriteLine(phone.Name + " " + phone.Year + " " + phone.Country);
                        }
                        Console.WriteLine(" ");
                    }
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Такого варианта нет!");
                    break;
            }
        }
    }
}