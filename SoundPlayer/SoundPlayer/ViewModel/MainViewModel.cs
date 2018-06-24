using GalaSoft.MvvmLight;
using SoundPlayer.Model;
using System.Media;
using System.Windows.Input;

namespace SoundPlayer.ViewModel
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
        /// Variables declaration
        /// </summary>
        private ICommand _exclamation;
        private ICommand _hand;
        private ICommand _question;
        private ICommand _beep;
        private ICommand _asterisk;
        /// <summary>
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ICommand Exclamation
        {
            get
            {
                return _exclamation;
            }
            set
            {
                _exclamation = value;
                RaisePropertyChanged("Exclamation");
            }
        }

        public ICommand Hand
        {
            get
            {
                return _hand;
            }
            set
            {
                _hand = value;
                RaisePropertyChanged("Hand");
            }
        }

        public ICommand Question
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
                RaisePropertyChanged("Question");
            }
        }

        public ICommand Beep
        {
            get
            {
                return _beep;
            }
            set
            {
                _beep = value;
                RaisePropertyChanged("Beep");
            }
        }

        public ICommand Asterisk
        {
            get
            {
                return _asterisk;
            }
            set
            {
                _asterisk = value;
                RaisePropertyChanged("Asterisk");
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
                    Exclamation = new RelayCommand(Exclamation_Click);
                    Hand = new RelayCommand(Hand_Click);
                    Question = new RelayCommand(Question_Click);
                    Beep = new RelayCommand(Beep_Click);
                    Asterisk = new RelayCommand(Asterisk_Click);
                });
        }

        /// <summary>
        /// Call to SystemSounds
        /// </summary>
        /// 
        private void Exclamation_Click(object sender)
        {
            SystemSounds.Exclamation.Play();
        }

        private void Hand_Click(object sender)
        {
            SystemSounds.Hand.Play();
        }

        private void Question_Click(object sender)
        {
            SystemSounds.Question.Play();
        }

        private void Beep_Click(object sender)
        {
            SystemSounds.Beep.Play();
        }

        private void Asterisk_Click(object sender)
        {
            SystemSounds.Asterisk.Play();
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}