using OpenQA.Selenium;
using System.Threading;

namespace RecTracPom.OnScreenElements
{
    public class Textbox : Element
    {
        public enum KeyToPress
        {
            Enter,
            Tab
        }
        public Textbox(By finder) : base(finder)
        {
        }

        public Textbox() : base()
        {
        }

        public void SetText(string text)
        {
            // Clear the text box prior to entry 
            WebElement.Clear();
            WebElement.SendKeys(text);

        }
        
        // Used to follow entry 
        public void SetText(string text, KeyToPress key)
        {
            // Firefox is pesky wrt text boxes. Gotta wait an extra sec
            if (BrowserWindow.Instance.Browser == BrowserWindow.Browsers.Firefox)
            {
                Thread.Sleep(1000);
            }
            SetText(text);
            switch(key)
            {
                case KeyToPress.Enter:
                    WebElement.SendKeys(Keys.Enter);
                    break;
                case KeyToPress.Tab:
                    WebElement.SendKeys(Keys.Tab);
                    break;
            }

        }

        public string GetValue()
        {
            return WebElement.GetAttribute("value");
        }

    }
}
