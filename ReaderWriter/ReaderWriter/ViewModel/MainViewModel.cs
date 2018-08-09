using GalaSoft.MvvmLight;
using ReaderWriter.Model;
using System.Windows;
using System.Windows.Input;

namespace ReaderWriter.ViewModel
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
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            InitializeCommand();
        }

        /// <summary>
        /// Helpers.
        /// </summary>
        /// 
        private void InitializeCommand()
        {

        }

        /// <summary>
        /// Variables declaration.
        /// </summary>

        /// <summary>
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}