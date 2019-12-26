using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Threading;

namespace RecTracPom
{
    /// <summary>Exposes button objects that are common to module pages like teh CLOSE button visuble on tab hover.</summary>
    public static class PanelModuleCommon
    {
        private static By byAddButton = By.XPath("//button[@title='Add']");
        private static By byMoreButton = By.XPath("//button[@title='More']");
        private static By byDeleteButton = By.XPath("//button[@title='Delete']");
        private static By byChangeButton = By.XPath("//button[@title='Change']");
        private static By byClosePanelButton = By.XPath("//button[@title='Close Panel']");
        private static By byTab = By.XPath("//a[@class='active header-tab']");
            

        public static void AddButtonClick()
        {
            Thread.Sleep(2000);
            Button btnAdd = new Button(byAddButton);
            btnAdd.Click();
        }

        public static void MoreButtonClick()
        {
            Button btnMore = new Button(byMoreButton);
            btnMore.Click();
        }

        public static void DeleteButtonClick()
        {
            Button btnDelete = new Button(byDeleteButton);
            btnDelete.Click();
        }

        public static void ChangeButtonClick()
        {
            Thread.Sleep(1000);
            Button btnChange = new Button(byChangeButton);
            btnChange.Click();
        }

        /// <summary>  Does the combination of actions/clicks to perform a delete with dialog responses (where applicable).</summary>
        public static void DoDeleteEntire()
        {
            MoreButtonClick();
            DeleteButtonClick();
            Dialog dlgInfo = new Dialog("Information");
            dlgInfo.ClickButtonByButtonTitle("Yes");
        }

        /// <summary>Hovers over active module tab to expose the close button then clicks the close button.</summary>
        public static void DoCloseActiveTabEntire()
        {
            // So there is a defect in EDGE whereby the behavior of the code containted in the hover on the tab executes without
            // error but the action underneath does not occur. So in Edge, callng the hover method of the TAB as seen in the else condition 
            // below
            // 
            IWebElement close;
            
            if (BrowserWindow.Instance.Browser == BrowserWindow.Browsers.Edge)
            {
                close = BrowserWindow.Instance.Driver.FindElement(byClosePanelButton);
                string js = "arguments[0].style.height='auto'; arguments[0].style.visibility='visible'; arguments[0].style.display='inline';";
                IWebDriver driver = BrowserWindow.Instance.Driver;
                IWebElement element = close;
                ((IJavaScriptExecutor)driver).ExecuteScript(js, element);
            }
            else
            {
                Element tab = new Element(byTab);
                tab.Hover();
                close = new Button(byClosePanelButton).WebElement;
            }
            close.Click();
        }
    }
}
