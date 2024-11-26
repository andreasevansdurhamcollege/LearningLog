﻿/* LogEntry.cs
 * Author: Andreas Evans-Adamecz
 * Date: November 5th 2024
 * Description: defines the LogEntry class, where each LogEntry object is a recording session
 */
using System.IO;

namespace LearningLog
{
    // properties
    internal class LogEntry
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public int Wellness { get; set; }
        public int Quality { get; set; }
        public string Notes { get; set; }
        public FileInfo RecordingFile { get; set; }

        // static properties
        public static int Count { get; set; }
        public static DateTime FirstEntry { get; set; }
        public static DateTime NewestEntry { get; set; }

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