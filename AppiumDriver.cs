using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Configuration;
using OpenQA.Selenium.Appium.Enums;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using System.Net;

namespace IsaMobile_Appium_POC
{
    public class AppiumDriver  
    {
        // auto-implemented property
        public static AppiumDriver<IWebElement> Instance { get; set; }
        public static IWebDriver RemoteInstance { get; set; }
        public static bool isAndroidDevice { get; set; }
        public static object Constants { get; private set; }

        /// <summary>
        /// this method creates the current instance of the appium driver. 
        /// </summary>
        /// <returns></returns>
        public static void InitializeNewAndroidInstance() //_NW()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            string capabilitySetting = string.Empty;

            // first try and set common capabilities for both android and iOS
            try
            {

                cap.SetCapability("device", ConfigurationManager.AppSettings.Get("androidDevice"));
                cap.SetCapability("deviceName", ConfigurationManager.AppSettings.Get("androidDeviceName"));
                cap.SetCapability("platformName", ConfigurationManager.AppSettings.Get("androidPlatformName"));
                cap.SetCapability("platformVersion", ConfigurationManager.AppSettings.Get("androidPlatformVersion"));
                cap.SetCapability("automationName", "appium");
                //cap.SetCapability(MobileCapabilityType.NewCommandTimeout, 120);

                // try to assign the Android Specific capabilities
                if ((ConfigurationManager.AppSettings.Get("androidAppPackage") != null) && (ConfigurationManager.AppSettings.Get("androidAppActivity") != null))
                {
                    string str = null;
                    string[] strArr = null;
                    str = ConfigurationManager.AppSettings.Get("androidPlatformVersion");
                    char[] splitchar = { '.' };
                    strArr = str.Split(splitchar);
                    int majorVersionNumber = Int32.Parse(strArr[0]);

                    if (majorVersionNumber >= 9)
                    {
                        var proc = new Process();
                        proc.StartInfo.FileName = ConfigurationManager.AppSettings.Get("androidSdkPath") + "\\platform-tools\\adb.exe ";
                        proc.StartInfo.Arguments = "uninstall io.appium.settings";
                        proc.StartInfo.UseShellExecute = false;
                        proc.StartInfo.RedirectStandardOutput = true;
                        proc.Start();
                        string outPut = proc.StandardOutput.ReadToEnd();

                        proc.WaitForExit();
                        var exitCode = proc.ExitCode;
                        proc.Close();

                        proc.StartInfo.Arguments = "uninstall io.appium.unlock";
                        proc.Start();
                        outPut = proc.StandardOutput.ReadToEnd();

                        proc.WaitForExit();
                        exitCode = proc.ExitCode;
                        proc.Close();
                    }

                    cap.SetCapability("appPackage", ConfigurationManager.AppSettings.Get("androidAppPackage")); 
                    cap.SetCapability("appActivity", ConfigurationManager.AppSettings.Get("androidAppActivity"));
                    cap.SetCapability("automationName", "uiautomator2");
                    Instance = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap, TimeSpan.FromSeconds(1200)); // 840));

                    Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                }
            }
            catch (ConfigurationErrorsException)
            {
            }

