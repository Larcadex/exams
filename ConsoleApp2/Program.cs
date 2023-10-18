using System;

class program
{
    static void Main()
    {
        double[,] data = {
            { 40, 5 },
            { 100, 50 },
            { 60, 200 }
        };

        bool a = true;

        while (a)
        {
            Console.WriteLine("Выберите транспортное средство: \n1 - мопед \n2 - машина \n3 - автобус");
            int avto_type = 0;

            ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

            switch (keyInfo1.Key)
            {
                case ConsoleKey.D1:
                    avto_type = 1;
                    break;
                case ConsoleKey.D2:
                    avto_type = 2;
                    break;
                case ConsoleKey.D3:
                    avto_type = 3;
                    break;

            }
            Console.WriteLine();

            double distance = 0;

            Console.WriteLine("Выберите маршрут: \n1 - 100 км \n2 - 200 км \n3 - 300 км");
            ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);

            switch (keyInfo2.Key)
            {
                case ConsoleKey.D1:
                    distance = 100;
                    break;
                case ConsoleKey.D2:
                    distance = 200;
                    break;
                case ConsoleKey.D3:
                    distance = 300;
                    break;
            }
            Console.WriteLine();

            double speed = data[avto_type - 1, 0]; 
            double bak_size = data[avto_type - 1, 1];  

            double fuel_per_km = 0;

            if (speed > 0 && speed < 50)
            {
                fuel_per_km = 0.05;
            }
            else if (speed > 50 && speed < 90)
            {
                fuel_per_km = 0.1;
            }
            else
            {
                fuel_per_km = 0.2;
            }

            double fuel_required = calculate_fuel_required(distance, speed, fuel_per_km);
            double max_distance = calculate_max_distance(bak_size, fuel_per_km);

            Console.WriteLine($"Для преодоления маршрута в {distance} км на {get_name(avto_type)} со скоростью {speed} км/ч потребуется {fuel_required:F2} литров топлива.");

            if (distance <= max_distance)
            {
                Console.WriteLine($"Транспортное средство сможет преодолеть весь маршрут на одном баке.");
            }
            else
            {
                Console.WriteLine($"Транспортное средство не сможет преодолеть расстояние в  {distance} км на одном баке. Одного бака хвататит на {max_distance:F2} км.");
            }

            Console.WriteLine("\nЖелаете запустить программу заново?: \n1 - да \n2 - нет");
            ConsoleKeyInfo keyInfo3 = Console.ReadKey(true);

            if (keyInfo3.Key == ConsoleKey.D2)
            {
                a = false;
            }
            Console.Clear();
        }
    }

    static double calculate_fuel_required(double distance, double speed, double fuel_per_km)
    {
        double fuel_required = distance * fuel_per_km;
        return fuel_required;
    }

    static double calculate_max_distance(double bak_size, double fuel_per_km)
    {
        double max_distance = bak_size / fuel_per_km;
        return max_distance;
    }

    static string get_name(int avto_type)
    {
        switch (avto_type)
        {
            case 1:
                return "мопеде";
            case 2:
                return "машине";
            case 3:
                return "автобусе";
            default:
                return "неизвестный тип";
        }
    }
}
