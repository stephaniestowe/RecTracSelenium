using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RecTracPom.OnScreenElements
{
    public class Table : Element
    {
        private By finder;
        private By byRows = By.XPath("//tbody/tr[contains(@class, 'ui-state-default')]"); 

        public Table(By finder)
        {
            this.finder = finder;
        }

        public ReadOnlyCollection<IWebElement> Rows
        {
            get
            {
                IWebElement table = GetTable();
                ReadOnlyCollection<IWebElement> rows = table.FindElements(byRows);
                return rows;
            }
        }

        public int RowCount()
        {
            return Rows.Count;          
        }

        public bool IsSelected(int rowIndex)
        {
            IWebElement row = Row(rowIndex);
            string classInfo = row.GetAttribute("class");
            if (classInfo.Contains("row-selected"))
            {
                return true;
            }
            return false;
        }

        public void SelectRow(int rowIndex)
        {
            if (!IsSelected(rowIndex))
            {
                Row(rowIndex).Click();
            }
        }


        public IWebElement Row(int rowIndex)
        {
            IWebElement table = GetTable();
            By byRows = By.TagName("tr");
            ReadOnlyCollection<IWebElement> rows = table.FindElements(byRows);
            IWebElement row = rows[rowIndex];
            return row;
        }
        private IWebElement GetTable()
        {

            System.TimeSpan waitTime = new System.TimeSpan(0, 0, 20);
            OpenQA.Selenium.Support.UI.WebDriverWait wait = new OpenQA.Selenium.Support.UI.WebDriverWait(BrowserWindow.Instance.Driver, waitTime);
            IWebElement table = wait.Until(ExpectedConditions.ElementIsVisible(finder));

            if (table.TagName.ToUpper() != "TABLE")
            {
                throw new OpenQA.Selenium.InvalidElementStateException("Finder object does not find a TABLE element. Cannot get rowcount.");
            }
            return table;
        }
    }
}
