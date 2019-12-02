﻿using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.ObjectModel;

namespace RecTracPom
{
    public class ModulePosTicketManagement : IModule
    {
        private static By byTicketCodeFilter = By.XPath("//input[contains(@name,'filter_psticketmain_ticketcode')]");
        private static By byTicketDataTable = By.XPath("//table[starts-with(@id, 'psticketmainmain_datagrid')]");
        private static By byTicketHeaderTable = By.XPath("//table"); //first table is header table.
        private static By byCellTicketCode = By.XPath("//td[@data-property='psticketmain_ticketcode']");
        private static By byShortDescription = By.XPath("//td[@data-property='psticketmain_shortdescription']/div"); // get the div within the cell for the text
        private static ModulePosTicketManagement instance = null;

        private ModulePosTicketManagement()
        {

        }

        public static ModulePosTicketManagement Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModulePosTicketManagement();
                }
                return instance;
            }
        }

        public static void SetTicketCodeFilter(string ticketCode)
        {
            Textbox txtFilterCode = new Textbox(byTicketCodeFilter);
            txtFilterCode.SetText(ticketCode, Textbox.KeyToPress.Enter);
            
        }

        public static string GetShortDescription
        {
            get
            {
                Element lbl = new Element(byShortDescription);
                return lbl.Text;
            }
        }

        public static int TicketCount
        {
            get
            {
                Table table = new Table(byTicketDataTable);
                return table.RowCount();
            }
        }


        public Table DataGrid
        {
            get
            {
                return new Table(byTicketDataTable);
            }
        }

        public static bool IsTicketExists(string ticketCode)
        {
           
            
            SetTicketCodeFilter(ticketCode);
            Table table = new Table(byTicketDataTable);
            
            foreach (IWebElement row in table.Rows)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> cols = row.FindElements(byCellTicketCode);

                    foreach (IWebElement col in cols)
                    {
                        if (col.Text.ToLower() == ticketCode.ToLower())
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }

        public void DoPrimaryFilter(string value)
        {
            SetTicketCodeFilter(value);
        }

        public string GetChangedText()
        {
            return GetShortDescription;
        }
    }
}
