using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace IsaMobile_Appium_POC
{
    public class MobileLogin
    {

        // Log In Button
        public static IWebElement LogInButton
        {
            get
            {
                return AppiumDriver.Instance.FindElementByAccessibilityId("buttonLogin");
            }
        }

        public static void ClickLoginButton()
        {
            AppiumDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(AppiumDriver.Instance.FindElements(By.ClassName("android.widget.Button")));

            if (elementList.Count > 0)
            {
                //If the count is greater than 0 your element exists.
                elementList[0].Click();
            }

            AppiumDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        public static IWebElement UserName
        {
            get
            {
                return AppiumDriver.Instance.FindElementByAccessibilityId ("entryUsername");  ////*[@name='entryUsername']
            }
        }


        public static IWebElement Password
        {
            get
            {
                return AppiumDriver.Instance.FindElementByAccessibilityId("entryPassword");
            }
        }

        public static void ClickProfileButton()
        {
            List<IWebElement> elementList = new List<IWebElement>();
            //elementList.AddRange(AppiumDriver.Instance.FindElementsByClassName("android.widget.FrameLayout"));
           //var profileElement = AppiumDriver.Instance.FindElementByXPath("(//*[@class='android.view.ViewGroup' and ./parent::*[@class='android.widget.FrameLayout' and ./parent::*[@class='android.widget.RelativeLayout']]]/*[./*[@id='icon']])[5]");
            var profileElement = AppiumDriver.Instance.FindElementByXPath("//*[@resource-id='com.isagenix.qualia:id/icon']");
            profileElement.Click();
            //if (elementList.Count > 0)
            //{
            //    //If the count is greater than 0 your element exists.
            //    elementList[4].Click();
            //}
        }

        public static IWebElement LogOutButton
        {
            get
            {
                return AppiumDriver.Instance.FindElement(By.Name("buttonSignOut"));
            }
        }
        

    }
}
