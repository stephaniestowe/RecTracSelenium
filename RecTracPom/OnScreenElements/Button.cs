using OpenQA.Selenium;
using System.Threading;

namespace RecTracPom.OnScreenElements
{
    internal class Button : Element
    {
        public Button(By finder) : base(finder)
        {
        }

        public Button() : base()
        {

        }

        public void Click()
        {
            // Why bother having a click method of the button object when all you are doing is a webelement click?
            // in the event of a problem that is solved across all button clicks, there is one point of correction
            //WebElement.Click();
            ((IJavaScriptExecutor)BrowserWindow.Instance.Driver).ExecuteScript("arguments[0].click()", WebElement);
        }

    }
}
