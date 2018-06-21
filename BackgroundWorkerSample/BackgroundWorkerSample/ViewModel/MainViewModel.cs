using GalaSoft.MvvmLight;
using BackgroundWorkerSample.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;

namespace BackgroundWorkerSample.ViewModel
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
        BackgroundWorker _backgroundWorker;
        private string _status;
        private string _textColor;
        private string _instruction = "Click Start button to begin.";
        private bool _startEnable = true;
        private ICommand _startBackgroundWorker;
        private int _progress;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                this.RaisePropertyChanged("Status");
            }
        }

        public string TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                this.RaisePropertyChanged("TextColor");
            }
        }

        public string Instruction
        {
            get
            {
                return _instruction;
            }
            set
            {
                _instruction = value;
                this.RaisePropertyChanged("Instruction");
            }
        }

        public bool StartEnable
        {
            get
            {
                return _startEnable;
            }
            set
            {
                _startEnable = value;
                this.RaisePropertyChanged("StartEnable");
            }
        }

        public ICommand StartBackgroundWorker
        {
            get
            {
                return _startBackgroundWorker;
            }
            set
            {
                _startBackgroundWorker = value;
                RaisePropertyChanged("StartBackgroundWorker");
            }
        }

        public int Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                RaisePropertyChanged("Progress");
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
                    StartBackgroundWorker = new RelayCommand(startProcess);
                });
        }

        private void startProcess(object sender)
        {
            _backgroundWorker = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync();
            Instruction = "";
            TextColor = "Black";
            StartEnable = false;
        }

        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (_backgroundWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                _backgroundWorker.ReportProgress(i);
                System.Threading.Thread.Sleep(200);
            }
        }

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Status = "Processing ... " + e.ProgressPercentage + " % complete";
            Progress = e.ProgressPercentage;
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) 
        {
            if (!e.Cancelled)
            {
                TextColor = Brushes.Green.ToString();
                Status = "BackgroundWorker finished!";
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}