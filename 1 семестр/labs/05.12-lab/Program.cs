using System;
using System.Linq;

class Student
{
    public string FullName { get; set; }
    public int BirthYear { get; set; }
    public string MotherName { get; set; }
    public string FatherName { get; set; }
    public string Address { get; set; }

    public Student(string fullName, int birthYear, string motherName, string fatherName, string address)
    {
        FullName = fullName;
        BirthYear = birthYear;
        MotherName = motherName;
        FatherName = fatherName;
        Address = address;
    }
}

class Classroom
{
    static Student[] students = new Student[3];
    static int studentCount = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Заполнить данные ученика");
            Console.WriteLine("2. Модификация данных ученика");
            Console.WriteLine("3. Поиск учеников по первым символам");
            Console.WriteLine("4. Поиск учеников по улице");
            Console.WriteLine("5. Поиск по году рождения");
            Console.WriteLine("6. Выход");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddStudent();
                    break;
                case 2:
                    ModifyStudent();
                    break;
                case 3:
                    SearchByFirstLetter();
                    break;
                case 4:
                    SearchByStreet();
                    break;
                case 5:
                    SearchByBirthYear();
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        if (studentCount >= students.Length)
        {
            Console.WriteLine("Массив учеников заполнен.");
            return;
        }

        Console.Write("Введите ФИО: ");
        string fullName = Console.ReadLine();
        Console.Write("Введите год рождения: ");
        int birthYear = int.Parse(Console.ReadLine());
        Console.Write("Введите ФИО мамы (оставьте пустым, если не заполняется): ");
        string motherName = Console.ReadLine();
        Console.Write("Введите ФИО папы (оставьте пустым, если не заполняется): ");
        string fatherName = Console.ReadLine();
        Console.Write("Введите адрес: ");
        string address = Console.ReadLine();

        students[studentCount] = new Student(fullName, birthYear, motherName, fatherName, address);
        studentCount++;
        Console.WriteLine("Ученик добавлен.");
    }

    static void ModifyStudent()
    {
        if (IsFull())
        {
            Console.Write("Введите ФИО ученика для модификации: ");
            string fullName = Console.ReadLine();
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].FullName == fullName)
                {
                    Console.Write("Введите новое ФИО: ");
                    students[i].FullName = Console.ReadLine();
                    Console.Write("Введите новый год рождения: ");
                    students[i].BirthYear = int.Parse(Console.ReadLine());
                    Console.Write("Введите новое ФИО мамы: ");
                    students[i].MotherName = Console.ReadLine();
                    Console.Write("Введите новое ФИО папы: ");
                    students[i].FatherName = Console.ReadLine();
                    Console.Write("Введите новый адрес: ");
                    students[i].Address = Console.ReadLine();
                    Console.WriteLine("Данные ученика модифицированы.");
                    return;
                }
            }
            Console.WriteLine("Ученик с таким ФИО не найден.");
        }
        else
        {
            Console.WriteLine("Массив не полностью заполнен. Редактирование невозможно.");
            return;
        }
    }

    static bool IsFull()
    {
        return studentCount == students.Length;
    }

    static void SearchByFirstLetter()
    {
        Console.Write("Введите первую букву имени: ");
        char firstLetter = Console.ReadLine()[0];
        bool found = false;
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].FullName.StartsWith(firstLetter.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(students[i].FullName);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Учеников с такой буквой не найдено.");
        }
    }

    static void SearchByStreet()
    {
        Console.Write("Введите название улицы: ");
        string street = Console.ReadLine();
        bool found = false;
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].Address.Contains(street, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(students[i].FullName);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Учеников, проживающих на этой улице, не найдено.");
        }
    }

    static void SearchByBirthYear()
    {
        Console.Write("Введите год рождения для выборки: ");
        int year = int.Parse(Console.ReadLine());
        bool found = false;
        for (int i = 0; i < studentCount; i++)
        {
            if (students[i].BirthYear == year)
            {
                Console.WriteLine(students[i].FullName);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Учеников с этим годом рождения не найдено.");
        }
    }
}
