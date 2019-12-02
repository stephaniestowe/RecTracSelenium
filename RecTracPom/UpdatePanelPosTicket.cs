using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.Generic;

namespace RecTracPom
{
    public class UpdatePanelPosTicket : IUpdatePanel
    {
        private List<Textbox> requiredTextboxes = new List<Textbox>();
        private static UpdatePanelPosTicket instance = null;

        private readonly By byTicketCode = By.XPath("//input[starts-with(@id,'psticketmain_ticketcode')]");
        private readonly By bySave = By.XPath("//button[@title='Save']");
        private readonly By byLongDescription = By.XPath("//input[starts-with(@id, 'psticketmain_longdescription')]");
        private readonly By byShortDescription = By.XPath("//input[starts-with(@id, 'psticketmain_shortdescription')]");

        private UpdatePanelPosTicket()
        {

        }

        public static UpdatePanelPosTicket Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpdatePanelPosTicket();
                }

                instance.requiredTextboxes.Add(new Textbox(instance.byTicketCode)) ;

                return instance;
            }
        }

        public List<Textbox> Required 
        { 
            get
            {
                return requiredTextboxes; 
            }
        }

        public void ButtonSaveClick()
        {
            Button btnSave = new Button(bySave);
            btnSave.Click();
        }
        public void SetTicketCode(string ticketCode)
        {
            Textbox txtTicketCode = new OnScreenElements.Textbox(byTicketCode);
            txtTicketCode.SetText(ticketCode);

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

        public void SetRequiredValues(string value)
        {
            foreach (Textbox item in requiredTextboxes)
            {
                item.SetText(value);
            }
        }

        public void SetChangeValue(string value)
        {
            SetShortDescription(value);
        }

    }
}
