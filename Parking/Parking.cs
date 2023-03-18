using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class Parking
    {
        private List<Car> cars; // Список автомобилей на парковке
        private string fileName; // Имя файла для сохранения данных

        public Parking()
        {
            cars = new List<Car>();
            fileName = "parking.txt";

            // Если файл с данными существует, то загружаем данные из него
            if (File.Exists(fileName))
            {
                LoadCarsFromFile();
            }
        }

        // Добавить автомобиль на парковку
        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        // Получить список автомобилей на парковке
        public List<Car> GetCars()
        {
            return cars;
        }

        // Убрать автомобиль с парковки по номеру
        public bool LeaveCar(string number)
        {
            foreach (Car car in cars)
            {
                if (car.Number == number)
                {
                    cars.Remove(car);
                    return true;
                }
            }

            return false;
        }

        // Сохранить данные об автомобилях на парковке в файл
        public void SaveCarsToFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Car car in cars)
                {
                    writer.WriteLine($"{car.Brand},{car.Model},{car.Color},{car.Number},{car.Time.ToString("HH:mm")}");
                }
            }
        }

        // Загрузить данные об автомобилях на парковке из файла
        private void LoadCarsFromFile()
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(',');

                    string brand = parts[0];
                    string model = parts[1];
                    string color = parts[2];
                    string number = parts[3];
                    DateTime time = DateTime.ParseExact(parts[4], "HH:mm", null);

                    Car car = new Car(brand, model, color, number, time);
                    cars.Add(car);
                }
            }
        }
    }
}
