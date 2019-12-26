using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.ObjectModel;
using System.Threading;

namespace RecTracPom
{
    public class ModuleActivitySectionManagement : IModule
    {
        private static ModuleActivitySectionManagement instance = null;

        private static By byDataTable = By.XPath("//table[starts-with(@id, 'arsectionmain_datagrid')]");
        private static By bySectionCodeFilter = By.XPath("//input[contains(@name,'filter_arsection_section')]");
        private static By byShortDescription = By.XPath("//td[@data-property='arsection_shortdescription']/div"); // get the div within the cell for the text

        private ModuleActivitySectionManagement()
        {

        }

        public static ModuleActivitySectionManagement Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModuleActivitySectionManagement();
                }
                return instance;
            }
        }

        public Table DataGrid => new Table(byDataTable);

        public void DoPrimaryFilter(string value)
        {
            SetSectionFilter(value);
        }

        public string GetChangedText()
        {
            return GetShortDescription();
        }

        public bool IsExists(string code)
        {
            SetSectionFilter(code);

            Table table = new Table(byDataTable);

            foreach (IWebElement row in table.Rows)
            {
                try
                {
                    //Get the columns for returned rows to seek an exact match
                    By byColumnsForSection = By.XPath("//td[@data-property='arsection_section']/div");
                    ReadOnlyCollection<IWebElement> cols = row.FindElements(byColumnsForSection);

                    foreach (IWebElement col in cols)
                    {
                        if (col.Text.ToLower() == code.ToLower())
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

        public void SetSectionFilter(string value)
        {
            // Whoooo weeeeee selenium is fast. So fast, that though the text box can report clickable
            // and the entry still gets mucked up.
            Thread.Sleep(2000);
            Textbox txt = new Textbox(bySectionCodeFilter);
            txt.SetText(value);
            txt.WebElement.SendKeys(Keys.Tab);
        }

        public string GetShortDescription()
        {
            Element lbl = new Element(byShortDescription);
            return lbl.Text;
        }
    }
}
