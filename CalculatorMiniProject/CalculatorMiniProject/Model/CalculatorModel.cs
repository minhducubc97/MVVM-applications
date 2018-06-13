using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CalculatorMiniProject.Model
{
    public class CalculatorModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private int firstNumber;
        private int secondNumber;

        public int FirstNumber
        {
            get
            {
                return firstNumber;
            }

            set
            {
                if (firstNumber != value)
                {
                    firstNumber = value;
                    OnPropertyChanged(nameof(FirstNumber));
                    OnPropertyChanged(nameof(Sum));
                }
            }
        }

        public int SecondNumber
        {
            get
            {
                return secondNumber;
            }
            
            set
            {
                if (secondNumber != value)
                {
                    secondNumber = value;
                    OnPropertyChanged(nameof(SecondNumber));
                    OnPropertyChanged(nameof(Sum));
                }
            }
        }

        public int Sum
        {
            get
            {
                return firstNumber + secondNumber;
            }
        }
    }
}
