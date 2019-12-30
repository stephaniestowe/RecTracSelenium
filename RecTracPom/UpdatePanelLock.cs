using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.Generic;
using System.Threading;

namespace RecTracPom
{
    public class UpdatePanelLock : IUpdatePanel
    {
        private static UpdatePanelLock instance = null;

        // finders
        private readonly By byLockMake = By.XPath("//input[starts-with(@id,'lklock_make')]");
        private readonly By byLockNumber = By.XPath("//input[starts-with(@id,'lklock_lockcode')]");
        
        private UpdatePanelLock ()
        {

        }

        public static UpdatePanelLock Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpdatePanelLock();
                }
                return instance;
            }
        }

        public void SetChangeValue(string value)
        {
            SetLockMake(value);
        }

        public void SetLockMake(string value)
        {
            Textbox txt = new Textbox(byLockMake);
            txt.SetText(value);
        }

        public void SetLockNumber(string value)
        {
            Textbox txt = new Textbox(byLockNumber);
            txt.SetText(value);
        }
    }
}
