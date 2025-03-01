namespace abonentss
{
    class Abonent
    {
        public string FullName { get; set; }
        public string City { get; set; }
        public List<Numbers> MobileNumbers { get; set; }

        public Abonent(string fullname, string city, List<Numbers> mobileNumbers)
        {
            FullName = fullname;
            City = city;
            MobileNumbers = mobileNumbers;
        }


    }

    class Numbers
    {
        public string Number { get; set; }
        public string Year { get; set; }
        public string Provider { get; set; }

        public Numbers(string number, string provider, string year)
        {
            Number = number;
            Provider = provider;
            Year = year;
        }

        public static void SearchByProvider(Abonent[] abonents, string provider, int abonentscount)
        {
            for (int i = 0; i < abonentscount; i++)
            {
                for (int j = 0; j < abonents[i].MobileNumbers.Count(); j++)
                {
                    if (provider == abonents[i].MobileNumbers[j].Provider)
                    {
                        Console.WriteLine("Имя: " + abonents[i].FullName + "; Город: " + abonents[i].City + "; Телефон: " + abonents[i].MobileNumbers[j].Number + "; Оператор: " + abonents[i].MobileNumbers[j].Provider + "; Год подключения: " + abonents[i].MobileNumbers[j].Year);
                    }
                }
            }
        }

        public static void SearchByMobileNumber(Abonent[] abonents, string number, int abonentscount)
        {
            for (int i = 0; i < abonentscount; i++)
            {
                for (int j = 0; j < abonents[i].MobileNumbers.Count(); j++)
                {
                    if (number == abonents[i].MobileNumbers[j].Number)
                    {
                        Console.WriteLine("Имя: " + abonents[i].FullName + "; Город: " + abonents[i].City + "; Телефон: " + abonents[i].MobileNumbers[j].Number + "; Оператор: " + abonents[i].MobileNumbers[j].Provider + "; Год подключения: " + abonents[i].MobileNumbers[j].Year);
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Abonent[] abonents = new Abonent[2];
            int AbonentsCount = 0;
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить абонента в базу");
                Console.WriteLine("2. Найти абонента по провайдеру");
                Console.WriteLine("3. Найти абонента по номеру телефона");
                Console.WriteLine("4. Найти абонента по городу проживания");
                Console.WriteLine("5. Выход\n");
                Console.WriteLine("Выберите что хотите сделать");

                int Choice = int.Parse(Console.ReadLine());
                switch (Choice)
                {
                    case 1:
                        AddAbonent(abonents, AbonentsCount);
                        AbonentsCount++;
                        break;
                    case 2:
                        Console.WriteLine("Введите провайдера, по которому будет осуществлен поиск: ");
                        string TempProvider = Console.ReadLine();
                        Numbers.SearchByProvider(abonents, TempProvider, AbonentsCount);
                        break;
                    case 3:
                        Console.WriteLine("Введите номер телефона, по которому будет осуществлен поиск: ");
                        string TempNumber = Console.ReadLine();
                        Numbers.SearchByMobileNumber(abonents, TempNumber, AbonentsCount);
                        break;
                    case 4:
                        Console.WriteLine("Введите город, по которому будет осуществлен поиск: ");
                        string TempCity = Console.ReadLine();
                        SearchByCity(abonents, TempCity, AbonentsCount);
                        break;
                    case 5:
                        return;
                }
            }
        }

        static void AddAbonent(Abonent[] abonents, int AbonentsCount)
        {
            Console.WriteLine("Введите ФИО");
            string FullName = Console.ReadLine();
            Console.WriteLine("Введите город проживания абонента");
            string City = Console.ReadLine();
            Console.WriteLine("Сколько номеров у абонента?");
            int NumberCount = int.Parse(Console.ReadLine());

            List<Numbers> numbers = new List<Numbers>();

            for (int i = 0; i < NumberCount; i++)
            {
                Console.WriteLine($"Введите номер {i + 1}");
                string TempNumber = Console.ReadLine();
                Console.WriteLine("Введите оператора связи");
                string TempProvider = Console.ReadLine();
                Console.WriteLine("Введите год подключения номера");
                string TempYear = Console.ReadLine();

                numbers.Add(new Numbers(TempNumber, TempProvider, TempYear));
            }
            abonents[AbonentsCount] = new Abonent(FullName, City, numbers);
        }

        public static void SearchByCity(Abonent[] abonents, string city, int abonentscount)
        {
            for (int i = 0; i < abonentscount; i++)
            {
                if (city == abonents[i].City)
                {
                    Console.WriteLine("Имя: " + abonents[i].FullName + "; Город: " + abonents[i].City);
                }
            }
        }
    }
}