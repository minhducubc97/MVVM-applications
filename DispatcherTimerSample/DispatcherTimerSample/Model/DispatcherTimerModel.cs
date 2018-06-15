using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DispatcherTimerSample.Model
{
    class DispatcherTimerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private string _dateTimeValue;
        public string DateTimeValue
        {
            get { return _dateTimeValue; }
            set
            {
                _dateTimeValue = value;
                OnPropertyChanged(nameof(DateTimeValue));
            }
        }
    }
}
