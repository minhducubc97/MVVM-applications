using GalaSoft.MvvmLight;
using System.Windows.Input;
using TabControl.Model;

namespace TabControl.ViewModel
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
        private ICommand _nextButton;
        private ICommand _backButton;
        private int _mainTabSelectedIndex;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ICommand NextButton
        {
            get
            {
                return _nextButton;
            }
            set
            {
                _nextButton = value;
            }
        }

        public ICommand BackButton
        {
            get
            {
                return _backButton;
            }
            set
            {
                _backButton = value;
            }
        }

        public int MainTabSelectedIndex
        {
            get
            {
                return _mainTabSelectedIndex;
            }
            set
            {
                _mainTabSelectedIndex = value;
                this.RaisePropertyChanged("MainTabSelectedIndex");
            }
        }

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

                    NextButton = new RelayCommand(nextTab);
                    BackButton = new RelayCommand(previousTab);
                });
        }

        /// <summary>
        /// Move to next tab
        /// </summary>
        public void nextTab(object sender)
        {
            if (MainTabSelectedIndex != 2)
            {
                MainTabSelectedIndex++;
            }
        }

        /// <summary>
        /// Move back to previous tab
        /// </summary>
        public void previousTab(object sender)
        {
            if (MainTabSelectedIndex != 0)
            {
                MainTabSelectedIndex--;
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}