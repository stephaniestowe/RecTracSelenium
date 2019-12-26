using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecTracPom;
using RecTracActions;


namespace RecTracSelenium.TicketTests
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
            Session.OpenStandard(browser, url, "zzz", "password");
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
                bool success = item.CheckExists();
                Assert.IsTrue(success);
      
                item.Change();
                success = item.CheckChange();
                Assert.IsTrue(success);
                item.Delete();
                Assert.IsFalse(item.CheckExists(), "Deleted item does not exist.");
                item.CloseActiveTab();
            }
        }

    }
}
