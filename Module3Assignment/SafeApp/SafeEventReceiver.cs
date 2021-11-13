using System;

namespace SafeApp
{
    public class SafeEventReceiver
    {
        public delegate void SafeEventHandler (object source, SafeEvent safeEvent);
        public event SafeEventHandler EventReceived;

        public void Receive (SafeEvent safeEvent)
        {
            Console.WriteLine($"New safe event: {safeEvent.Message}");

            OnEventReceived(safeEvent);
        }

        private void OnEventReceived(SafeEvent safeEvent)
        {
            EventReceived.Invoke(this, safeEvent);
        }
    }

}
