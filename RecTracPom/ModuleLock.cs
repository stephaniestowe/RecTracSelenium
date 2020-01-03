using OpenQA.Selenium;
using RecTracPom.OnScreenElements;

namespace RecTracPom
{
    public class ModuleLock : IModule
    {
        private static ModuleLock instance = null;

        //finders
        private By byDataTable = By.XPath("//table[starts-with(@id, 'lklockmain_datagrid')]");
        private By byLockNumberFilter = By.XPath("//input[contains(@name,'filter_lklock_lockcode')]");
        private By byLockNumberCell = By.XPath("//td[@data-property='lklock_lockcode']");
        private static By byLockMakeCell = By.XPath("//td[@data-property='lklock_make']/div"); // get the div within the cell for the text
        private static By byLockNumberFilterSelect = By.XPath("//select[contains(@name, 'filterby_lklock_lockcode')]");

        private ModuleLock()
        {

        }

        public static ModuleLock Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new ModuleLock();
                }
                return instance;
            }
        }

        public Table DataGrid => new Table(byDataTable);

        public void DoPrimaryFilter(string value)
        {
            SetLockNumberFilter(value);
        }

        public string GetChangedText()
        {
            return GetLockMake;
        }

        public bool IsExists(string code)
        {
            DoPrimaryFilter(code);
            Table table = new Table(byDataTable);
            bool exists = table.IsItemExists(byLockNumberCell, code);
            if (exists)
            {
                // select the wro
                table.SelectRow(1);
            }
            return exists;
        }

        public void SetLockNumberFilter(string lockNum)
        {
            FilterType filter = new FilterType(byLockNumberFilterSelect);
            filter.SelectOption("Equals");
            Textbox txt = new Textbox(byLockNumberFilter);
            txt.SetText(lockNum, Textbox.KeyToPress.Tab);
            
        }

        public string GetLockMake
        {
            get
            {
                Element lbl = new Element(byLockMakeCell);
                return lbl.Text;
            }
        }

    }
}
