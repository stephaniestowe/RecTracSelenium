using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecTracPom;
using RecTracPom.OnScreenElements;
using RecTracActions;


namespace RecTracSelenium.TicketTests
{
    [TestClass]
    public class ManagementTests
    {
        private const string url = "http://qa-stephanies:4180/wbwsc/clientdemo.wsc/login.html?InterfaceParameter=RecTracNextGenStephanie#/login";

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestInitialize]
        public void Startup()
        {
            Session.OpenStandard(BrowserWindow.Browsers.Chrome, url, "zzz", "password");
        }

        [TestCleanup]
        public void Cleanup()
        {
            Session.CloseStandard();
        }

        [TestMethod]
        public void Crud()
        {
            CrudDriver driver = CrudDriver.Instance;
            foreach (CrudItem item in driver.Items)
            {
                item.Navigate();
                
                item.Add();
                Assert.IsTrue(item.CheckExists(), "Added item exists.");
                item.Change();
                Assert.IsTrue(item.CheckChange(), "Item change successful.");
                item.Delete();
                Assert.IsFalse(item.CheckExists(), "Deleted item does not exist.");
                item.CloseActiveTab();
            }
        }
    }
}
