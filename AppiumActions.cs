
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace IsaMobile_Appium_POC
{
    // property type enumeration
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        ClassName
    };

    public enum SwipeDirections { UP = 1, DOWN, LEFT, RIGHT };

    public class AppiumActions
    {


        public static void Swipe(SwipeDirections eSwipeDirection)
        {
            int startx, starty, endx, endy;


            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;


            if (eSwipeDirection == SwipeDirections.DOWN)
            {
                // get the proper location of where to start to swipe from
                startx = size.Width / 2;
                starty = 100;

                endx = startx;
                endy = (int)(size.Height * 0.9) - 50;
            }
            else if (eSwipeDirection == SwipeDirections.UP)
            {
                // get the proper location of where to start to swipe from
                startx = size.Width / 2;
                starty = (int)(size.Height * 0.76);

                endx = startx;
                endy = (int)(size.Height * 0.25); ;
            }
            else if (eSwipeDirection == SwipeDirections.LEFT)
            {
                // get the proper location of where to start to swipe from
                startx = (int)(size.Width * 0.9) - 50;
                starty = (int)(size.Height * 0.75);

                endx = 50;
                endy = starty;
            }
            else   // must be right then
            {
                // get the proper location of where to start to swipe from
                startx = 10;
                starty = size.Height / 2;

                endx = (int)(size.Width * 0.9) - 50;
                endy = starty;
            }

            // perform the swipe
            AppiumDriver.Instance.Swipe(startx, starty, endx, endy, 2000);
        }


        public static void SwipeElement(IWebElement element, SwipeDirections eSwipeDirection)
        {
            int startx, starty, endx, endy;

            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            System.Drawing.Size size = element.Size;
            int locX = element.Location.X;
            int locY = element.Location.Y;

            if (eSwipeDirection == SwipeDirections.DOWN)
            {
                // get the proper location of where to start to swipe from
                startx = size.Width / 2;
                starty = 100;

                endx = startx;
                endy = (int)(size.Height * 0.8) - 100;
            }
            else if (eSwipeDirection == SwipeDirections.UP)
            {
                // get the proper location of where to start to swipe from
                startx = size.Width / 2;
                starty = 100;

                endx = startx;
                endy = (int)(size.Height * 0.8) - 100;
            }
            else if (eSwipeDirection == SwipeDirections.LEFT)
            {
                // get the proper location of where to start to swipe from
                startx = locX + (size.Width - 40);
                starty = locY + (int)(size.Height / 2);

                endx = locX + 40;
                endy = starty;
            }
            else   // must be right then
            {
                // get the proper location of where to start to swipe from
                startx = 200;
                starty = size.Height / 2;

                endx = (int)(size.Width * 0.8) - 50;
                endy = starty;
            }

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, endx, endy, 2000);
        }


        public static void ScrollDownAndroid(int intAmountToScroll)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width / 2;
            int starty = (int)(size.Height * 0.8) - 100;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, starty - intAmountToScroll, 1000);
        }

        public static void ScrollDownAndroidPropertyFlyer(int intAmountToScroll)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width / 2;
            int starty = (int)(size.Height / 1.5);

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, starty - intAmountToScroll, 1000);
        }


        public static void ScrollUpAndroid(int intAmountToScroll)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width / 2;
            //int starty = 800;
            int starty = (int)(size.Height * 0.4) - 100;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, starty + intAmountToScroll, 1000);
        }

        public static void ScrollTillAnElement(string xPath)
        {
            IWebElement element = AppiumDriver.Instance.FindElementByXPath(xPath);
            ((IJavaScriptExecutor)AppiumDriver.Instance).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void TouchActions(int scrollX, int scrollY)
        //TouchActions(int scrollX, int scrollY)
        {
            TouchAction touchAction4 = new TouchAction(AppiumDriver.Instance);
            touchAction4.Press(0, 900).MoveTo(scrollX, scrollY).Release();
            AppiumDriver.Instance.PerformTouchAction(touchAction4);
        }

        public static void ScrollTo()
        {
            //AppiumDriver.Instance.Swipe(0, 900, 0, 6050, 1000);
        }


        public static void ScrollVerticalPercentage(int fromPercentage, int toPercentage)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startX = 100;
            double dblStartY = size.Height * ((float)fromPercentage / 100);
            double dblEndY = size.Height * ((float)toPercentage / 100);

            int startY = Convert.ToInt32(dblStartY);
            int endY = Convert.ToInt32(dblEndY);

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startX, startY, startX, endY, 1000);
        }

        public static void PageDownAndroid()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            //int startx = (int)(size.Width / 2) - 10;
            int startx = size.Width - 250;
            int starty = (int)(size.Height * 0.8) - 10;
            int endy = 25;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }

        public static void PageDownAndroidFlyer()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            //int startx = (int)(size.Width / 2) - 10;
            int startx = size.Width - 250;
            int starty = (int)(size.Height * 0.8) + 30;
            int endy = 25;

            // perform the swipe
            //ppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }

        public static void PageDownAndroidPropertyDetail()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            //int startx = (int)(size.Width / 2) - 10;
            int startx = size.Width - 250;
            int starty = (int)(size.Height * 0.8) - 10;
            int endy = 800;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }


        public static void SwipeFromTo(int startX, int startY, int endX, int endY)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startX, startY, endX, endY, 1000);
        }

        public static void PropertyDetailsPageDownAndroid()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width / 2) + 50;
            int starty = (int)(size.Height * 0.8) - 100;
            int endy = 50;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }

        public static void LoginPageDown()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width / 6) - 50;
            int starty = (int)(size.Height * 0.8) - 800;
            int endy = 100;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }

        public static void PageDownIOS()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width / 2) - 50;
            int starty = (int)(size.Height * 0.8) - 800;
            int endy = 100;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }


        public static void SettingsPageDown()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width / 6) - 50;
            int starty = (int)(size.Height * 0.8) - 800;
            int endy = 200;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }

        public static void SettingsPageUp()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width / 6) - 50;
            int starty = (int)(size.Height * 0.8) - 400;
            int endy = 500;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);

            //AppiumDriver.Instance.Swipe(startx, endy, startx, starty, 1000);
        }


        public static bool TryFindElementById(By by)
        {
            bool elementFound = true;
            IWebElement elementToFind = null;

            try
            {
                elementToFind = AppiumDriver.Instance.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                elementFound = false;
            }

            return elementFound;
        }

        public bool IsElementVisible(IWebElement element)
        {
            return element.Displayed && element.Enabled;
        }



        public static void TapScreenLowerAndroid()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width - 25;
            int starty = size.Height - 25;

            // perform the tap
            //AppiumDriver.Instance.Tap(1, startx, starty, 1);
        }



        public static void TapScreenUpperAndroid()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width / 2;
            int starty = 100;

            // perform the tap
            //AppiumDriver.Instance.Tap(1, startx, starty, 3);
        }


        public static void TapScreenUpperRightAndroid()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width - 100;
            int starty = 100;

            // perform the tap
            //AppiumDriver.Instance.Tap(1, startx, starty, 1);
        }

        public static void TapScreenUpperRightIOS()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width - 100;
            int starty = 300;

            // perform the tap
            //AppiumDriver.Instance.Tap(1, startx, starty, 1);
        }

        public static void TapScreenMiddleAndroid()
        {
            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width / 2;
            int starty = size.Height / 2;

            // perform the tap
            //AppiumDriver.Instance.Tap(1, startx, starty, 1);
        }

        public static void TapCompScreenAndroid()
        {
            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = size.Width / 2;
            int starty = (size.Height / 2) - 280;

            // perform the tap
            //AppiumDriver.Instance.Tap(1, startx, starty, 1);
        }


        public static void TapScreenLocation(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            //AppiumDriver.Instance.Tap(1, xPos, yPos, 1);
        }

        public static void UserSettingsSlideRES(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 300);
            tAction.Press(xPos, yPos).MoveTo(moveTo, yPos).Release();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }

        public static void DistanceAdjustSlide(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 200);
            tAction.Press(xPos, yPos).MoveTo(moveTo, yPos).Release();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }


        public static void UserSettingsSlideRESIOS(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 700);
            int start = (int)(xPos + 820);
            tAction.Press(start, yPos).MoveTo(moveTo, yPos).Release();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }

        public static void UserSettingsSlideRESSoldIOS(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 300);
            int start = (int)(xPos + 570);
            tAction.Press(start, yPos).MoveTo(moveTo, yPos).Release();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }

        public static void UserSettingsSlideCOMM(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 500);
            tAction.Press(xPos, yPos).MoveTo(moveTo, yPos).Release();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }

        public static void UserSettingsSlideCOMMIOS(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 600);
            int start = (int)(xPos + 820);
            tAction.Press(start, yPos).MoveTo(moveTo, yPos).Release();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }


        public static void MarketActivitySlide(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 500);
            tAction.Press(xPos, yPos).MoveTo(moveTo, yPos).Release();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }

        public static void TravelTimeWalkTimePin(int xPos, int yPos)
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            int moveTo = (int)(xPos + 1);
            tAction.Press(xPos, yPos).Wait(1).MoveTo(moveTo, yPos).Release().Perform();
            AppiumDriver.Instance.PerformTouchAction(tAction);
        }



        public static void ScrollDownToElement(IWebElement element)
        {
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            scrollObject.Add("direction", "down");

            GetBack:
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    if (element.Displayed)
                    {
                        break;
                    }
                    else
                    {
                        ((IJavaScriptExecutor)AppiumDriver.Instance).ExecuteScript("mobile: scroll", scrollObject);
                    }
                }
            }
            catch 
            {
                goto GetBack;
            }
        }



        public static void ScrollUpToElement(IWebElement element)
        {
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            scrollObject.Add("direction", "up");

        GetBack:
            try
            {
                for (int i = 0; i < 12; i++)
                {
                    if (element.Displayed)
                    {
                        break;
                    }
                    else
                    {
                        ((IJavaScriptExecutor)AppiumDriver.Instance).ExecuteScript("mobile: scroll", scrollObject);
                    }
                }
            }
            catch
            {
                goto GetBack;
            }
        }


        public static void iOSScrollDownToElement(string elementName)  //, IWebElement element)
        {
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            scrollObject.Add("direction", "down");
            //scrollObject.Add("name", elementName);
            scrollObject.Add("toVisible", "true");
            ((IJavaScriptExecutor)AppiumDriver.Instance).ExecuteScript("mobile: scroll", scrollObject);
        }

        public static void AndroidBack()
        {
            AppiumDriver.Instance.Navigate().Back();
        }

        public static void Scroll(int ScrollAmount)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)AppiumDriver.Instance;
            js.ExecuteScript("window.scrollBy(0," + ScrollAmount + ")");
        }
        public static void ScrollUp()
        {
            Dictionary<string, string> scrollObject = new Dictionary<string, string>();
            scrollObject.Add("direction", "up");
            ((IJavaScriptExecutor)AppiumDriver.Instance).ExecuteScript("mobile:scroll", scrollObject);
        }
        public static void ScrollDown()
        {
            Dictionary<String, String> scrollObject = new Dictionary<String, String>();
            scrollObject.Add("direction", "down");
            ((IJavaScriptExecutor)AppiumDriver.Instance).ExecuteScript("mobile:scroll", scrollObject);
        }


        public static void DrawRectagle(Point upperLeft, int height, int width)
        {
            // Using Touch Action Classes
            TouchAction tAction1 = new TouchAction(AppiumDriver.Instance);
            //TouchAction tAction2 = new TouchAction(AppiumDriver.Instance);
            //TouchAction tAction3 = new TouchAction(AppiumDriver.Instance);
            //TouchAction tAction4 = new TouchAction(AppiumDriver.Instance);
            //TouchAction tAction5 = new TouchAction(AppiumDriver.Instance);
            //TouchAction tAction6 = new TouchAction(AppiumDriver.Instance);

            // perform the swipe
            tAction1.Press(upperLeft.X, upperLeft.Y);
            tAction1.MoveTo(upperLeft.X, upperLeft.Y + height);
            tAction1.MoveTo(upperLeft.X + width, upperLeft.Y + height);
            tAction1.MoveTo(upperLeft.X + width, upperLeft.Y);
            tAction1.MoveTo(upperLeft.X, upperLeft.Y);
            tAction1.Release();

            //MultiAction mAction = new MultiAction(AppiumDriver.Instance);
            //mAction.Add(tAction1).Add(tAction2).Add(tAction3).Add(tAction4).Add(tAction5).Add(tAction6);
            tAction1.Perform();

            // perform the swipe
            //tAction1.Press(upperLeft.X, upperLeft.Y).MoveTo(upperLeft.X, upperLeft.Y + height).MoveTo(upperLeft.X + width, upperLeft.Y + height).MoveTo(upperLeft.X + width, upperLeft.Y).MoveTo(upperLeft.X, upperLeft.Y).Release().Perform();
        }

        public static void ClickOKButtonIfExists()
        {
            AppiumDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(AppiumDriver.Instance.FindElements(By.Id("OK")));

            if (elementList.Count > 0)
            {
                //If the count is greater than 0 your element exists.
                elementList[0].Click();
            }

            AppiumDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }


        public static void ClickSystemDownOKButton()
        {
            AppiumDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            List<IWebElement> elementList = new List<IWebElement>();
            elementList.AddRange(AppiumDriver.Instance.FindElements(By.XPath("//*[contains(@Text,'OK')]")));

            if (elementList.Count > 0)
            {
                //If the count is greater than 0 your element exists.
                elementList[0].Click();
            }

            AppiumDriver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        public static void FindAndClick(String val)
        {
            IWebElement element = AppiumDriver.Instance.FindElement(By.XPath(val));
            IJavaScriptExecutor js = (IJavaScriptExecutor)AppiumDriver.Instance;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            js.ExecuteScript("window.scrollBy(0,-100)");
            element.Click();
        }

        public static void ScollAndClick(string val)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)AppiumDriver.Instance;

            do 
            {
                try
                {
                        IWebElement element = AppiumDriver.Instance.FindElement(By.XPath(val));
                        js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                        element.Click();
                        break;
                }
                catch
                {

                    IWebElement element = AppiumDriver.Instance.FindElement(By.XPath(val));
                    js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
                    element.Click();
                    break;

                }
            } while(true);
        }


        public static void PressAndHoldElement(IWebElement webElement)
        {
            TouchAction action = new TouchAction(AppiumDriver.Instance);
            action.LongPress(webElement).Perform();
        }

        public static void TapElement(IWebElement webElement)
        {
            TouchAction action = new TouchAction(AppiumDriver.Instance);
            action.Tap(webElement).Perform();
        }

        public static void HoverAndClick(IWebElement webElement)
        {
            Actions action = new Actions(AppiumDriver.Instance);
            action.MoveToElement(webElement).Click(webElement).Build().Perform();
            //action.moveToElement(webElement).click(elementToClick).build().perform();
        }

      

        public static void SendKeysTab()
        {
            AppiumDriver.Instance.ExecuteScript("experitest:client.run(\"adb shell input keyevent 61\")");
            
          
        }

        public static void SendKeysBack() //Android Back Button
        {
            AppiumDriver.Instance.ExecuteScript("experitest:client.run(\"adb shell input keyevent 4\")");


        }

        public static void SendKeysHome() //Android Home Button
        {
            AppiumDriver.Instance.ExecuteScript("experitest:client.run(\"adb shell input keyevent 3\")");


        }

        public static void SendKeysRecentApps() //Android Recent Apps Button
        {
            AppiumDriver.Instance.ExecuteScript("experitest:client.run(\"adb shell input keyevent 187\")");
        }

        public static void PropertyDetailPhotoSwipe(SwipeDirections eSwipeDirection)
        {
            int startx, starty, endx, endy;


            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;

            if (eSwipeDirection == SwipeDirections.LEFT)
            {
                // get the proper location of where to start to swipe from
                startx = (int)(size.Width * 0.9) - 50;
                starty = (int)(size.Height / 3);

                endx = 50;
                endy = starty;
            }

            else   // must be right then
            {
                // get the proper location of where to start to swipe from
                startx = 10;
                starty = size.Height / 3;

                endx = (int)(size.Width * 0.9) - 50;
                endy = starty;
            }

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, endx, endy, 2000);
        }

        public static void ReportsOptionsPageDown()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width) - 100;
            int starty = (int)(size.Height * 0.8) - 400;
            int endy = 500;

            // perform the swipe
            //AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);

           // AppiumDriver.Instance.Swipe(startx, starty, startx, endy, 1000);
        }

        public static void ReportsOptionsPageUp()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width) - 100;
            int starty = (int)(size.Height * 0.8) - 400;
            int endy = 550;

            //AppiumDriver.Instance.Swipe(startx, endy, startx, starty, 1000);
        }

        public static void ReportsOptionsPageUpTablet()
        {

            // Using Touch Action Classes
            TouchAction tAction = new TouchAction(AppiumDriver.Instance);

            // get the proper location of where to start to swipe from
            System.Drawing.Size size = AppiumDriver.Instance.Manage().Window.Size;
            int startx = (int)(size.Width / 2);
            int starty = (int)(size.Height - 100);
            int endy = 1150;

            //AppiumDriver.Instance.Swipe(startx, endy, startx, starty, 1000);
        }

    }
}
      
   
