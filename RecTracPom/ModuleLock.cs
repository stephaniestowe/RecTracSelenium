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
        private static By byLockMakeCell = By.XPath("//td[@data-property='lklock_lockcode']/div"); // get the div within the cell for the text

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
            return table.IsItemExists(byLockNumberCell, code);
        }

        public void SetLockNumberFilter(string lockNum)
        {
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
