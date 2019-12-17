using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.ObjectModel;
namespace RecTracPom
{
    public class ModuleActivityManagement : IModule
    {
        private static  By byActivityDataTable = By.XPath("//table[starts-with(@id, 'aractivitymain_datagrid')]");
        private static By byActivityCodeFilter = By.XPath("//input[contains(@name,'filter_aractivity_activitycode')]");
        private static By byShortDescription = By.XPath("//td[@data-property='aractivity_shortdescription']/div"); // get the div within the cell for the text
        private static ModuleActivityManagement instance = null;

        public Table DataGrid => new Table(byActivityDataTable); // determine prefered syntax

        private ModuleActivityManagement()
        {

        }

        public static ModuleActivityManagement Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModuleActivityManagement();
                }
                return instance;
            }
        }
        public void DoPrimaryFilter(string value)
        {
            SetActivityCodeFilter(value);
        }

        public string GetChangedText()
        {
            return GetShortDescription();
        }

        public static void SetActivityCodeFilter(string activityCode)
        {
            Textbox txtActivityCodeFilter = new Textbox(byActivityCodeFilter);
            txtActivityCodeFilter.SetText(activityCode, Textbox.KeyToPress.Enter);
            
        }

        public static string GetShortDescription()
        {
            Element lbl = new Element(byShortDescription);
            return lbl.Text;
        }

        public bool IsExists(string code)
        {
            SetActivityCodeFilter(code);

            
            Table table = new Table(byActivityDataTable);

            foreach (IWebElement row in table.Rows)
            {
                try
                {
                    ReadOnlyCollection<IWebElement> cols = row.FindElements(byActivityCodeFilter);

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
    }
}

