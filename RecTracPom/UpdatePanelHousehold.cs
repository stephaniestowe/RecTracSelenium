using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.Generic;
using System.Threading;

namespace RecTracPom
{
    public class UpdatePanelHousehold : IUpdatePanel
    {
        private static UpdatePanelHousehold instance = null;
        private List<Textbox> requiredTextboxes = new List<Textbox>();
        
        private static readonly By byFirstName = By.XPath("//input[starts-with(@id, 'sahousehold_firstname')]");
        private static readonly By byLastName = By.XPath("//input[starts-with(@id, 'sahousehold_lastname')]");
        private static readonly By byPrimaryEmail = By.XPath("//input[starts-with(@id, 'sahousehold_primaryemailaddress')]");
        private static readonly By byCity = By.XPath("//input[starts-with(@id, 'sahousehold_primarycity')]");

        private UpdatePanelHousehold()
        {
        }

        public static UpdatePanelHousehold Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpdatePanelHousehold();
                }

                instance.requiredTextboxes.Add(new Textbox(byFirstName));
                instance.requiredTextboxes.Add(new Textbox(byLastName));
                return instance;
            }
        }

        public List<Textbox> Required => requiredTextboxes;

        public void SetChangeValue(string value)
        {
            SetCity(value);
        }

        public void SetPrimaryEmail(string value)
        {
            Textbox txt = new Textbox(byPrimaryEmail);
            txt.SetText(value);
        }
        public void SetCity(string value)
        {
            Textbox txt = new Textbox(byCity);
            txt.SetText(value);
        }

        public void SetRequiredValues(string value)
        {
            foreach (Textbox item in requiredTextboxes)
            {
                item.SetText(value);
            }
        }

        public void SetFirstName(string value)
        {
            Textbox txt = new Textbox(byFirstName);
            txt.SetText(value);
        }

        public void SetLastName(string value)
        {
            Textbox txt = new Textbox(byLastName);
            txt.SetText(value);

        }
    }
}
