using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace AudVidApp
{
    public partial class MainWindow : Window
    {
        private const string DataFilePath = "devices.json";
        private List<AudVidTech> devices = new List<AudVidTech>();


        public MainWindow()
        {
            InitializeComponent();
            LoadDevices();
            UpdateDeviceList();
        }

        private void AddTv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string model = TvModelTextBox.Text;
                string manufacturer = TvManufacturerTextBox.Text;
                double price = ParseDouble(TvPriceTextBox.Text, "цена");
                int year = ParseInt(TvYearTextBox.Text, "год");
                int screenSize = ParseInt(TvScreenSizeTextBox.Text, "размер экрана");
                string resolution = TvResolutionTextBox.Text;
                string matrixType = ValidateMatrixType(TvMatrixTypeTextBox.Text);  // Проверка типа матрицы
                int ram = ParseInt(TvRamTextBox.Text, "ОЗУ");

                var tv = new Televisor(model, manufacturer, price, year, screenSize, resolution, matrixType, ram);
                devices.Add(tv);
                SaveDevices();
                UpdateDeviceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private string ValidateMatrixType(string matrixType)
        {
            string[] validMatrixTypes = { "PDP", "LCD", "OLED", "QLED" };

            if (Array.Exists(validMatrixTypes, type => type.Equals(matrixType, StringComparison.OrdinalIgnoreCase)))
            {
                return matrixType;
            }
            else
            {
                throw new FormatException("Матрица может быть только одного из типов: PDP, LCD, OLED, QLED.");
            }
        }

        private void AddRadio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string model = RadioModelTextBox.Text;
                string manufacturer = RadioManufacturerTextBox.Text;
                double price = ParseDouble(RadioPriceTextBox.Text, "цена");
                int year = ParseInt(RadioYearTextBox.Text, "год");
                int presets = ParseInt(RadioPresetsTextBox.Text, "предустановки");
                int battery = ParseInt(RadioBatteryTextBox.Text, "емкость аккумулятора");

                var radio = new Radio(model, manufacturer, price, year, presets, battery);
                devices.Add(radio);
                SaveDevices();
                UpdateDeviceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddOther_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string model = OtherModelTextBox.Text;
                string manufacturer = OtherManufacturerTextBox.Text;
                double price = ParseDouble(OtherPriceTextBox.Text, "цена");
                int year = ParseInt(OtherYearTextBox.Text, "год");

                var other = new AudVidTech(model, manufacturer, price, year);
                devices.Add(other);
                SaveDevices();
                UpdateDeviceList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveSelected_Click(object sender, RoutedEventArgs e)
        {
            if (DevicesListBox.SelectedItem is AudVidTech selectedDevice)
            {
                devices.Remove(selectedDevice);
                SaveDevices();
                UpdateDeviceList();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите устройство для удаления.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void UpdateDeviceList()
        {
            DevicesListBox.ItemsSource = null;
            DevicesListBox.ItemsSource = devices;
        }

        private void SaveDevices()
        {
            string json = JsonSerializer.Serialize(devices, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(DataFilePath, json);
        }

        private void LoadDevices()
        {
            if (File.Exists(DataFilePath))
            {
                string json = File.ReadAllText(DataFilePath);
                devices = JsonSerializer.Deserialize<List<AudVidTech>>(json) ?? new List<AudVidTech>();
            }
        }

        private double ParseDouble(string input, string fieldName)
        {
            if (!double.TryParse(input, out double result))
                throw new FormatException($"Поле '{fieldName}' должно быть числом.");
            return result;
        }

        private int ParseInt(string input, string fieldName)
        {
            if (!int.TryParse(input, out int result))
                throw new FormatException($"Поле '{fieldName}' должно быть целым числом.");
            return result;
        }

    }

}

