/* Author: Andreas Evans-Adamecz
 * Date: November 5th 2024
 * Description: main file which initializes all the stuff in the xaml and also contains the event handlers for all the buttons
 * 
 */

using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace LearningLog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // indicates whether or not the app is recording something
        private bool isRecording = false;

        // stores path and contents of recordings
        private FileInfo recordingFile;

        public MainWindow()
        {
            // initialize the user interface
            InitializeComponent();
        }

        /// <summary>
        /// event handler for the record button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonRecord_Click(object sender, RoutedEventArgs e)
        {
            if (!isRecording)
            {
                // if a recording is not already going on, when clicked, changes isRecording to true, switches the button to stop, updates the status and starts the recording
                isRecording = true;
                buttonRecord.Content = "Stop";
                UpdateStatus("Recording has started");
                RecordWav.StartRecording();

            }
            else
            {
                isRecording = false;
                buttonRecord.Content = "Record";
                recordingFile = RecordWav.EndRecording();
                UpdateStatus("Recording has stopped");

                buttonRecord.IsEnabled = false; // Disable Record button
                buttonPlay.IsEnabled = true;
                buttonDelete.IsEnabled = true;
                buttonSave.IsEnabled = true;
            }
        }

        /// <summary>
        /// event handler fo the play button which plays an audio file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPlay_Click(object sender, RoutedEventArgs e)
        {
            if (recordingFile != null && recordingFile.Exists)
            {

                var player = new System.Media.SoundPlayer(recordingFile.FullName); // makes a soundplayer object
                player.Play();
                UpdateStatus("Playing recording");
            }

        }

        /// <summary>
        /// event handler for the delete button which deletes a recorded audio file 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (recordingFile != null && recordingFile.Exists)
            {
                recordingFile.Delete();
                UpdateStatus("Deleted recording");
                buttonPlay.IsEnabled = false;
                buttonDelete.IsEnabled = false;
                buttonSave.IsEnabled = false;
                buttonRecord.IsEnabled = true; // Enable Record button
            }

        }

        /// <summary>
        /// placeholder for the Save button. I left things too late and am tired :( fully my fault though
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            int wellness = comboWellnessMood.SelectedIndex + 1; // Assuming 1-based scale
            int quality = comboboxQuality.SelectedIndex + 1;
            string notes = textNotes.Text;

            var logEntry = new LogEntry(wellness, quality, notes, recordingFile);

            UpdateStatus("Entry saved");

            // Reset the form
            comboWellnessMood.SelectedIndex = -1;
            comboboxQuality.SelectedIndex = -1;
            textNotes.Clear();
            recordingFile = null;

            buttonPlay.IsEnabled = false;
            buttonDelete.IsEnabled = false;
            buttonSave.IsEnabled = false;
            buttonRecord.IsEnabled = true;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabSummary.IsSelected)
            {
                textBlockEntryNumber.Text = LogEntry.Count.ToString();
                textBlockFirstEntry.Text = LogEntry.FirstEntry.ToString("g");
                textBlockNewestEntry.Text = LogEntry.NewestEntry.ToString("g");

                UpdateStatus("Summary tab viewed");
            }
        }

        /// <summary>
        /// ditto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textNotes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// updates the stratus bar
        /// </summary>
        /// <param name="message"></param>
        private void UpdateStatus(string message)
        {
            statusState.Content = $"{message} - {DateTime.Now:HH:mm:ss}";
        }


    }
}