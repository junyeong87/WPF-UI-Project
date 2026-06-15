using Pratice.Services;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging.Abstractions;
using Pratice.Models;

namespace Pratice.ViewModels.Pages
{
    public partial class DashboardViewModel : ObservableObject
    {


        private readonly SensorService _sensorService;
        private readonly JsonService _jsonService;

        private readonly DispatcherTimer _timer;

        public DashboardViewModel(SensorService sensorService, JsonService jsonService) 
        {
            _sensorService = sensorService;
            _jsonService = jsonService;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);

            _timer.Tick += (_, _) =>
            {
                Temperature = _sensorService.GetTemperature();
                Pressure = _sensorService.GetPressure();
            };
        }







        [ObservableProperty]
        private int _counter = 0;

        [ObservableProperty]
        private string _currentDate;

        [ObservableProperty]
        private bool _deviceRun;
        
        [ObservableProperty]
        private bool _deviceEmergency;

        [ObservableProperty]
        private int _temperature;

        [ObservableProperty]
        private int _pressure;



        [ObservableProperty]
        private ObservableCollection<LogEntry> _logs = new ObservableCollection<LogEntry>();




        public string DeviceStatus
        {
            get { 
                if (DeviceEmergency)
                    return "Emergency";
                else
                    return DeviceRun ? "ON" : "OFF";
            }
        }

        partial void OnDeviceRunChanged(bool value)
        {
            OnPropertyChanged(nameof(DeviceStatus));
        }

        partial void OnDeviceEmergencyChanged(bool value)
        {
            OnPropertyChanged(nameof(DeviceStatus));
            OnPropertyChanged(nameof(CanStart));
            OnPropertyChanged(nameof(CanReset));
        }

        public bool CanStart => !DeviceEmergency;
        public bool CanReset => DeviceEmergency;


        [RelayCommand]
        private void UpdateDate()
        {
            CurrentDate = DateTime.Now.ToString();
        }

        [RelayCommand]
        private void DeviceOn() { 

            if(DeviceEmergency)
                return;

            DeviceRun = true;
            _timer.Start();

            Logs.Add(new LogEntry
            {
                Time = DateTime.Now,
                Type = "INFO",
                Message = "장비 시작",
                Temperature = Temperature,
                Pressure = Pressure
            });


///            Logs.Add($"{DateTime.Now:HH:mm:ss}: 장비 시작");
        }

        [RelayCommand]
        private void DeviceOff()
        {
            DeviceRun = false;
            _timer.Stop();


            Logs.Add(new LogEntry
            {
                Time = DateTime.Now,
                Type = "STOP",
                Message = "장비 정지",
                Temperature = Temperature,
                Pressure = Pressure
            });
            ///            Logs.Add("-------------------------------------");
            ///            Logs.Add($"{DateTime.Now:HH:mm:ss}: 장비 정지");
            ///            Logs.Add($"온도 = {Temperature}℃   ");
            ///            Logs.Add($"압력 = {Pressure}");
        }

        [RelayCommand]

        private void Emergency()
        {
            DeviceEmergency = true;
            DeviceRun = false;
            _timer.Stop();


            Logs.Add(new LogEntry
            {
                Time = DateTime.Now,
                Type = "ERROR",
                Message = "비상 정지",
                Temperature = Temperature,
                Pressure = Pressure
            });
            ///            Logs.Add("-------------------------------------");
            ///            Logs.Add($"{DateTime.Now:HH:mm:ss}: 비상 정지");
            ///            Logs.Add($"{Temperature}℃");
            ///            Logs.Add($"{Pressure}");
        }

        [RelayCommand]
        private void ResetStatus()
        {
            DeviceEmergency = false;
            DeviceRun = false;
            Temperature = 0;
            Pressure = 0;


            Logs.Add(new LogEntry
            {
                Time = DateTime.Now,
                Type = "RESET",
                Message = "초기화",
                Temperature = Temperature,
                Pressure = Pressure
            });
            ///            Logs.Add("-------------------------------------");
            ///            Logs.Add($"{DateTime.Now:HH:mm:ss}: 리셋");
        }


        [RelayCommand]
        private void SaveLogs()
        {
            _jsonService.SaveLogs(Logs);
        }

    }
}
