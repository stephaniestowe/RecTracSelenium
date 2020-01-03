using OpenQA.Selenium;
using RecTracPom.OnScreenElements;

namespace RecTracPom
{
    public class DialogFileMaintenanceClone : OnScreenElements.Dialog
    {
        private static readonly string title = "File Maintenance Clone";

        private static readonly By byNewRecordCodeList = By.XPath("//input[@name='filemaintenanceclone_clonelist']");
        private static readonly By byNewSeason = By.XPath("//input[contains(@name, 'seasonclonelist')]");
        private static readonly By byNewYear = By.XPath("//input[contains(@name, 'yearclonelist')]");

        public DialogFileMaintenanceClone() : base(title)
        {

        }

        public void SetNewRecordCodeList(string value)
        {
            Textbox txt = new Textbox(byNewRecordCodeList);
            txt.SetText(value);
        }

        public void SetNewSeason(string value)
        {
            Textbox txt = new Textbox(byNewSeason);
            txt.SetText(value);
        }

        public void SetNewYear(string value)
        {
            Textbox txt = new Textbox(byNewYear);
            txt.SetText(value);
        }
    }
}
