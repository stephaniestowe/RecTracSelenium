using RecTracPom;
using System;

namespace RecTracActions
{
    public static class Session
    {
        /// <summary>Standard opening sequence.:
        /// - Loads the RecTrac app in desired browser.
        /// - Logins in.
        /// - Checks for session and accepts session. If session existed, log out and log back in.</summary>
        public static void OpenStandard(BrowserWindow.Browsers browser, string url, string userName, string password)
        {
            BrowserWindow browserInstance = BrowserWindow.Instance;
            browserInstance.Browser = browser;
            browserInstance.Url = url;
            browserInstance.Load();
            PageLogin.Instance.Login(userName, password);
            if (PageLogin.Instance.IsContinueOnSession)
            {
                PageLogin.Instance.ContinueOnSession();
                LogoutEndSession();
                PageLogin.Instance.Login(userName, password);
            }
            
        }

        /// <summary>
        /// This loads the specified URL from a randomly selected browser in the browser enum. It is very important to not only run tests for the different browsers we support, but confirm the tests themselves remain stably cross browser compliant.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="userName">User for the login screen.</param>
        /// <param name="password">Password for the login screen .</param>
        public static void OpenStandardAnyBrowser(string url, string userName, string password)
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 3);

            BrowserWindow.Browsers browser = (BrowserWindow.Browsers)randomNumber;
            OpenStandard(browser, url, userName, password);

        }
        public static void LogoutEndSession()
        {
            PageHome.Instance.ClickBtnLogoutEndSession();
        }

        public static void CloseStandard()
        {
            LogoutEndSession();
            BrowserWindow.Instance.Close();
            
        }

        public static void OpenStandard(BrowserWindow.Browsers browser, Uri url, string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
