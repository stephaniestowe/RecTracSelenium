using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace WebTracPom
{
    public class BrowserWindow
    {
        const string driverLocation = "C:\\SeleniumDrivers";
        private static BrowserWindow instance = null;

        public enum Browsers
        {
            Chrome,
            Edge,
            Firefox
        }

        private BrowserWindow()
        {
            // default value
            Browser = Browsers.Chrome;
        }

        public static BrowserWindow Instance
        {
            get
            {
                if (instance == null)
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
                case Browsers.Edge:
                    driver = new EdgeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case Browsers.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    driver = new ChromeDriver(driverLocation, options);
                    break;
                case Browsers.Firefox:

                    driver = new FirefoxDriver(driverLocation);
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    driver = new ChromeDriver(driverLocation);
                    break;

            }
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            Driver = driver;
            driver.Url = this.Url;
        }

        public void Close()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
