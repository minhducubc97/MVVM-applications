using CefSharp;
using CefSharp.Wpf;
using GalaSoft.MvvmLight;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YoutubeStream.Model;


namespace YoutubeStream.ViewModel
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
        /// Variables.
        /// </summary>
        /// 

        /// <summary>
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 

        private string _url;
        public string Url
        {
            get
            {
                return GetEmbedURL(_url);
            }
            set
            {
                _url = value;
                RaisePropertyChanged("Url");
            }
        }

        private WebBrowser _webBrowser;
        public WebBrowser webBrowser
        {
            get
            {
                return _webBrowser;
            }
            set
            {
                _webBrowser = value;
                RaisePropertyChanged("webBrowser");
            }
        }

        private ICommand _enterLink;
        public ICommand EnterLink
        {
            get
            {
                return _enterLink;
            }
            set
            {
                _enterLink = value;
                RaisePropertyChanged("EnterLink");
            }
        }

        public string _browserAddress;
        public string BrowserAddress
        {
            get
            {
                return _browserAddress;
            }
            set
            {
                _browserAddress = value;
                RaisePropertyChanged("BrowserAddress");
            }
        }

        private string _errorVisibility;
        public string ErrorVisibility
        {
            get
            {
                return _errorVisibility;
            }
            set
            {
                _errorVisibility = value;
                RaisePropertyChanged("ErrorVisibility");
            }
        }

        public CefSettings browserSettings { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            initializeVariable();
            initializeCommand();
        }

        /// <summary>
        /// Initialization.
        /// </summary>
        private void initializeVariable()
        {
            Url = "";
            webBrowser = new WebBrowser();
            browserSettings = new CefSettings();
            Cef.Initialize(browserSettings);
            ErrorVisibility = "Hidden";
        }

        private void initializeCommand()
        {
            EnterLink = new RelayCommand(enterLinkMethod);
        }

        /// <summary>
        /// Helpers.
        /// </summary>
        private string GetEmbedURL(string link)
        {
            string embedUrl = link.Replace("watch?v=", "embed/");
            return embedUrl;
        }

        private void enterLinkMethod(object sender)
        {
            if (!Url.Contains("www.youtube.com"))
            {
                ErrorVisibility = "Hidden"; // => Trigger the blinking effect of ErrorStyle
                ErrorVisibility = "Visible";
            }
            else
            {
                ErrorVisibility = "Hidden";
                BrowserAddress = Url;
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}