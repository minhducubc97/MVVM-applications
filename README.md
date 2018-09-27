# Window applications (MVVM)
Sample Window Applications using MVVM framework/MVVM Light framework:
### 1 - BASIC:
- *CalculatorMiniProject:* A simple calculator that can add 2 numbers together. The calculation happens immediately after the user unfocus the textbox.
- *DispatcherTimerSample:* A simple digital clock that show current time accurate to milliseconds.
- *CustomCommand:* A simple demonstration of using CommandBinding to: allow shortkey control, enable/disable button, create pop-up window in MVVM.
- *TabControl:* A simple demonstration of using TabControl in MVVM that features a next button to move to the next tab and a back button to move back to the previous tab. 
- *SoundPlayer:* Using built-in SystemSounds libary, the SoundPlayer is capable of playing 5 different sounds: Asterisk, Beep, Exclamation, Hand and Question. The sounds may vary, due to user's customization.
- *ListViewSample:* Create a table that resembles an excel sheet, which can receive inputs from the users and calculate the result based on the inputs. In this specific project, the table can calculate gravitation force, given user's input of 2 target objects' mass (m1, m2) and the distance between 2 object (r): F = (G x m1 x m2)/r^2 (Newton). The mini-project feature demonstration of PreviewTextInput, which restricts user to only typing valid characters into the textboxes.

  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github11.PNG" height="250"/>
  
### 2 - ADVANCED:
- *BackgroundWorkerSample:* A window with progress bar controlled by BackgroundWorker using multithreading principle. There are three main buttons available to use: Cancel Button - used to close the window, Stop Button - used to stop the BackgroundWorker and the progress bar completely, and Start Button - used to start the BackgroundWorker and trigger the progress bar.

  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/BackgroundWorker.PNG"  height="250"/>
  
- *PraceXml:* A demonstration of using XmlReader to extract data from Xml file externally (which means that developer has to place the folder containing Xml files inside the output Folder insteading of storing the Xml files inside the executable file). The information is then displayed on the console. Unlike other projects, this one does not need MVVM.

  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/Github10.PNG" height="280"/>
  
- *PraceXml-EmbeddedVers:* Based on PraceXml, this application stores Xml files inside the executable file as EmbeddedResources instead (which makes it easier for the installation process).
- *SQLiteCommunication:* The mini-project demonstrates the communication with SQLite database. It shows how to create, insert data and get data from a database file.

  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/SQLCommunication.PNG" height="280"/>
  
- *JSONCommunicator:* A simple demonstration of using serializing and deserializing data with a JSON file. 

  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/JSONCommunicator.PNG" height="280"/>
  
- *AccessDTBCommunication:* This mini-project demonstrates a simple student registration form. Student enters into the form his/her name, prefered ID number, gender, contact and address, and the program will store those values into a local Access file. This program can extract data from and import data into Access file, as well as make changes to data already inside the file.

  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/AccessDTBCommunication.PNG" height="350"/>
  
- *ReaderWriter*: Using SpeechSynthesizer (used for speaking) and SpeechRecognizer (used for reading) buit into System.Speech, the software can perform the two most important abilities of human: speaking and reading. User can speak out the command (eg: call the name of the button, then the button will be pressed automatically), tell the program to type and listen to the program speaking the text the user specified. Tip: You need a good pair of headsets.
- *DetectPorts*: An WPF application that can detect all the COM ports and USB available in the system. It will also notify the user when a COM port is inserted/removed. There will be a Background thread that constantly search for device availability, and it will contact the UI thread when there is a change (insertion or removal).
- *YoutubeStream:* An WPF application that can stream videos from Youtube. The user enters their youtube link into the textbox, then application will decide whether the link is valid or not. Only when the link is valid, the application will open the youtube link in embedded version of the video. The application also allows user to download the video to local directory. The application makes use of CefSharp, which enables surfing webs in Chromium instead of default IE.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
**Remark:** After experimenting quite a few Youtube videos in different browsers, I realize that many of the embedded version of old Youtube links are broken (but the non-embedded version works perfectly). However, the newer Youtube videos work quite well. (It is possible that Youtube gets rid of embedded version of the old videos to make space for newer ones).

  <img src="https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/Images/YoutubeRight.PNG" height="300"/>

## Built with
- MVVM light framework

## License
This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/minhducubc97/Window-Applications-MVVM/blob/master/LICENSE) file for details
