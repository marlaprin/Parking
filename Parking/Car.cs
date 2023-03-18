using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string Number { get; set; }
        public DateTime Time { get; set; }

        public Car(string brand, string model, string color, string number, DateTime time)
        {
            Brand = brand;
            Model = model;
            Color = color;
            Number = number;
            Time = time;
        }

        public override string ToString()
        {
            return $"Марка: {Brand}, Модель: {Model}, Цвет: {Color}, Номер: {Number}, Время прибытия: {Time.ToString("HH:mm")}";
        }
    }
}
