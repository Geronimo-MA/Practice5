using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudVidApp
{
    public class Televisor : AudVidTech
    {
        private double screenSize;
        public double ScreenSize
        {
            get => screenSize;
            set => screenSize = ValidateScreenSize(value);
        }

        public string ScreenResolution { get; set; }
        public string TypeOfMatrix { get; set; }

        private int ramSize;
        public int RamSize
        {
            get => ramSize;
            set => ramSize = ValidateRamSize(value);
        }

        public Televisor(string model = "Unknown", string manufacturer = "Unknown", double price = 0.0, int year = 2000,
                         double screenSize = 40.0, string screenResolution = "3840x2160", string typeOfMatrix = "LED", int ramSize = 2)
            : base(model, manufacturer, price, year)
        {
            ScreenSize = screenSize;
            ScreenResolution = screenResolution;
            TypeOfMatrix = typeOfMatrix;
            RamSize = ramSize;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Размер экрана: {ScreenSize} дюймов, Разрешение экрана: {ScreenResolution}, Тип матрицы: {TypeOfMatrix}, Оперативная память: {RamSize} GB");
        }

        private double ValidateScreenSize(double value)
        {
            if (value <= 0) throw new ArgumentException("Размер экрана должен быть положительным.");
            return value;
        }

        private int ValidateRamSize(int value)
        {
            if (value <= 0) throw new ArgumentException("Оперативная память должна быть положительной.");
            return value;
        }
        public override string Description => $"{base.Description} ({GetType().Name})";

    }

}
