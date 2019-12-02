﻿using OpenQA.Selenium;

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

    }
}