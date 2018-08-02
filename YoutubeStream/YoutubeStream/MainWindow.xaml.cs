using MyToolkit.Multimedia;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YoutubeStream.ViewModel;

namespace YoutubeStream
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
    }
}