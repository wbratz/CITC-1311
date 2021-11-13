namespace SafeApp
{
    public class SafeOpenedEvent : SafeEvent
    {
        public override string GetType()
        {
            return nameof(SafeOpenedEvent);
        }
    }
}
