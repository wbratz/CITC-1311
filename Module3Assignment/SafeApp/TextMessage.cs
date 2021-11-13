using System;

namespace SafeApp
{
    public class TextMessage
    {
        public void OnEventReceived(object source, SafeEvent safeEvent)
        {
            // Exclude item added and removed events.
            // Only send a message if the safe was opened.
            // Specific subscribers can opt out of particular messages.
            // Cleaner ways to do this but it works for quick and dirty.
            
            if(safeEvent.GetType().Equals(nameof(SafeOpenedEvent)))
            {
                Console.WriteLine($"Text Message was sent with a new event: Event Type: " +
                $"{safeEvent.GetType()} Message: {safeEvent.DateTime} {safeEvent.Message}");
            }
        }
    }
}
