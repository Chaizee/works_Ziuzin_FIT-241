using System;
using static System.Collections.Specialized.BitVector32;
using System.Reflection;

using System;

public class Train
{
    public int TrainNumber { get; set; }
    public string DepartureStation { get; set; }
    public string DestinationStation { get; set; }
    public DateTime DepartureTime { get; set; }

    public Train(int number, string stationName, string appointment, DateTime time)
    {
        TrainNumber = number;
        DepartureStation = stationName;
        DestinationStation = appointment;
        DepartureTime = time;
    }
    public override string ToString()
    {
        return $"Номер поезда: {TrainNumber}, Пункт отправления: {DepartureStation}, Пункт назначения: {DestinationStation}, Время отправления: {DepartureTime}";
    }
}

public class Station
{
    public string StationName { get; set; }
    public Train[] Trains { get; set; }

    public Station(string stationName, int numberOfTrains)
    {
        StationName = stationName;
        Trains = new Train[numberOfTrains];
    }

    public void AddTrain(Train train)
    {
        for (int i = 0; i < Trains.Length; i++)
        {
            if (Trains[i] == null)
            {
                Trains[i] = train;
                return;
            }
        }
        Console.WriteLine("Массив поездов полностью заполнен.");
    }

    public void PrintTrainsToDestination(string dest)
    {
        var trains = Trains.Where(t => t != null && t.DestinationStation == dest);
        foreach (var train in trains)
        {
            Console.WriteLine(train);
        }
    }

    public void PrintTrainsAfterTime(DateTime time)
    {
        var trains = Trains.Where(t => t != null && t.DepartureTime > time);
        foreach (var train in trains)
        {
            Console.WriteLine(train);
        }
    }

    public bool IsFull()
    {
        return Trains.All(t => t != null);
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите название станции: ");
        string stationName = Console.ReadLine();
        Console.Write("Введите количество поездов: ");
        int numberOfTrains = int.Parse(Console.ReadLine());

        Station station = new Station(stationName, numberOfTrains);
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввод данных о поезде");
            Console.WriteLine("2. Информация о поездах по пункту назначения");
            Console.WriteLine("3. Информация о поездах по времени отправления");
            Console.WriteLine("4. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    if (station.IsFull())
                    {
                        Console.WriteLine("Массив заполнен");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите номер поезда:");
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите пункт назначения:");
                        string appointment = Console.ReadLine();
                        Console.WriteLine("Введите время отправления (формат: ГГГГ-ММ-ДД ЧЧ:ММ:СС):");
                        DateTime time = DateTime.Parse(Console.ReadLine());
                        Train newTrain = new Train(number, stationName, appointment, time);
                        station.AddTrain(newTrain);
                        break;
                    }

                case 2:
                    if (station.IsFull())
                    {
                        Console.Write("Введите пункт назначения: ");
                        string dest = Console.ReadLine();
                        station.PrintTrainsToDestination(dest);
                    }
                    else
                    {
                        Console.WriteLine("Массив не полностью заполнен.");
                    }
                    break;

                case 3:
                    if (station.IsFull())
                    {
                        Console.WriteLine("Введите время отправления (формат: ГГГГ-ММ-ДД ЧЧ:ММ:СС):");
                        DateTime time2 = DateTime.Parse(Console.ReadLine());
                        station.PrintTrainsAfterTime(time2);
                    }
                    else
                    {
                        Console.WriteLine("Массив не полностью заполнен.");
                    }
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Неверно выбран пункт.");
                    break;
            }
        }
    }
}
