using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using ListViewSample.ViewModel;

namespace ListViewSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }

        private void TextBox_OnlyNonNegativeDoubleValid(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            SimpleIoc.Default.GetInstance<MainViewModel>().TextBox_OnlyNonNegativeDoubleValid(sender,e);
        }

        private void TextBox_OnlyNonZeroDoubleValid(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            SimpleIoc.Default.GetInstance<MainViewModel>().TextBox_OnlyNonZeroDoubleValid(sender, e);
        }
    }
}