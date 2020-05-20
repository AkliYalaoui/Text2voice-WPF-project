using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Speech;
using System.Speech.Synthesis;
namespace text2voice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SpeechSynthesizer reader = new SpeechSynthesizer();

        public MainWindow()
        {
            InitializeComponent();
            setComboItem();
        }

        private void voice_Click(object sender, RoutedEventArgs e)
        {
            if(textToConvert.Text == "")
            {
                textToConvert.Text = "Entrer un text pour le convertir";
            }
            else
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                try { reader.SelectVoice(languages.Text); } catch (Exception ez) { MessageBox.Show(ez.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
                reader.SpeakAsync(textToConvert.Text);
            }
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Speaking)
                    reader.Pause();
            }
        }

        private void resume_Click(object sender, RoutedEventArgs e)
        {
            if (reader != null )
            {
                if (reader.State == SynthesizerState.Paused)
                reader.Resume();
            }
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
            }
        }
       private  void setComboItem()
        {
            foreach(var voix in reader.GetInstalledVoices())
            {
                languages.Items.Add(voix.VoiceInfo.Name);
            }
        }
    }
}
