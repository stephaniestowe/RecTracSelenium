using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Threading;

namespace RecTracPom
{
    public static class PanelModuleBottomButtons
    {
        private static By byAddButton = By.XPath("//button[@title='Add']");
        private static By byMoreButton = By.XPath("//button[@title='More']");
        private static By byDeleteButton = By.XPath("//button[@title='Delete']");
        private static By byChangeButton = By.XPath("//button[@title='Change']");
        

        public static void AddButtonClick()
        {
            Button btnAdd = new Button(byAddButton);

            //TODO: replace this with a correct wait sceme
            Thread.Sleep(5000);

            btnAdd.Click();
        }

        public static void MoreButtonClick()
        {
            Button btnMore = new Button(byMoreButton);
            btnMore.Click();
        }

        public static void DeleteButtonClick()
        {
            Button btnDelete = new Button(byDeleteButton);
            btnDelete.Click();
        }

        public static void ChangeButtonClick()
        {
            Button btnChange = new Button(byChangeButton);
            btnChange.Click();
        }

        /// <summary>  Does the combination of actions/clicks to perform a delete with dialog responses (where applicable).</summary>
        public static void DoDeleteEntire()
        {
            MoreButtonClick();
            DeleteButtonClick();
            Dialog dlgInfo = new Dialog("Information");
            dlgInfo.ClickButtonByButtonTitle("Yes");
        }
    }
}
