// ***********************************************************************
// Assembly         : RecTracPom
// Author           : stephanieas
// Created          : 11-05-2019
//
// Last Modified By : stephanieas
// Last Modified On : 01-08-2020
// ***********************************************************************
// <copyright file="BrowserWindow.cs" company="Vermont Systems Inc.">
//     Copyright ©  2019
// </copyright>
// <summary>Browser Window is the class responsible for loading the web browser and holding the instance of the Selenium WebDriver that is used in the remainder of the solution.
//</summary>
// ***********************************************************************
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace RecTracPom
{
    public class BrowserWindow
    {
        const string driverLocation = "C:\\SeleniumDrivers";
        private static BrowserWindow instance = null;

        /// <summary>  Browser that the tests in solution can run.</summary>
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
            if (string.IsNullOrEmpty(Url))
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
            driver.Url = this.Url.ToString();
        }

        public void Close()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
