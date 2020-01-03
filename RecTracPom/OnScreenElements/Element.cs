using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace RecTracPom.OnScreenElements
{
    /// <summary>
    /// This is the base class that is inherited by many of the other onscreen object elements like textbox and button. It's Selenium WebElement getter has a wait for the element to become visible at acquisition improving stability.
    /// </summary>
    public class Element
    {
        private By finder;
        private IWebElement root = null;

        public Element(By finder)
        {
            this.finder = finder;
        }

        public Element(IWebElement root, By finder)
        {
            this.root = root;
            this.finder = finder;
        }
        public Element()
        {

        }

        public By Finder
        {
            set
            {
                finder = value;
            }
        }

        public IWebElement WebElement
        {
            get
            {
                IWebElement element;
                if (finder == null)
                {
                    throw new ArgumentOutOfRangeException("Finder", "Must set Finder property either in constructor or with the property setter itself. Finder cannot be null.");
                }
                System.TimeSpan waitTime = new System.TimeSpan(0, 0, 20);
                OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(BrowserWindow.Instance.Driver, waitTime);
                if (root == null)
                {
                    element = wait.Until(ExpectedConditions.ElementIsVisible(finder));
                }
                else
                {
                    element = root.FindElement(finder);
                    
                }
                return element;
            }
        }

        public string Text
        {
            get
            {
                return WebElement.Text;
            }
        }

        public void Hover()
        {
            Actions action = new Actions(BrowserWindow.Instance.Driver);
            action.MoveToElement(WebElement).Build().Perform();
            Thread.Sleep(1000);
            
        }

        public void Click()
        {
            
            // According the Stack Overflow, firefox needs a wee second for click. We should certainly be open to 
            // different solutions.
            if (BrowserWindow.Instance.Browser == BrowserWindow.Browsers.Firefox)
            {
                Thread.Sleep(1000);
            }

            WebElement.Click();
        }

    }
}
