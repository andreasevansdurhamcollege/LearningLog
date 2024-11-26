using LearningLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingLearningLog
{
    class AudioLogEntry : LogEntry
    {
        public FileInfo RecordingFile { get; set; }
    }
}
