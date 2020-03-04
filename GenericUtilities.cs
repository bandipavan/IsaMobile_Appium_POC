using System;


namespace IsaMobile_Appium_POC
{
    public class GenericUtilities
    {

       public static void Wait(int intSeconds)
        {
            Boolean blnNotDone = true;
            DateTime dtCountdownTo = DateTime.Now.AddSeconds(intSeconds);

            //dtCountdownTo.AddSeconds(intSeconds);

            while (blnNotDone)
            {
                if (DateTime.Now > dtCountdownTo)
                    blnNotDone = false;
            }

            blnNotDone = true;

        }

        public static void WaitMilliSeconds(int MilliSeconds)
        {
            Boolean blnNotDone = true;
            DateTime dtCountdownTo = DateTime.Now.AddMilliseconds(MilliSeconds);

            while (blnNotDone)
            {
                if (DateTime.Now > dtCountdownTo)
                    blnNotDone = false;
            }

            blnNotDone = true;

        }

    }
}
