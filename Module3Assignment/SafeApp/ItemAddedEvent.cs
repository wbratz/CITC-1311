namespace SafeApp
{
    public class ItemAddedEvent : SafeEvent
    {
        public string ItemName { get; set; }

        public override string GetType()
        {
            return nameof(ItemAddedEvent);
        }
    }
}
