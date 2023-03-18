using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса парковка
            Parking parking = new Parking();

            // Открываем главное меню
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить автомобиль");
                Console.WriteLine("2. Вывести список автомобилей на парковке");
                Console.WriteLine("3. Выезд автомобиля");
                Console.WriteLine("4. Выход из программы");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите марку автомобиля:");
                        string brand = Console.ReadLine();

                        Console.WriteLine("Введите модель автомобиля:");
                        string model = Console.ReadLine();

                        Console.WriteLine("Введите цвет автомобиля:");
                        string color = Console.ReadLine();

                        Console.WriteLine("Введите номер автомобиля:");
                        string number = Console.ReadLine();

                        Console.WriteLine("Введите время прибытия автомобиля (в формате ЧЧ:ММ):");
                        string timeString = Console.ReadLine();
                        DateTime time = DateTime.ParseExact(timeString, "HH:mm", null);

                        Car car = new Car(brand, model, color, number, time);
                        parking.AddCar(car);

                        Console.WriteLine("Автомобиль успешно добавлен на парковку.");
                        break;

                    case "2":
                        List<Car> cars = parking.GetCars();

                        if (cars.Count == 0)
                        {
                            Console.WriteLine("На парковке нет автомобилей.");
                        }
                        else
                        {
                            Console.WriteLine("Список автомобилей на парковке:");
                            Console.WriteLine("--------------------------------");

                            foreach (Car c in cars)
                            {
                                Console.WriteLine(c);
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("Введите номер автомобиля, который хотите вывезти:");
                        string numberToLeave = Console.ReadLine();
                        bool success = parking.LeaveCar(numberToLeave);

                        if (success)
                        {
                            Console.WriteLine("Автомобиль успешно выезжает с парковки.");
                        }
                        else
                        {
                            Console.WriteLine("Автомобиль с таким номером не найден на парковке.");
                        }
                        break;

                    case "4":
                        // Сохраняем данные в файлы перед выходом из программы
                        parking.SaveCarsToFile();

                        Console.WriteLine("Программа завершена.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}