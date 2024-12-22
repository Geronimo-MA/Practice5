using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudVidApp

{
    public class AudVidTech
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }

        private double price;
        public double Price
        {
            get => price;
            set => price = ValidatePrice(value);
        }

        private int year;
        public int Year
        {
            get => year;
            set => year = ValidateYear(value);
        }

        public AudVidTech(string model = "Unknown", string manufacturer = "Unknown", double price = 0.0, int year = 2000)
        {
            Model = model;
            Manufacturer = manufacturer;
            Price = price;
            Year = year;
        }
        public override string ToString()
        {
            return Model;  // Возвращаем только название модели
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Модель: {Model}, Производитель: {Manufacturer}, Цена: {Price} USD, Год: {Year}");
        }

        private double ValidatePrice(double value)
        {
            if (value < 0) throw new ArgumentException("Цена не может быть отрицательной.");
            return value;
        }

        private int ValidateYear(int value)
        {
            int currentYear = DateTime.Now.Year;
            if (value < 1960 || value > currentYear)
                throw new ArgumentException($"Год должен варьироваться между 1960 и {currentYear}.");
            return value;
        }
        public virtual string Description => $"{Model} by {Manufacturer} - ${Price}";

    }
}
