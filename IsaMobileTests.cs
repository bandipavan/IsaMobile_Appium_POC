using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;



namespace IsaMobile_Appium_POC
{
    [TestClass]
    public class IsaMobileTests
    {
        [TestInitialize]
        public void Init()
        { 
            AppiumDriver.InitializeAppiumDriverInstance(TestContext.TestName);
           // MobileLogInPage.LogOutIfAlreadyLoggedIn();
            //AppiumActions.TapScreenUpperRightAndroid();
            MobileLogInPage.LoginAs(ConfigurationManager.AppSettings.Get("UserName")).WithPassword(ConfigurationManager.AppSettings.Get("Password")).Login();
            GenericUtilities.Wait(10);
        }


        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                GenericUtilities.Wait(10);
                // log out of the app
                //MobileLogin.ClickProfileButton();
                //MobileLogInPage.MobileLogOut();
                //LogResults.LogPass("Signed Out successfully");
            }
            catch (Exception ex)
            {
                //LogResults.LogFail("Failed to Sign Out" + ex);
            }

            AppiumDriver.CloseDriverSession();
            //Assert.IsTrue(LogResults.EndLoggingSession());

        }


        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}