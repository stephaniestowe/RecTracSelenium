using OpenQA.Selenium;
using RecTracPom.OnScreenElements;

namespace RecTracPom
{
    public class PageHome
    {
        private static PageHome instance = null;
        private IWebDriver driver;
        

        private PageHome()
        {
            // throw error if this is access where no instance of browserwindow? Or let the error bubble up?
            driver = BrowserWindow.Instance.Driver;
        }

        public static PageHome Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PageHome();
                }
                return instance;
            }
        }

        private static readonly By byLogoutEndSession = By.XPath("//button[@aria-label='Logout and End Session']");
        private static readonly By byMenu = By.XPath("//button[@aria-label='Menu']");
        private static readonly By byFilterMenu = By.CssSelector("#applications-popout > div.sidebar-popout-body > input");
        

        public void ClickBtnLogoutEndSession()
        {

            Button btnLogoutEndSession = new Button();

            btnLogoutEndSession.Finder = byLogoutEndSession;
            btnLogoutEndSession.Click();
        }

        public void Navigate(string navigateText)
        {
            Button btnMenu = new Button(byMenu);
            btnMenu.Click();
            Textbox txtFilterMenu = new Textbox(byFilterMenu);
            txtFilterMenu.SetText(navigateText);

            // specifically built xPath
            By byTicketManagement = By.XPath("//button[@title='" + navigateText + "']");
            Button btnTicketManagement = new Button(byTicketManagement);
            btnTicketManagement.Click();

        }
        


        


    }
}
