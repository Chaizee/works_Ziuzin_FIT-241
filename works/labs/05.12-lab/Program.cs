public class Student
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public string MotherFullName { get; set; }
    public string FatherFullName { get; set; }
    public string Address { get; set; }

    public Student(string fullName, int birthYear, string motherFullName, string fatherFullName, string address)
    {
        FullName = fullName;
        BirthYear = birthYear;
        MotherFullName = string.IsNullOrEmpty(motherFullName) ? "Не указано" : motherFullName;
        FatherFullName = string.IsNullOrEmpty(fatherFullName) ? "Не указано" : fatherFullName;
        Address = address;
    }
}

public class StudentManager
{
    private Student[] students;
    private int currentIndex = 0;

    public StudentManager(int size)
    {
        students = new Student[size];
    }

    public void AddStudent(Student student)
    {
        if (currentIndex < students.Length)
        {
            students[currentIndex] = student;
            currentIndex++;
        }
        else
        {
            Console.WriteLine("Массив заполнен.");
        }
    }

    public void ModifyStudent(string fullName, Student updatedStudent)
    {
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i] != null && students[i].FullName == fullName)
            {
                students[i] = updatedStudent;
                return;
            }
        }
        Console.WriteLine("Ученик не найден.");
    }

    public Student[] SearchStudentsByInitial(char initial)
    {
        return students.Where(s => s != null && s.FullName.StartsWith(initial.ToString(), StringComparison.OrdinalIgnoreCase)).ToArray();
    }

    public Student[] SearchStudentsByStreet(string street)
    {
        return students.Where(s => s != null && s.Address.Contains(street, StringComparison.OrdinalIgnoreCase)).ToArray();
    }

    public Student[] SearchStudentsByBirthYear(int birthYear)
    {
        return students.Where(s => s != null && s.BirthYear == birthYear).ToArray();
    }
    public bool IsFull()
    { 
        return currentIndex == students.Length; 
    }
}

class Program
{
    static void Main(string[] args)
    {
        StudentManager manager = new StudentManager(100);

        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Заполнение");
            Console.WriteLine("2. Модификация (доступно, если массив заполнен)");
            Console.WriteLine("3. Поиск учеников по начальной букве");
            Console.WriteLine("4. Поиск учеников по улице");
            Console.WriteLine("5. Поиск учеников по году рождения");
            Console.WriteLine("6. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите ФИО ученика: ");
                    string fullName = Console.ReadLine();
                    Console.Write("Введите год рождения: ");
                    int birthYear = int.Parse(Console.ReadLine());
                    Console.Write("Введите ФИО мамы (необязательно): ");
                    string motherFullName = Console.ReadLine();
                    Console.Write("Введите ФИО папы (необязательно): ");
                    string fatherFullName = Console.ReadLine();
                    Console.Write("Введите адрес: ");
                    string address = Console.ReadLine();

                    Student newStudent = new Student(fullName, birthYear, motherFullName, fatherFullName, address);
                    manager.AddStudent(newStudent);
                    break;

                case 2:
                   
                    if (manager.IsFull())
                    {
                        Console.Write("Введите ФИО ученика для модификации: ");
                        string modifyFullName = Console.ReadLine();
                        Console.Write("Введите новое ФИО: ");
                        string newFullName = Console.ReadLine();
                        Console.Write("Введите новый год рождения: ");
                        int newBirthYear = int.Parse(Console.ReadLine());
                        Console.Write("Введите новое ФИО мамы (необязательно): ");
                        string newMotherFullName = Console.ReadLine();
                        Console.Write("Введите новое ФИО папы (необязательно): ");
                        string newFatherFullName = Console.ReadLine();
                        Console.Write("Введите новый адрес: ");
                        string newAddress = Console.ReadLine();

                        Student updatedStudent = new Student(newFullName, newBirthYear, newMotherFullName, newFatherFullName, newAddress);
                        manager.ModifyStudent(modifyFullName, updatedStudent);
                    }
                    else
                    {
                        Console.WriteLine("Массив не полностью заполнен. Редактирование невозможно.");
                    }
                    break;

                case 3:
                    Console.Write("Введите начальную букву для поиска: ");
                    char initial = char.Parse(Console.ReadLine());
                    Student[] foundStudentsByInitial = manager.SearchStudentsByInitial(initial);
                    if (foundStudentsByInitial.Length > 0)
                    {
                        foreach (var student in foundStudentsByInitial)
                        {
                            Console.WriteLine($"ФИО: {student.FullName}, Адрес: {student.Address}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Учеников не найдено.");
                    }
                    break;

                case 4:
                    Console.Write("Введите улицу для поиска: ");
                    string street = Console.ReadLine();
                    Student[] foundStudentsByStreet = manager.SearchStudentsByStreet(street);
                    if (foundStudentsByStreet.Length > 0)
                    {
                        foreach (var student in foundStudentsByStreet)
                        {
                            Console.WriteLine($"ФИО: {student.FullName}, Адрес: {student.Address}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Учеников не найдено.");
                    }
                    break;

                case 5:
                    Console.Write("Введите год рождения для поиска: ");
                    int searchBirthYear = int.Parse(Console.ReadLine());
                    Student[] foundStudentsByYear = manager.SearchStudentsByBirthYear(searchBirthYear);
                    if (foundStudentsByYear.Length > 0)
                    {
                        foreach (var student in foundStudentsByYear)
                        {
                            Console.WriteLine($"ФИО: {student.FullName}, Год рождения: {student.BirthYear}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Учеников не найдено.");
                    }
                    break;

                case 6:
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, попробуйте снова.");
                    break;
            }
        }
    }
}



    