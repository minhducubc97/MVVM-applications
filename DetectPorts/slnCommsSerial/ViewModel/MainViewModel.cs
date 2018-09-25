using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace slnCommsSerial.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Implementing INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion Implementing INotifyPropertyChanged

        #region Constructor
        /// <summary>
        /// Constructor.
        /// </summary>
        public MainViewModel()
        {
            InitializeVariables();
            InitializeCommands();
            InitializeBackgroundThread();
        }
        #endregion Constructor

        #region Methods
        #region Initialization
        /// <summary>
        /// Initialize variables.
        /// </summary>
        private void InitializeVariables()
        {
            VCPs = new ObservableCollection<string>();
            USBs = new ObservableCollection<string>();
        }

        /// <summary>
        /// Initialize commands.
        /// </summary>
        private void InitializeCommands()
        {
            DetectVCP = new RelayCommand(DetectVCPMethod);
            DetectUSB = new RelayCommand(DetectUSBMethod);
        }

        /// <summary>
        /// Initialize background thread.
        /// </summary>
        private void InitializeBackgroundThread()
        {
            Worker = new BackgroundWorker();
            Worker.DoWork += Worker_DoWork;
            Worker.RunWorkerAsync();
        }
        #endregion Initialization

        /// <summary>
        /// Detect the COM ports.
        /// </summary>
        private void DetectVCPMethod(object sender)
        {
            VCPs.Clear();
            try
            {
                // Find in Win32_PnPEntity id that contains VCP
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE PnPClass='Ports'");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (!VCPs.Contains(queryObj["Name"].ToString()))
                    {
                        VCPs.Add(queryObj["Name"].ToString());
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }

        /// <summary>
        /// Detect the USBs.
        /// </summary>
        /// <param name="sender"></param>
        private void DetectUSBMethod(object sender)
        {
            USBs.Clear();
            try
            {
                // Find in Win32_PnPEntity id that contains USBs.
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE PnPClass='USB'");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["Name"] == null)
                    {
                        // skip
                    }
                    else if (!USBs.Contains(queryObj["Name"].ToString()))
                    {
                        if (!(queryObj["Name"].ToString().Contains("Composite")) && !(queryObj["Name"].ToString().Contains(" Hub"))) // these are USB supporting device, not USB
                        {
                            if (IsPluggedInUSB(queryObj["DeviceID"].ToString()))
                            {
                                USBs.Add(queryObj["Name"].ToString());
                            }
                        }
                    }
                }
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
        }

        /// <summary>
        /// Return true if the device is a plugged in USB. Return false otherwise (a default USB built-in device).
        /// </summary>
        /// <param name="deviceID"></param>
        /// <returns></returns>
        private bool IsPluggedInUSB(string deviceID)
        {
            bool result = false;
            string[] removeBackLash = deviceID.Split('\\');
            if (removeBackLash[1].Contains("VID_") && removeBackLash[1].Contains("PID_"))
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Scanning for insertion and removal of COM port.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var insertCOMQuery = new WqlEventQuery("SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity' AND TargetInstance.Name LIKE '%(COM[0-9]%'");
            var insertCOMWatcher = new ManagementEventWatcher(insertCOMQuery);
            insertCOMWatcher.EventArrived += DeviceInsertedEvent;
            insertCOMWatcher.Start();

            var removeCOMQuery = new WqlEventQuery("SELECT * FROM __InstanceDeletionEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity' AND TargetInstance.Name LIKE '%(COM[0-9]%'");
            var removeCOMWatcher = new ManagementEventWatcher(removeCOMQuery);
            removeCOMWatcher.EventArrived += DeviceRemovedEvent;
            removeCOMWatcher.Start();
        }

        /// <summary>
        /// Display message about the device inserted.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceInsertedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            MessageBox.Show(instance.Properties["Name"].Value + " is Inserted.");
        }

        /// <summary>
        /// Display message about the device removed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeviceRemovedEvent(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject instance = (ManagementBaseObject)e.NewEvent["TargetInstance"];
            MessageBox.Show(instance.Properties["Name"].Value + " is Removed.");
        }
        #endregion Methods

        #region Properties and Fields
        private ICommand _detectVCP;
        public ICommand DetectVCP
        {
            get
            {
                return _detectVCP;
            }
            set
            {
                _detectVCP = value;
                RaisePropertyChanged("DetectVCP");
            }
        }

        private ObservableCollection<string> _vcps;
        public ObservableCollection<string> VCPs
        {
            get
            {
                return _vcps;
            }
            set
            {
                _vcps = value;
                RaisePropertyChanged("VCPs");
            }
        }

        private ICommand _detectUSB;
        public ICommand DetectUSB
        {
            get
            {
                return _detectUSB;
            }
            set
            {
                _detectUSB = value;
                RaisePropertyChanged("DetectUSB");
            }
        }

        private ObservableCollection<string> _usbs;
        public ObservableCollection<string> USBs
        {
            get
            {
                return _usbs;
            }
            set
            {
                _usbs = value;
                RaisePropertyChanged("USBs");
            }
        }

        BackgroundWorker Worker { get; set; }
        #endregion Properties and Fields
    }
}
