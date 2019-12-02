using OpenQA.Selenium;

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
        // To find stably, these will be used in conjunction to find the dialog root rather than a simple series of By objects
        internal Dialog(string title)
        {
            sTitle = title;
            By byDialog = By.XPath("//div[contains(@class, 'ui-dialog')]");
            By byTitle = By.XPath("//span[@class='ui-dialog-title' and text()='" + title +"']");
            try
            {
                dialog = BrowserWindow.Instance.Driver.FindElement(byDialog);
                titleElement = dialog.FindElement(byTitle);
            }
            catch(OpenQA.Selenium.NoSuchElementException)
            {
                throw new NoSuchElementException("The desired dialog does not exist with the given title.");
            }
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
            Button btn = new Button(finder);
            btn.Click();
        }
    }
}
