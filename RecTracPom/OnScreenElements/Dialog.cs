using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Threading;

namespace RecTracPom.OnScreenElements
{
    // a dialog instance is found not by a BY object as with many elements but by the text within the title
    public class Dialog 
    {
        private string sTitle;
        private IWebElement dialog;
        private IWebElement titleElement;


        // A dialog is identifable by the class of the div it lives in. It is uniquely identifiable by this class and the elements
        // of the title span
        public Dialog(string title)
        {
            sTitle = title;
            By byDialog = By.XPath("//div[@role='dialog']");
            By byTitle = By.XPath("//span[@class='ui-dialog-title' and text()='" + title + "']");

            System.TimeSpan waitTime = new System.TimeSpan(0, 0, 60);
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(BrowserWindow.Instance.Driver, waitTime);
            dialog = BrowserWindow.Instance.Driver.FindElement(byDialog);
            titleElement = dialog.FindElement(byTitle);
        }


        public IWebElement Title
        {
            get
            {
                return titleElement;
            }
        }

        public void ContinueButtonClick()
        {
            By finder = By.XPath("//button[@title='Continue']");
            Button btnContinue = new Button(finder);
            btnContinue.Click();

        }

        public void ClickButtonByButtonTitle(string title)
        {
            By finder = By.XPath("//button[@title='" + title + "']");
            Button btn = new Button(dialog, finder);  
            btn.Click();
        }

        public void CloseDialogByCloseButton()
        {
            // find the span with the desired text within the dialog and get the button parent.
            By finder = By.XPath("//span[@class='ui-button-text' and text()='Close']/..");
            // There are multiple CLOSE buttons on the dialog, the first of which is hidden
            // find the first (either X in upper right corner or CLOSE labled button) to click
            IReadOnlyCollection<IWebElement> elements = dialog.FindElements(finder);
            foreach (IWebElement element in elements)
            {
                if (element.Displayed == true)
                {
                    element.Click();
                    break;
                }
            }
        }
    }
}
