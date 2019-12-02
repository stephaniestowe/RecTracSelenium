using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecTracPom;
using RecTracPom.OnScreenElements;
using RecTracActions;


namespace RecTracSelenium.Ticket
{
    [TestClass]
    public class TicketTests
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
        public void AddDeleteTicket()
        {
            const string ticketCode = "This is a ticket";
            RecTracActions.Ticket.NavigateTicketManagement();
            RecTracActions.Ticket.AddTicket(ticketCode);
            bool exists = RecTracActions.Ticket.IsTicketExists(ticketCode);
            Assert.IsTrue(exists);
            RecTracActions.Ticket.DeleteTicket(ticketCode);
            exists = RecTracActions.Ticket.IsTicketExists(ticketCode);
            Assert.IsFalse(exists);
        }

        [TestMethod]
        public void Crud()
        {
            Assert.IsTrue(CRUDDriver.Drive());

        }

    }
}
