using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using ReaderWriter.ViewModel;

namespace ReaderWriter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Variables.
        /// </summary>
        SpeechRecognizer speechRecognizer;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            speechRecognizer = new SpeechRecognizer();
        }

        private void btnWriter_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnWriter.Height = btnWriter.Height + 20;
            btnWriter.Width = btnWriter.Width + 20;
        }

        private void btnWriter_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnWriter.Height = btnWriter.Height - 20;
            btnWriter.Width = btnWriter.Width - 20;
        }

        private void btnReader_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnReader.Height = btnReader.Height + 20;
            btnReader.Width = btnReader.Width + 20;
        }

        private void btnReader_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            btnReader.Height = btnReader.Height - 20;
            btnReader.Width = btnReader.Width - 20;
        }

        private void ReadMethod(object sender, RoutedEventArgs e)
        {
            mainTab.TabIndex = mainTab.TabIndex + 2;
        }

        private void WriteMethod(object sender, RoutedEventArgs e)
        {
            mainTab.TabIndex++;
        }

        private void startWriting_Click(object sender, RoutedEventArgs e)
        {
            content.Text = "";
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            mainTab.TabIndex = 0;
        }

        private void startListenning_Click(object sender, RoutedEventArgs e)
        {
            PromptBuilder promptBuilder = new PromptBuilder();
            promptBuilder.AppendText("My name is ALFRED");

            PromptStyle promptStyle = new PromptStyle();
            promptStyle.Volume = PromptVolume.Soft;
            promptStyle.Rate = PromptRate.Slow;
            promptBuilder.StartStyle(promptStyle);
            promptBuilder.AppendText("and I am pleased to meet you.");
            promptBuilder.EndStyle();

            promptBuilder.AppendText("Date: ");
            promptBuilder.AppendTextWithHint(DateTime.Now.ToShortDateString(), SayAs.Date);

            promptBuilder.AppendText("Now, I would like to tell you what you wrote");
            promptBuilder.AppendText("Ehm", PromptEmphasis.Strong);
            promptBuilder.AppendText(content.Text);

            SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.Speak(promptBuilder);
        }
    }
}