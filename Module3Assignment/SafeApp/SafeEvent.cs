using System;

namespace SafeApp
{
    public class SafeEvent 
    {
        public DateTime DateTime {get; set;}
        public string Message { get; set; }

        public virtual new string GetType()
        {
            return nameof(SafeEvent);
        }
    }
}
