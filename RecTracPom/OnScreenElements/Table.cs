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
            this.Finder = finder;
            IWebElement table = this.WebElement;

            if (table.TagName.ToUpper() != "TABLE")
            {
                throw new OpenQA.Selenium.InvalidElementStateException("Finder object does not find a TABLE element. Cannot get rowcount.");
            }
            return table;
        }

        /// <summary>The value is sought in the cells of the table found with the Selenium By object.</summary>
        /// <param name="byCellToSearch">
        ///   <para>
        /// A Selenium By object which specifies the finder for the CELL in the table. The By object for this cell is often some piece of
        /// the data-property element as with this example in the ticket management module --
        /// <font color="#ab5207">By.XPath("//td[@data-property='psticketmain_ticketcode']");
        /// </font></para>
        ///   <para>
        ///     <font color="#000000">Since RecTrac  pages are consistently rendered, this pattern (data-property identification of the cell) is reliable across data pages.</font>
        ///   </para>
        ///   <note type="tip">This method is best (and fastest) when the page's unique filter was applied before calling.<br /><para></para></note>
        ///   <para></para>
        /// </param>
        /// <param name="value">The value to seek in the cells returned by byCellToSearch.</param>
        /// <returns>
        ///   <c>If the item of the specified value is found in the cells, return TRUE else FALSE.</c>
        /// </returns>
        public bool IsItemExists(By byCellToSearch, string value)
        {
            foreach (IWebElement row in Rows)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> cols = row.FindElements(byCellToSearch);

                    foreach (IWebElement col in cols)
                    {
                        if (col.Text.ToLower() == value.ToLower())
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
    }
}
