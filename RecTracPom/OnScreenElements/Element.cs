using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace RecTracPom.OnScreenElements
{
    public class Element
    {
        private By finder;

        public Element(By finder)
        {
            this.finder = finder;
        }

        public Element()
        {

        }

        public By Finder
        {
            set
            {
                // TODO: Re think SINGLTEON (which I have not done here, why do I do it in pages?).
                // Does ANYTHING have to be a singleton if we are just using the contrsuctor to get a 
                // new instance of the brwoser window instance?
                finder = value;
            }


        }

        public IWebElement WebElement
        {
            get
            {
                System.TimeSpan waitTime = new System.TimeSpan(0, 0, 20);
                OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(BrowserWindow.Instance.Driver, waitTime);
                IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(finder));
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
            action.MoveToElement(WebElement).Perform();
        }

    }
}
