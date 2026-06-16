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
                Logs.Add(new LogEntry
                {
                    Time = DateTime.Now,
                    Temperature = _sensorService.GetTemperature(),
                    Pressure = _sensorService.GetPressure(),
                    Type = "RUN",
                    Message = "센서 데이터"
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
