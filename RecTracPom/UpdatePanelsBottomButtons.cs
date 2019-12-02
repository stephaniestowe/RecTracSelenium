using OpenQA.Selenium;
using RecTracPom.OnScreenElements;

namespace RecTracPom
{
    public static class UpdatePanelsBottomButtons
    {
        private static By bySaveButton = By.XPath("//button[@title='Save']");
        private static By byCancelButton = By.XPath("//button[@title='Cancel'");

        public static void SaveButtonClick()
        {
            Button btnSave = new Button(bySaveButton);
            btnSave.Click();
        }

        public static void CancelButtonClick()
        {
            Button btnCancel = new Button(byCancelButton);
            btnCancel.Click();
        }

    }
}
