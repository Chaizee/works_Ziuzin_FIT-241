namespace prov
{

    class Mobile
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }

        public Mobile(string number, string name, string provider)
        {
            Number = number;
            Name = name;
            Provider = provider;
        }
    }
    class prog
    {
        static void Main(string[] args)
        {
            List<Mobile> mobiles = new List<Mobile>();

            while (true)
            {
                Console.WriteLine("Меню: ");
                Console.WriteLine("1. Добавить абонента");
                Console.WriteLine("2. Узнать чаще встречающегося оператора");
                Console.WriteLine("3. Выход");
                Console.Write("Выберите что хотите сделать: ");
                string Choice = Console.ReadLine();

                switch (Choice)
                {
                    case "1":
                        Console.WriteLine("\nВведите ФИО абонента: ");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Введите номер телефона: ");
                        string Number = Console.ReadLine();
                        Console.WriteLine("Введите провайдера: ");
                        string Provider = Console.ReadLine();
                        Console.WriteLine();
                        mobiles.Add(new Mobile(Number, Name, Provider));

                        break;
                    case "2":
                        
                        Dictionary<string, int> ProviderCount = new Dictionary<string, int>();

                        foreach (var mobile in mobiles)
                        {
                            if (ProviderCount.ContainsKey(mobile.Provider))
                            {
                                ProviderCount[mobile.Provider]++;
                            }
                            else
                            {
                                ProviderCount.Add(mobile.Provider, 1);
                            }
                        }

                        int MaxCountProvider = 0;
                        string MaxProvider = "";
                        foreach(var provider in ProviderCount)
                        {
                            if (provider.Value > MaxCountProvider)
                            {
                                MaxCountProvider = provider.Value;
                                MaxProvider = provider.Key;
                            }
                        }
                        Console.WriteLine($"\nБольше всего раз встречается: {MaxProvider}, количество: {MaxCountProvider} \n");

                        break;
                    case "3":
                        return;
                    case "":
                        Console.WriteLine("\nВыберите один из вариантов!\n");
                        break;

                    default:
                        Console.WriteLine("\nНет такого варианта!\n");
                        break;
                }
            }
        }
    }
}
