using System;
using System.IO;

namespace SafeApp
{
    public class SafeLog 
    {
        
        public void OnEventReceived(object source, SafeEvent safeEvent)
        {
            Console.WriteLine($"Writing event to log: {safeEvent.Message}");

            WriteToLog(safeEvent);
        }

        private void WriteToLog(SafeEvent safeEvent)
        {
            if(!File.Exists("log.txt"))
            {
                string logPath = "log.txt";   
                FileStream stream = File.Create(logPath);
                stream.Dispose();
            }

            using StreamWriter writer = File.AppendText("log.txt");
            writer.WriteLine($"{safeEvent.DateTime} - {safeEvent.GetType()} - {safeEvent.Message}");
            writer.Dispose();
        }
    }
}
