/* LogEntry.cs
 * Author: Andreas Evans-Adamecz
 * Date: November 5th 2024
 * Description: defines the LogEntry class, where each LogEntry object is a recording session
 */
using System.IO;

namespace LearningLog
{
    // properties
    internal abstract class LogEntry
    {
        protected internal int Id { get; set; }
        protected internal DateTime EntryDate { get; set; }
        protected internal int Wellness { get; set; }
        protected internal int Quality { get; set; }
        protected internal string Notes { get; set; }
        protected internal FileInfo RecordingFile { get; set; }

        // static properties
        protected internal static int Count { get; set; }
        protected internal static DateTime FirstEntry { get; set; }
        protected internal static DateTime NewestEntry { get; set; }

        //default constructor
        public LogEntry()
        {
            Id = ++Count;
            EntryDate = DateTime.Now;
            Wellness = 0;
            Quality = 0;
            Notes = string.Empty;
            RecordingFile = null;

            if (Count == 1) FirstEntry = EntryDate;
            NewestEntry = EntryDate;


        }

        // parameterized constructor
        public LogEntry(int wellness, int quality, string notes, FileInfo recordingFile) : this()
        {
            Wellness = wellness;
            Quality = quality;
            Notes = notes;
            RecordingFile = recordingFile;
        }


    }
}