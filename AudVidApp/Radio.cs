using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudVidApp
{
    public class Radio : AudVidTech
    {
        private double numberOfPresets;
        public double NumberOfPresets
        {
            get => numberOfPresets;
            set => numberOfPresets = ValidateNumberOfPresets(value);
        }

        private int batteryCapacity;
        public int BatteryCapacity
        {
            get => batteryCapacity;
            set => batteryCapacity = ValidateBatteryCapacity(value);
        }

        public Radio(string model = "Unknown", string manufacturer = "Unknown", double price = 0.0, int year = 2000,
                     double numberOfPresets = 4, int batteryCapacity = 2000)
            : base(model, manufacturer, price, year)
        {
            NumberOfPresets = numberOfPresets;
            BatteryCapacity = batteryCapacity;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Количество предустановок: {NumberOfPresets}, Емкость аккумулятора: {BatteryCapacity} mAh");
        }

        private double ValidateNumberOfPresets(double value)
        {
            if (value <= 0) throw new ArgumentException("Количество предустановок должно быть положительным.");
            return value;
        }

        private int ValidateBatteryCapacity(int value)
        {
            if (value <= 0) throw new ArgumentException("Емкость аккумулятора должна быть положительной.");
            return value;
        }
        public override string Description => $"{base.Description} ({GetType().Name})";

    }

}
