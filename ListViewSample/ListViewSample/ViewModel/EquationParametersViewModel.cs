using ListViewSample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewSample.ViewModel
{
    public class EquationParametersViewModel : EquationParameters, INotifyPropertyChanged
    {
        // Property changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// 
        public EquationParametersViewModel(int id) : base(id)
        {
            this.Id = id;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public double M1
        {
            get
            {
                return _m1;
            }
            set
            {
                _m1 = value;
                OnPropertyChanged("M1");
            }
        }

        public double M2
        {
            get
            {
                return _m2;
            }
            set
            {
                _m2 = value;
                OnPropertyChanged("M2");
            }
        }

        public double R
        {
            get
            {
                return _r;
            }
            set
            {
                _r = value;
                OnPropertyChanged("R");
            }
        }

        public double Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
    }
}
