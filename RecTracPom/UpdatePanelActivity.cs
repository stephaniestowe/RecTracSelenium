using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.Generic;
using System.Threading;

namespace RecTracPom
{
    public class UpdatePanelActivity : IUpdatePanel
    {
        private List<Textbox> requiredTextboxes = new List<Textbox>();
        private static UpdatePanelActivity instance = null;

        private readonly By byActivityCode = By.XPath("//input[starts-with(@id,'aractivity_activitycode')]");
        private readonly By byLongDescription = By.XPath("//input[starts-with(@id,'aractivity_longdescription')]");
        private readonly By bySave = By.XPath("//button[@title='Save']");
        private readonly By byShortDescription = By.XPath("//input[starts-with(@id, 'aractivity_shortdescription')]");

        private UpdatePanelActivity()
        {

        }

        public static UpdatePanelActivity Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpdatePanelActivity();
                }

                instance.requiredTextboxes.Add(new Textbox(instance.byActivityCode));
                instance.requiredTextboxes.Add(new Textbox(instance.byLongDescription));

                return instance;
            }
        }


        public void SetActivityCode(string code)
        {
            Textbox txt = new OnScreenElements.Textbox(byActivityCode);
            txt.SetText(code);

        }

        public void SetShortDescription(string description)
        {
            Textbox txtShortDescription = new Textbox(byShortDescription);
            txtShortDescription.SetText(description);
        }

        public void SetLongDescription(string description)
        {
            Textbox txtLongDescription = new OnScreenElements.Textbox(byLongDescription);
            txtLongDescription.SetText(description);

        }

        public void SetChangeValue(string value)
        {
            SetShortDescription(value);
        }



    }
}
