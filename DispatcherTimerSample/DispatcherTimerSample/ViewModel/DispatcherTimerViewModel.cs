using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Threading;
using DispatcherTimerSample.Model;

namespace DispatcherTimerSample.ViewModel
{
    public class DispatcherTimerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        DispatcherTimerModel dispatcherTimerModel;

        public string DateTimeValue
        {
            get { return dispatcherTimerModel.DateTimeValue; }
            set
            {
                dispatcherTimerModel.DateTimeValue = value;
                OnPropertyChanged(nameof(DateTimeValue));
            }
        }
        public DispatcherTimerViewModel()
        {
            dispatcherTimerModel = new DispatcherTimerModel {
                DateTimeValue = DateTime.Now.ToString("HH:mm:ss.fff")
            };
            createDispatcherTimer();
        }

        public void createDispatcherTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTimeValue = DateTime.Now.ToString("HH:mm:ss.fff");
        }
    }
}
