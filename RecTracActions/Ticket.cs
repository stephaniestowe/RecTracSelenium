using RecTracPom;

namespace RecTracActions
{
    public class Ticket : ManagementActor, IManagementActor
    {
        private static Ticket instance = null;
        private const string navString = "Ticket Management";

        private Ticket()
        {

        }

        public static Ticket Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Ticket();
                }
                return instance;
            }
        }
        public void Navigate()
        {
            PageHome.Instance.Navigate(navString);
        }

        public void Add(string code)
        {
            
            PanelModuleCommon.AddButtonClick();
            DialogDefaultRecordAdd dlg = new DialogDefaultRecordAdd();
            dlg.ContinueButtonClick();
            UpdatePanelPosTicket.Instance.SetTicketCode(code);
            UpdatePanelsBottomButtons.SaveButtonClick();
        }

        public void Delete(string code)
        {
            SelectTicket(code);
            base.Delete();
        }

        public bool IsExists(string code)
        {
            return ModulePosTicketManagement.Instance.IsExists(code);
        }

        private void SelectTicket(string ticketCode)
        {
            _ = IsExists(ticketCode);
        }
    }
}
