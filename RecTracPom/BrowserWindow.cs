using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace RecTracPom
{
    public class BrowserWindow
    {
        const string driverLocation = "C:\\SeleniumDrivers";
        private static BrowserWindow instance = null;
        
        public enum Browsers
        {
            IE,
            Chrome,
            Edge,
        }

        private BrowserWindow() 
        {
            
        }

        public static BrowserWindow Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new BrowserWindow();
                }
                return instance;
            }
        }

        public string Url { get; set; }

        public Browsers Browser { get; set; }

        public IWebDriver Driver { get; private set; }

        public void Load()
        {
            // Url and Browser are necessary. Browser defaults to IE and is never empty.
            if (string.IsNullOrEmpty(this.Url))
            {
                // throw invalid operation exception
                throw new InvalidOperationException("Url property must be set to use parameterless LoadHome.");
            }

            Load(Url, Browser);
            
        }

        public void Load(string Url, Browsers Browser)
        {
            this.Url = Url;
            this.Browser = Browser;

            IWebDriver driver;
            
            switch (Browser)
            {
                case Browsers.IE:
                    driver = new InternetExplorerDriver(driverLocation);
                    driver.Manage().Window.Maximize();
                    break;
                case Browsers.Edge:
                    driver = new EdgeDriver(driverLocation);
                    driver.Manage().Window.Maximize();
                    break;
                case Browsers.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    driver = new ChromeDriver(driverLocation, options);
                    break;
                default:
                    driver = new InternetExplorerDriver(driverLocation);
                    break;

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver = driver;
            driver.Url = this.Url;
        }

        public void Close()
        {
            Driver.Close();
            Driver.Dispose();
        }
    }
}
