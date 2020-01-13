using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecTracActions;
using RecTracPom;
using System;

namespace RecTracSelenium.ManagementTests
{
    [TestClass]
    public class ManagementTests
    {
        private const string url = "http://qa-stephanies:4180/wbwsc/clientdemo.wsc/login.html?InterfaceParameter=RecTracNextGenStephanie#/login";
        private const BrowserWindow.Browsers browser = BrowserWindow.Browsers.Edge;


        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void Startup()
        {
            Session.OpenStandardAnyBrowser(url, "zzz", "password");
            
        }

        [TestCleanup]
        public void Cleanup()
        {
           Session.CloseStandard();
        }

        [TestMethod]
        public void Crud()
        {
            //TODO: Look at an assert failure... what happens to the rest of the run?
            // bind this to an event handler. Research.
            CrudDriver driver = CrudDriver.Instance;
            foreach (CrudItem item in driver.Items)
            {
                try
                {
                    item.Navigate();
                    item.Add();
                    bool success = item.CheckExists();
                    Assert.IsTrue(!success);

                    item.Change();
                    success = item.CheckChange();
                    Assert.IsTrue(success);

                    if (item.IsClonable)
                    {
                        item.Clone();
                        success = item.CheckClone();
                        Assert.IsTrue(success);
                        item.CleanupClone();
                    }

                    item.Delete();
                    Assert.IsFalse(item.CheckExists(), "Deleted item does not exist.");

                    item.CloseActiveTab();
                }
                catch(Exception e)
                {
                    // close out previous item for next item
                    Session.CloseStandard();
                    Session.OpenStandardAnyBrowser(url, "zzz", "password");
                }

            }
        }

    }
}
