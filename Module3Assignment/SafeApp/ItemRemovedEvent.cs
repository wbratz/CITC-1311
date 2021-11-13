namespace SafeApp
{
    public class ItemRemovedEvent : SafeEvent
    {
        public string ItemName {get; set;}

        public override string GetType()
        {
            return nameof(ItemRemovedEvent);
        }
    }
}
