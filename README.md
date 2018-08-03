# Window applications (MVVM)
Sample Window Applications using MVVM framework:
<h4>1 - BASIC:</h4>
* <i>CalculatorMiniProject:</i> A simple calculator that can add 2 numbers together. The calculation happens immediately after the user unfocus the textbox.<br/><br/>
* <i>DispatcherTimerSample:</i> A simple digital clock that show current time accurate to milliseconds.
<br/><br/>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github.PNG" height="150"/>
  <br/>
<div align="center"><i>Figure 1: Clock view.</i></div>
</p>
<br/>
* <i>CustomCommand:</i> A simple demonstration of using CommandBinding to: allow shortkey control, enable/disable button, create pop-up window in MVVM.<br/><br/>
* <i>TabControl:</i> A simple demonstration of using TabControl in MVVM that features a next button to move to the next tab and a back button to move back to the previous tab. 
<br/><br/>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github4.PNG" height="280"/>
  <br/>
  <div align="center"><i>Figure 2: Tab view.</i></div>
</p>
<br/>
* <i>SoundPlayer:</i> Using built-in SystemSounds libary, the SoundPlayer is capable of playing 5 different sounds: Asterisk, Beep, Exclamation, Hand and Question. The sounds may vary, due to user's customization.
<br/><br/><br/>
<h4>2 - ADVANCED:</h4>
* <i>BackgroundWorkerSample:</i> A window with progress bar controlled by BackgroundWorker using multithreading principle. There are three main buttons available to use: Cancel Button - used to close the window, Stop Button - used to stop the BackgroundWorker and the progress bar completely, and Start Button - used to start the BackgroundWorker and trigger the progress bar.
<br/><br/>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github7.PNG" height="150"/>
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github8.PNG" height="150"/>
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github9.PNG" height="150"/>
  <br/>
  <div align="center"><i>Figure 3: BackgroundWorker in action.</i></div>
</p>
<br/><br/>
* <i>PraceXml:</i> A demonstration of using XmlReader to extract data from Xml file externally (which means that developer has to place the folder containing Xml files inside the output Folder insteading of storing the Xml files inside the executable file). The information is then displayed on the console. Unlike other projects, this one does not need MVVM.
<br/><br/>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github10.PNG" height="280"/>
  <br/>
  <div align="center"><i>Figure 4: Console output triggered by the application.</i></div>
</p>
<br/><br/>
* <i>PraceXml-EmbeddedVers:</i> Based on PraceXml, this application stores Xml files inside the executable file as EmbeddedResources instead (which makes it easier for the installation process).
<br/><br/>
* <i>ListViewSample:</i> Create a table that resembles an excel sheet, which can receive inputs from the users and calculate the result based on the inputs. In this specific project, the table can calculate gravitation force, given user's input of 2 target objects' mass (m1, m2) and the distance between 2 object (r): F = (G x m1 x m2)/r^2 (Newton). The mini-project feature demonstration of PreviewTextInput, which restricts user to only typing valid characters into the textboxes.
<br/><br/>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github11.PNG" height="250"/>
  <br/>
  <div align="center"><i>Figure 5: Table view.</i></div>
</p>
<br/><br/>
* <i>YoutubeStream:</i> An WPF application that can stream videos from Youtube. The user enters their youtube link into the textbox, then application will decide whether the link is valid or not. Only when the link is valid, the application will open the youtube link in embedded version of the video. The application also allows user to download the video to local directory. The application makes use of CefSharp, which enables surfing webs in Chromium instead of default IE. 
<br/>
<b>Remark:</b> After experimenting quite a few Youtube videos in different browsers, I realize that many of the embedded version of old Youtube links are broken (but the non-embedded version works perfectly). However, the newer Youtube videos work quite well. (It is possible that Youtube gets rid of embedded version of the old videos to make space for newer ones).
<br/><br/>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Youtube.PNG" height="300"/>
  <br/>
  <div align="center"><i>Figure 6: Application initial view.</i></div>
</p>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/YoutubeWrong.PNG" height="300"/>
  <br/>
  <div align="center"><i>Figure 7: Application shows error when user enters an invalid Youtube link.</i></div>
</p>
<p align="center">
  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/YoutubeRight.PNG" height="300"/>
  <br/>
  <div align="center"><i>Figure 8: Application displays the Youtube video in embedded form.</i></div>
</p>
<br/>
<br/>
<p><i>Note: Most of the projects use MVVM light framework.</i></p>
