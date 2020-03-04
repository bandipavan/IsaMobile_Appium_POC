
using System;
using OpenQA.Selenium;

namespace IsaMobile_Appium_POC
{

    public class MobileLogInPage : MobileLogin
    {
        /// <summary>
        /// Returns new instance of MobileLoginCommand instance
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static MobileLoginCommand LoginAs(string userName)
        {
            return new MobileLoginCommand(userName);
        }

        /// <summary>
        /// Determines if currently displaying login page
        /// </summary>
        /// <returns>boolean value indicating at login page</returns>
        public static bool CurrentlyAtLoginPage()
        {
            bool atLoginPage = false;

             if (AppiumDriver.Instance.FindElements(By.Id("login_username")).Count > 0)
            {
                atLoginPage = true;
            }
            else
            {
                atLoginPage = false;
            }


            return atLoginPage;
        }

        public static void MobileLogOut()
        {
            try
            {
                AppiumActions.ScrollDown();
                LogOutButton.Click();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        /// <summary>
        /// If already logged in, log out so that proper startup sequence can occur
        /// </summary>
        public static void LogOutIfAlreadyLoggedIn()
        {
            try
            {
                if (AppiumDriver.Instance.PageSource.Contains("login_logo") == false)
                {
                    AppiumDriver.Instance.FindElement(By.Id("action_home")).Click();
                    AppiumDriver.Instance.FindElement(By.Id("action_settings")).Click();
                    MobileLogOut();
                    //AppiumDriver.CloseDriverSession();
                }

                else if (AppiumDriver.Instance.PageSource.Contains("login_logo") == true)
                    return;

                    //LogResults.LogInfo("Able to log-out if already logged in upon startup.");
            }
            catch (Exception ex)
            {
                //LogResults.LogFail("Failed to log-out if already logged in upon startup. " + ex);
            }

            //AppiumDriver.CloseDriverSession();
        }

      
    }


    public class MobileLoginCommand : MobileLogin
    {
        private readonly string userName;
        private string password;

        /// <summary>
        /// updates the local user name class variable
        /// </summary>
        /// <param name="userName"></param>
        public MobileLoginCommand(string userName)
        {
            this.userName = userName;
        }


        /// <summary>
        /// updates the local password class variable
        /// </summary>
        /// <param name="password"></param>
        /// <returns>instance of MobileLoginCommand</returns>
        public MobileLoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }


        /// <summary>
        /// Perform the login action itself
        /// </summary>
        public void Login()
        {
            try
            {
                GenericUtilities.Wait(5);
                if (UserName.Text.Equals(userName) == false)
                {
                    if (UserName.Text != "")
                        UserName.Clear();
                    UserName.SendKeys(userName);
                }
                if (Password.Text != "")
                    Password.Clear();
                Password.SendKeys(password);

                //try
                //{
                //    AppiumDriver.Instance.HideKeyboard();
                //}
                //catch
                //{ }


                GenericUtilities.Wait(3);
                //UserName.Click(); //There is an issue with Password field when cursor is in it, unable to click SignIn button, do not remove this. 
                LogInButton.Click();
                //LogResults.LogPass("Signed In successfully");
                }
                catch (Exception ex)
                {
                    //LogResults.LogFail("Failed to Login" + ex.InnerException.Message);
            }

        }


    }
}