            GenericUtilities.Wait(3);
        }



        /// <summary>
        /// this method creates the current instance of the appium driver. 
        /// </summary>
        /// <returns></returns>
        public static void InitializeNewIOSInstance() //_NW()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            string capabilitySetting = string.Empty;

            // first try and set common capabilities for both android and iOS
            try
            {

                cap.SetCapability("device", ConfigurationManager.AppSettings.Get("iOSDevice"));
                cap.SetCapability("deviceName", ConfigurationManager.AppSettings.Get("iOSDeviceName"));
                cap.SetCapability("platformName", ConfigurationManager.AppSettings.Get("iOSPlatformName"));
                cap.SetCapability("platformVersion", ConfigurationManager.AppSettings.Get("iOSPlatformVersion"));
                cap.SetCapability(MobileCapabilityType.NewCommandTimeout, 120);

                // try to assign the iOS Specific capabilities
                if ((ConfigurationManager.AppSettings.Get("iOSudid") != null) && (ConfigurationManager.AppSettings.Get("iOSbundleId") != null) && (ConfigurationManager.AppSettings.Get("iOSapp") != null))
                {
                    cap.SetCapability("udid", ConfigurationManager.AppSettings.Get("iOSudid"));
                    cap.SetCapability("bundleId", ConfigurationManager.AppSettings.Get("iOSbundleId"));
                    cap.SetCapability("app", ConfigurationManager.AppSettings.Get("iOSapp"));
                    cap.SetCapability("xcodeOrgId", "2FV693844F"); // "75XPPVJ3JR"); // ConfigurationManager.AppSettings.Get("iOSapp"));
                    cap.SetCapability("xcodeSigningId", "iPhone Developer"); //, ConfigurationManager.AppSettings.Get("iOSapp"));
                    cap.SetCapability("noReset", "false");


                    Instance = new IOSDriver<IWebElement>(new Uri("http://192.168.1.149:4723/wd/hub"), cap, TimeSpan.FromSeconds(840));
                    // 81, 149
                    Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                }

            }
            catch (ConfigurationErrorsException)
            {
            }

            GenericUtilities.Wait(3);
        }



        /// <summary>
        /// this method creates the current instance of the appium driver for iOS Tablet. 
        /// </summary>
        /// <returns></returns>
        public static void InitializeNewIOSTabletInstance() //_NW()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            string capabilitySetting = string.Empty;

            // first try and set common capabilities for both android and iOS
            try
            {

                cap.SetCapability("device", ConfigurationManager.AppSettings.Get("iOSDevice"));
                cap.SetCapability("deviceName", "Mark's iPad");
                cap.SetCapability("platformName", ConfigurationManager.AppSettings.Get("iOSPlatformName"));
                cap.SetCapability("platformVersion", ConfigurationManager.AppSettings.Get("iOSPlatformVersion"));

                // try to assign the iOS Specific capabilities
                if ((ConfigurationManager.AppSettings.Get("iOSudid") != null) && (ConfigurationManager.AppSettings.Get("iOSbundleId") != null) && (ConfigurationManager.AppSettings.Get("iOSapp") != null))
                {
                    cap.SetCapability("udid", "8b41de11ed27b18a5a470cff7e847d38bf1fb72d");
                    cap.SetCapability("app", ConfigurationManager.AppSettings.Get("iOSapp"));
                    cap.SetCapability("bundleId", ConfigurationManager.AppSettings.Get("iOSbundleId"));
                    cap.SetCapability("xcodeOrgId", "2FV693844F"); // "75PPVJ3JR");
                    cap.SetCapability("xcodeSigningId", "iPhone Developer");

                    Instance = new IOSDriver<IWebElement>(new Uri("http://192.168.1.149:4723/wd/hub"), cap, TimeSpan.FromSeconds(840));

                    Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
                }

            }
            catch (ConfigurationErrorsException)
            {
            }

            //GenericUtilities.Wait(3);
        }

        /// <summary>
        /// this method creates the current instance of the appium driver. 
        /// </summary>
        /// <returns></returns>
        public static void InitializeNewInstance_TO(string testName)
        {

            DesiredCapabilities cap = new DesiredCapabilities();

            // first try and set common capabilities for both android and iOS
            try
            {
                cap.SetCapability("testobject_api_key", "F50C7416433D4C1980A5E4FC95ABA14F"); // "76848341A4054FC1BEC72A012F36A453");
                cap.SetCapability("deviceName", "Samsung_Galaxy_S5_real"); // "iPhone_5_free");
                cap.SetCapability("platformName", "Android");
                cap.SetCapability("platformVersion", "5.1"); // "10.0.2");
                cap.SetCapability("phoneOnly", "true");
                cap.SetCapability("testobject_test_name", testName);
                Uri server = new Uri("http://us1.appium.testobject.com/wd/hub");

                Instance = new AndroidDriver<IWebElement>(server, cap, TimeSpan.FromMinutes(10));

                Instance.Orientation = ScreenOrientation.Portrait;


                //cap.SetCapability("testobject_api_key", "984E0103493D4C9BA54D675703EA600E"); // "A95BA6F297CB46449F1B7575281A508A"); 
                //cap.SetCapability("platformName", "Android");
                //cap.SetCapability("platformVersion", "8");
                ////cap.SetCapability("deviceName", "LG_Nexus_5X_free");
                ////cap.SetCapability("deviceName", "Motorola_Moto_E2_real_us");
                //cap.SetCapability("phoneOnly", "true");
                //cap.SetCapability("testobject_test_name", testName);
                ////cap.SetCapability(MobileCapabilityType.NewCommandTimeout, 5 * 60);
                //cap.SetCapability("testobject_session_creation_timeout", "900000");
                //Uri server = new Urihttp://us1.appium.testobject.com/wd/hub"); 

                //Instance = new AndroidDriver<IWebElement>(server, cap, TimeSpan.FromMinutes(10));
                Location testLocation = new Location();
                testLocation.Latitude = 33.63;
                testLocation.Longitude = -117.71;

                Instance.Location = testLocation;

                Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(45);
            }
            catch (ConfigurationErrorsException)
            {
            }

            GenericUtilities.Wait(3);
        }


        /// <summary>
        /// this method creates the current instance of the appium driver. 
        /// </summary>
        /// <returns></returns>
        public static void InitializeNewIOSInstance_TO()
        {

            DesiredCapabilities cap = new DesiredCapabilities();

            // first try and set common capabilities for both android and iOS
            try
            {
                cap.SetCapability("testobject_api_key", "984E0103493D4C9BA54D675703EA600E"); // "76848341A4054FC1BEC72A012F36A453");
                //cap.SetCapability("deviceName", "iPhone_8_real_us2"); // "iPhone_5_free");
                cap.SetCapability("platformName", "iOS");
                cap.SetCapability("platformVersion", "10"); // "10.0.2");
                cap.SetCapability("phoneOnly", "true");
                cap.SetCapability("locationServicesEnabled", "true");
                cap.SetCapability("locationServicesAuthorized", "true");
                //cap.SetCapability("autoAcceptAlerts", "true");
                Uri server = new Uri("http://us1.appium.testobject.com/wd/hub");

                Instance = new IOSDriver<IWebElement>(server, cap, TimeSpan.FromMinutes(10));

                Instance.Orientation = ScreenOrientation.Portrait;

                Location testLocation = new Location();
                testLocation.Latitude = 33.63;
                testLocation.Longitude = -117.71;

                IJavaScriptExecutor js = (IJavaScriptExecutor)Instance;
                js.ExecuteScript("location({latitude: 121.21, longitude: 11.56, altitude: 94.23});");

                Instance.Location = testLocation;

                Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            catch (ConfigurationErrorsException)
            {
            }

            GenericUtilities.Wait(3);
        }


        /// <summary>
        /// this method creates the generic current instance of the appium driver. 
        /// </summary>
        /// <returns></returns>
        public static void InitializeAppiumDriverInstance(string testName) 
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            string capabilitySetting = string.Empty;

            // first try and set common capabilities for both android and iOS
            try
            {
                string str = null;
                string[] strArr = null;
                str = ConfigurationManager.AppSettings.Get("PlatformVersion");
                char[] splitchar = { '.' };
                strArr = str.Split(splitchar);
                int majorVersionNumber = Int32.Parse(strArr[0]);


                string keyAppiumIPAddress = string.Empty;
                bool iOSDeviceTesting = false;
                DesiredCapabilities caps = DesiredCapabilities.Android();
                if (ConfigurationManager.AppSettings.Get("IsSauceLabTest").Contains("true") == true)
                {
                   
                    caps.SetCapability("username", "bandipavan");
                    //set your sauce labs access key
                    caps.SetCapability("accessKey", "88ba34b6-e507-4e38-bea2-e74b454ae067");
                    caps.SetCapability("appiumVersion", "1.9.1");
                    caps.SetCapability("deviceName", "Samsung Galaxy S9 WQHD GoogleAPI Emulator"); //Samsung Galaxy S9 WQHD GoogleAPI Emulator, Samsung Galaxy S9 Plus FHD GoogleAPI Emulator, Samsung Galaxy S9 Plus WQHD GoogleAPI Emulator
                    caps.SetCapability("deviceOrientation", "portrait");
                    caps.SetCapability("browserName", "");
                    caps.SetCapability("platformVersion", "9");
                    caps.SetCapability("platformName", "Android");
                    caps.SetCapability("no-reset", "true");
                    caps.SetCapability("full-reset", "false");
                    caps.SetCapability("appPackage", "com.isagenix.qualia");
                    caps.SetCapability("appActivity", "md5936c377d2b4806a004640334b067390d.SplashActivity");
                    caps.SetCapability("app", @"sauce-storage:com.isagenix.qualia.apk.zip"); //https://github.com/saucelabs/sample-app-mobile/releases/download/2.2.0/Android.SauceLabs.Mobile.Sample.app.2.2.0.apk
                }
                else
                {
                    if (ConfigurationManager.AppSettings.Get("PlatformName").Contains("iOS") == true)
                        iOSDeviceTesting = true;

                    SetAppiumCapability(ref cap, "device", "Device");
                    SetAppiumCapability(ref cap, "deviceName", "DeviceName");
                    SetAppiumCapability(ref cap, "platformName", "PlatformName");
                    SetAppiumCapability(ref cap, "platformVersion", "PlatformVersion");
                    //SetAppiumCapability(ref cap, "udid", "udid");
                    //SetAppiumCapability(ref cap, "bundleId", "bundleId");
                    //SetAppiumCapability(ref cap, "app", "app");
                    //SetAppiumCapability(ref cap, "xcodeOrgId", "xcodeOrgId");
                    //SetAppiumCapability(ref cap, "xcodeSigningId", "xcodeSigningId");
                    SetAppiumCapability(ref cap, "no-reset", "true");
                    SetAppiumCapability(ref cap, "full-reset", "false");
                    SetAppiumCapability(ref cap, "appPackage", "AppPackage");
                    SetAppiumCapability(ref cap, "appActivity", "AppActivity");
                    //SetAppiumCapability(ref cap, "testobject_api_key", "TestObjectAPIKey");
                    //SetAppiumCapability(ref cap, "phoneOnly", "PhoneOnly");
                    keyAppiumIPAddress = ConfigurationManager.AppSettings.Get("AppiumIPAddress");

                    if (ConfigurationManager.AppSettings.Get("PlatformName").Contains("Android"))
                    {
                        cap.SetCapability("automationName", "uiautomator2");
                    }
                }
               
                string capURI = string.Empty;
                if (ConfigurationManager.AppSettings.Get("IsSauceLabTest").Contains("true") == true)
                {
                    capURI = @"http://ondemand.saucelabs.com:80/wd/hub";
                    //capURI = "http://" + keyAppiumIPAddress + "/wd/hub";
                    //cap.SetCapability("appiumVersion", "1.7.1");
                    //cap.SetCapability("deviceOrientation", "portrait");
                    //SetAppiumCapability(ref cap, "deviceOrientation", "portrait");
                }
                else
                {
                    capURI = "http://" + keyAppiumIPAddress + ":4723/wd/hub";
                    //capURI = "http://" + keyAppiumIPAddress + ":27015/wd/hub";

                }

                cap.SetCapability(MobileCapabilityType.NewCommandTimeout, 120);

                //if (testName.Length > 0)
                //    cap.SetCapability("testobject_test_name", testName);

                if (iOSDeviceTesting == true)
                    Instance = new IOSDriver<IWebElement>(new Uri(capURI), cap, TimeSpan.FromSeconds(840));
                else if (ConfigurationManager.AppSettings.Get("IsSauceLabTest").Contains("true") == true)
                    Instance = new AndroidDriver<IWebElement>(new Uri(capURI), caps, TimeSpan.FromSeconds(1200)); // 840));
                else
                    Instance = new AndroidDriver<IWebElement>(new Uri(capURI), cap, TimeSpan.FromSeconds(1200)); // 840));

                // 81, 149
                Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
            catch (ConfigurationErrorsException)
            {
            }

            GenericUtilities.Wait(3);
        }


        private static void SetAppiumCapability(ref DesiredCapabilities cap, string capabilityName, string appConfigSettingName)
        {

            try
            {
                string appConfigSetting = ConfigurationManager.AppSettings.Get(appConfigSettingName);
                if (string.IsNullOrEmpty(appConfigSetting) == false)
                    cap.SetCapability(capabilityName, appConfigSetting);
            }
            catch (ConfigurationErrorsException)
            {
            }
        }


        private static RemoteWebDriver getExecuteMethod()
        {
            throw new NotImplementedException();
        }

        public static bool ElementByIdDisplayed(string elementName, int timeoutInSeconds = 30)
        {
            try
            {
                Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSeconds);

                IWebElement element = AppiumDriver.Instance.FindElement(By.Id(elementName));
                int maxCounter = timeoutInSeconds * 4;
                int counter = 0;
                while ((!((element.Displayed) && (element.Enabled))) && (counter <= maxCounter))
                //while ((!(element.Enabled)) && (counter <= maxCounter))
                {
                    Thread.Sleep(250);
                    counter++;
                }

                Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                return (element.Enabled);
            }
            catch (Exception ex)
            {
                Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                return false;
            }
        }

        public static bool WaitForPageSourceElement(string elementID, int numberWaitSeconds = 30)
        {
            bool elementFound = false;
            for (int i = 0; i < numberWaitSeconds; i++)
            {
                if (AppiumDriver.Instance.PageSource.Contains(elementID) == true)
                {
                    IWebElement foundElement = AppiumDriver.Instance.FindElement(By.Id(elementID));
                    if (foundElement.Displayed)
                    {
                        elementFound = true;
                        break;
                    }
                }

            }

            return elementFound;
        }


        public static bool ExplicitWaitForElement(string elementID, int numberWaitSeconds = 30)
        {
            bool elementFound = false;

            try
            {
                WebDriverWait wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(numberWaitSeconds));

                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(elementID)));

                elementFound = true;

            }
            catch
            {
                elementFound = false;
            }

            return elementFound;
        }


        public static void CloseDriverSession()
        {
            Instance.CloseApp();
            Instance.Quit();
        }
    }
}
