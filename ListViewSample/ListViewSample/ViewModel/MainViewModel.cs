using GalaSoft.MvvmLight;
using ListViewSample.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Input;

namespace ListViewSample.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Variables declaration
        /// </summary>
        /// 
        private ObservableCollection<EquationParametersViewModel> _equationList;
        private ICommand _addRow;
        private ICommand _deleteRow;
        private ICommand _calculate;
        private int _lastIndex;
        private const double GRAVITATION_CONSTANT = 6.67e-11;
        private bool flag = false;

        /// <summary>
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 
        public ICommand AddRow
        {
            get
            {
                return _addRow;
            }
            set
            {
                _addRow = value;
                RaisePropertyChanged("AddRow");
            }
        }

        public ICommand DeleteRow
        {
            get
            {
                return _deleteRow;
            }
            set
            {
                _deleteRow = value;
                RaisePropertyChanged("DeleteRow");
            }
        }

        public ICommand Calculate
        {
            get
            {
                return _calculate;
            }
            set
            {
                _calculate = value;
                RaisePropertyChanged("Calculate");
            }
        }

        public int LastIndex
        {
            get
            {
                return _lastIndex;
            }
            set
            {
                _lastIndex = value;
                RaisePropertyChanged("LastIndex");
            }
        }

        public ObservableCollection<EquationParametersViewModel> EquationList
        {
            get
            {
                return _equationList;
            }
            set
            {
                _equationList = value;
                RaisePropertyChanged("EquationList");
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            LastIndex = 0;
            EquationList = new ObservableCollection<EquationParametersViewModel>();
            while (LastIndex < 3)
            {
                EquationParametersViewModel equation = new EquationParametersViewModel(LastIndex + 1);
                equation.R = 1;
                EquationList.Add(equation);
                LastIndex++;
            }
            LastIndex--;
            populateButtons();
        }

        /// <summary>
        /// Helper functions.
        /// </summary>
        /// 
        private void populateButtons()
        {
            AddRow = new RelayCommand(addRowMethod);
            DeleteRow = new RelayCommand(deleteRowMethod);
            Calculate = new RelayCommand(calculateMethod);
        }

        private void addRowMethod(object sender)
        {
            LastIndex++;
            EquationParametersViewModel newEquation = new EquationParametersViewModel(LastIndex + 1);
            newEquation.R = 1;
            EquationList.Add(newEquation);
        }

        private void deleteRowMethod(object sender)
        {
            if (LastIndex != 0)
            {
                EquationList.RemoveAt(LastIndex);
                LastIndex--;
            }
        }

        private void calculateMethod(object sender)
        {
            for (int i = 0; i < EquationList.Count; i++)
            {
                EquationParametersViewModel currentEquation = EquationList[i];
                currentEquation.Result = (GRAVITATION_CONSTANT * currentEquation.M1 * currentEquation.M2) / Math.Pow(currentEquation.R, 2);
            }
        }

        public void TextBox_OnlyNonNegativeDoubleValid(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            int cIndex = textBox.CaretIndex;
            int selectionLength = textBox.SelectionLength;

            string text = textBox.Text;
            string a, b, c;
            a = text.Substring(0, cIndex);                  // get the first part of string up to insertion point
            b = text.Substring(cIndex, selectionLength);    // get the selected part
            c = text.Substring(cIndex + selectionLength);   // get the remainder
            string newtext = a + e.Text + c;                // replace selection with typed text

            if (e.Text.Equals("e"))
            {
                flag = true;
            }

            double d;
            if (!(((a.Length > 0) && (e.Text.Equals("e"))) || (e.Text.Equals("-") && flag)))
            {
                flag = false;
                if ((!double.TryParse(newtext, out d)) && (!double.TryParse(newtext, System.Globalization.NumberStyles.AllowExponent, CultureInfo.CurrentCulture, out d)))
                {
                    e.Handled = true;                       // cancel the event
                }
            }
        }

        public void TextBox_OnlyNonZeroDoubleValid(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            int cIndex = textBox.CaretIndex;
            int selectionLength = textBox.SelectionLength;

            string text = textBox.Text;
            string a, b, c;
            a = text.Substring(0, cIndex);                  // get the first part of string up to insertion point
            b = text.Substring(cIndex, selectionLength);    // get the selected part
            c = text.Substring(cIndex + selectionLength);   // get the remainder
            string newtext = a + e.Text + c;                // replace selection with typed text

            double d;
            if (!(((a.Length > 0) && (e.Text.Equals("e"))) || (e.Text.Equals("-") && flag) || (newtext == "-")))
            {
                if ((!double.TryParse(newtext, out d)) || (Convert.ToDouble(newtext) == 0))
                {
                    e.Handled = true;                       // cancel the event
                }
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}