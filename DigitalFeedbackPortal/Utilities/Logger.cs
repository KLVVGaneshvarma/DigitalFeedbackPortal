using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFeedbackPortal.Utilities
{
    internal class Logger
    {
        private static readonly string logFile = "error_log.txt";

        public static void LogError(string message)
        {
            string logMessage = $"[{DateTime.Now}] ERROR: {message}";
            File.AppendAllText(logFile, logMessage + Environment.NewLine);
        }
    }
}