class NotebookList
{
    public int NotebookListID { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }

    public NotebookList(int notebookID, string brand, string model)
    {
        NotebookListID = notebookID;
        Brand = brand;
        Model = model;
    }
}

class OperSystems
{
    public int ID { get; set; }
    public string System { get; set; }
    public OperSystems(int id, string system)
    {
        ID = id;
        System = system;
    }
}

class Users
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public bool NotebookAvailability { get; set; }

    private int? _notebookBrandID;
    public int? NotebookBrandID
    {
        get => _notebookBrandID;
        set
        {
            if (NotebookAvailability == false)
            {
                _notebookBrandID = null;
            }
            else
            {
                _notebookBrandID = value;
            }
        }
    }

    private int? _systemID;
    public int? SystemID
    {
        get => _systemID;

        set
        {
            if (NotebookAvailability == false)
            {
                _systemID = null;
            }
            else
            {
                _systemID = value;
            }
        }
    }

    public Users(int userID, string name, bool notebookAvailability, int? notebookBrandID, int? systemID)
    {
        UserID = userID;
        Name = name;
        NotebookAvailability = notebookAvailability;
        NotebookBrandID = notebookBrandID;
        SystemID = systemID;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<NotebookList> notebookList = new List<NotebookList>();
        List<OperSystems> opersystems = new List<OperSystems>();
        List<Users> users = new List<Users>();

        notebookList.Add(new NotebookList(1, "Huawei", "ag1kg2"));
        notebookList.Add(new NotebookList(2, "Asus", "fngqkg"));

        opersystems.Add(new OperSystems(1, "Wind"));
        opersystems.Add(new OperSystems(2, "Lin"));

        users.Add(new Users(1, "hah", true, 1, 1));
        users.Add(new Users(2, "gag", false, null, null));
        users.Add(new Users(3, "faf", true, 2, 2));




        Console.WriteLine("Группировка по наличию кампудахтера");
        var AvailabilityGroup = from user in users
                                where user.NotebookAvailability == true
                                group user by user.NotebookAvailability;
        foreach (var user in AvailabilityGroup)
        {
            Console.WriteLine($"Пользователи сгруппированные по наличию компьютера ({(user.Key ? "есть" : "нет")}): ");
            foreach (var u in user)
            {
                string ModelName = "Нет данных";
                string brandName = "Нет данных";
                if (u.NotebookBrandID.HasValue)
                {
                    var brand = notebookList.FirstOrDefault(n => n.NotebookListID == u.NotebookBrandID.Value);
                    if (brand != null)
                    {
                        brandName = brand.Brand;
                        ModelName = brand.Model;
                    }
                }
                Console.WriteLine($"ФИО: {u.Name}; Марка ноутбука: {brandName}; Модель: {ModelName}");
            }
            Console.WriteLine();
        }


        Console.WriteLine("Группировка по марке кампудахтера");
        var BrandGroup = from user in users
                         where user.NotebookAvailability == true
                         group user by user.NotebookBrandID;
        foreach (var us in BrandGroup)
        {
            Console.WriteLine($"Пользователи сгруппированные по марке компьютера ({us.Key}): ");
            foreach (var u in us)
            {
                if (u.NotebookAvailability == true)
                {
                    string ModelName = "Нет данных";
                    if (u.NotebookBrandID != null)
                    {
                        var brand = notebookList.FirstOrDefault(n => n.NotebookListID == u.NotebookBrandID.Value);
                        if (brand != null)
                        {
                            ModelName = brand.Model;
                        }
                    }
                    Console.WriteLine($"ФИО: {u.Name}; Модель: {ModelName}");
                }
            }
            Console.WriteLine();
        }


        Console.WriteLine("Группировка по ОС");
        var OSGroup = from user in users
                      where user.NotebookAvailability == true
                      group user by user.SystemID;
        foreach (var us in OSGroup)
        {
            Console.WriteLine($"Пользователи сгруппированные по операционной системе ({us.Key}): ");
            foreach (var u in us)
            {
                if (u.NotebookAvailability == true)
                {
                    string ModelName = "Нет данных";
                    string brandName = "Нет данных";
                    if (u.NotebookBrandID.HasValue)
                    {
                        var brand = notebookList.FirstOrDefault(n => n.NotebookListID == u.NotebookBrandID.Value);
                        if (brand != null)
                        {
                            brandName = brand.Brand;
                            ModelName = brand.Model;
                        }
                    }
                    Console.WriteLine($"ФИО: {u.Name}; Марка ноутбука: {brandName}; Модель: {ModelName}");
                }
            }
            Console.WriteLine();
        }


        Console.WriteLine("Все данные пользователей:");
        foreach (var user in users)
        {
            string brandName = "Нет данных";
            string modelName = "Нет данных";

            if (user.NotebookBrandID.HasValue)
            {
                var notebook = notebookList.FirstOrDefault(n => n.NotebookListID == user.NotebookBrandID.Value);
                if (notebook != null)
                {
                    brandName = notebook.Brand;
                    modelName = notebook.Model;
                }
            }

            Console.WriteLine($"ФИО: {user.Name}; Марка ноутбука: {brandName}; Модель: {modelName}");
        }
    }
}