using CefSharp;
using CefSharp.Wpf;
using GalaSoft.MvvmLight;
using Microsoft.Win32;
using MyToolkit.Multimedia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
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

        private ChromiumWebBrowser _webBrowser;
        public ChromiumWebBrowser webBrowser
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
                webBrowser.Address = value;
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

        private ICommand _download;
        public ICommand Download
        {
            get
            {
                return _download;
            }
            set
            {
                _download = value;
                RaisePropertyChanged("Download");
            }
        }

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
            webBrowser = new ChromiumWebBrowser();
            browserSettings = new CefSettings();
            if (!Cef.IsInitialized)
            {
                Cef.Initialize(browserSettings);
            } 
            ErrorVisibility = "Hidden";
        }

        private void initializeCommand()
        {
            EnterLink = new RelayCommand(enterLinkMethod);
            Download = new RelayCommand(downloadMethod);
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
            if (!Url.Contains("youtube.com"))
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

        private async void downloadMethod(object sender)
        {
            var id = YoutubeClient.ParseVideoId(Url);
            var client = new YoutubeClient();
            var video = await client.GetVideoAsync(id);
            var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(id);

            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
            var ext = streamInfo.Container.GetFileExtension();
            string title = video.Title.Replace("/", "").Replace("\\","");

            await client.DownloadMediaStreamAsync(streamInfo, "D:\\" + title + ".mp4");
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}