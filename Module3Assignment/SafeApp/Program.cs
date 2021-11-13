using System;
using System.Collections.Generic;

namespace SafeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SafeEventReceiver safeReceiver = new SafeEventReceiver();
            SafeLog safeLog = new SafeLog();
            TextMessage txt = new TextMessage();

            safeReceiver.EventReceived += safeLog.OnEventReceived;
            safeReceiver.EventReceived += txt.OnEventReceived;

            var mySafe = new Safe("safeCode", 100, 100, 100, "MySafe", safeReceiver)
            {
                Shelves = 2
            };

            mySafe.ToString();


            var myOtherSafe = new Safe("otherSafeCode", 200, 100, 10, "MyOtherSafe", safeReceiver)
            {
                Shelves = 1
            };

            myOtherSafe.ToString();

            mySafe.OpenSafe("incorrectCode");
            mySafe.OpenSafe("safeCode");
            myOtherSafe.OpenSafe("otherSafeCode");

            mySafe.ToString();
            myOtherSafe.ToString();

            mySafe.AddContents("$10 bill");
            myOtherSafe.AddContents("$2 bill");
            myOtherSafe.AddContents("Chicken wings");

            mySafe.ToString();
            myOtherSafe.ToString();

            myOtherSafe.RemoveContents("Chicken wings");

            mySafe.CloseSafe();
            myOtherSafe.CloseSafe();

            mySafe.ToString();
            myOtherSafe.ToString();

            mySafe.ChangeAccessCode("safeCode", "unsafeCode");
        }
    }

    

}
