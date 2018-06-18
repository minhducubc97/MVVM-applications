using GalaSoft.MvvmLight;
using CustomCommand.Model;
using System.Windows.Input;
using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace CustomCommand.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand;
        private bool canExecute = true;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string HiButtonContent
        {
            get
            {
                return "Click to see something cool!";
            }
        }   
        
        public bool CanExecute
        {
            get
            {
                return this.canExecute;
            }
            set
            {
                if (this.canExecute != value)
                {
                    this.canExecute = value;
                }
            }
        }

        public ICommand ToggleExecuteCommand
        {
            get
            {
                return toggleExecuteCommand;
            }
            set
            {
                toggleExecuteCommand = value;
            }
        }

        public ICommand HiButtonCommand
        {
            get
            {
                return hiButtonCommand;
            }
            set
            {
                hiButtonCommand = value;
            }
        }

        public RelayCommand<Window> Close { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }
                });

            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            ToggleExecuteCommand = new RelayCommand(ChangeCanExecute);
            Close = new RelayCommand<Window>(this.closeWindow);
        }

        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }

        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }

        public void closeWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}