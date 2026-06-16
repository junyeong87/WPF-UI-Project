using System.Collections.ObjectModel;
using System.Windows.Media;
using Pratice.Models;
using Wpf.Ui.Abstractions.Controls;
using Pratice.Services;
using System.Windows.Threading;


namespace Pratice.ViewModels.Pages
{


    public partial class DataViewModel : ObservableObject, INavigationAware
    {

        private readonly SensorService _sensorService;
        private readonly DispatcherTimer _timer;



        [ObservableProperty]
        private ObservableCollection<LogEntry> _logs = new ObservableCollection<LogEntry>();






        public DataViewModel(SensorService sensorService)
        {
            _sensorService = sensorService;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);

            _timer.Tick += (_, _) =>
            {

                int temperature = _sensorService.GetTemperature();
                int pressure = _sensorService.GetPressure();

                string type = "RUN";
                string message = "정상";

                if (temperature >= 45 && pressure >= 1250)
                {
                    type = "ERROR";
                    message = "온도 및 압력 이상";
                }
                else if (temperature >= 45)
                {
                    type = "WARNING";
                    message = "온도 이상";
                }
                else if (pressure >= 1250)
                {
                    type = "WARNING";
                    message = "압력 이상";
                }







                Logs.Add(new LogEntry
                {
                    Time = DateTime.Now,
                    Temperature = temperature,
                    Pressure = pressure,
                    Type = type,
                    Message = message
                });

                // 너무 많이 쌓이는 걸 방지 (선택사항)
                if (Logs.Count > 1000)
                    Logs.RemoveAt(0);
            };
        }




        public Task OnNavigatedToAsync()
        {
            _timer.Start();
            return Task.CompletedTask;
        }


        public Task OnNavigatedFromAsync()
        {
            _timer.Stop();
            return Task.CompletedTask;
        }


    }
}
