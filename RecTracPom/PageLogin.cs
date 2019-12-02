﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace RecTracPom
{
    public class PageLogin 
    {
        private static PageLogin instance = null;
        private By lookupRoot = By.Id("ng-login-container");
        private By byHeader = By.TagName("h1");
        private By byUserName = By.Name("username");
        private By byPassword = By.Name("password");
        private By bySignIn = By.TagName("button"); // only button on screen. Not often a good plan, but works here.
        private By byContinue = By.XPath("//button[text()='Continue']");
        private const string LoginContinue = "Login Prompts";
        private IWebDriver driver;

        private PageLogin()
        {
            // throw error if this is access where no instance of browserwindow? Or let the error bubble up?
            driver = BrowserWindow.Instance.Driver;
        }

        public static PageLogin Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageLogin();
                }
                return instance;
            }
        }

        public string Navigator => string.Empty;

        public void Login(string userName, string password)
        {
            driver.FindElement(byUserName).SendKeys(userName);
            driver.FindElement(byPassword).SendKeys(password);
            driver.FindElement(bySignIn).Click();
        }

        public string GetHeader()
        {
            return driver.FindElement(byHeader).Text;
        }

        public bool IsContinueOnSession
        {
            get
            {
                Thread.Sleep(2000); //TODO: Figure correct explicit wait.
                if (GetHeader() == LoginContinue)
                {
                    return true;
                }
                return false;
            }
        }

        public void ContinueOnSession()
        {
            if (IsContinueOnSession)
            {
                driver.FindElement(byContinue).Click();
            }
        }
    }
}
