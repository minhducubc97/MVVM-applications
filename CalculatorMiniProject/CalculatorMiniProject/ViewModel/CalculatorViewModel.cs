using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CalculatorMiniProject.Model;


namespace CalculatorMiniProject.ViewModel
{
    public class CalculatorViewModel
    {
        public ObservableCollection<CalculatorModel> CalculatorModels
        {
            get;
            set;
        }

        public void loadModels()
        {
            ObservableCollection<CalculatorModel> calculatorModels = new ObservableCollection<CalculatorModel>();

            calculatorModels.Add(new CalculatorModel { FirstNumber = 1, SecondNumber = 2 });

            CalculatorModels = calculatorModels;
        }
    }
}
