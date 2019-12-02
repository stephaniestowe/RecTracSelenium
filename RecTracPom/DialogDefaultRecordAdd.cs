using OpenQA.Selenium;
using RecTracPom.OnScreenElements;

namespace RecTracPom
{
    public class DialogDefaultRecordAdd 
    {
        Dialog dialog = new Dialog("Default Record Add");
        public DialogDefaultRecordAdd()
        {
            
        }

        public void ContinueButtonClick()
        {
            dialog.ContinueButtonClick();
        }


    }
}
