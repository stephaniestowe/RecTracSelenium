using RecTracPom;

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

        public static void LogoutEndSession()
        {
            PageHome.Instance.ClickBtnLogoutEndSession();
        }

        public static void CloseStandard()
        {
            LogoutEndSession();
            BrowserWindow.Instance.Close();
            
        }

    }
}
