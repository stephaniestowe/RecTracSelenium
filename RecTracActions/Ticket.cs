using RecTracPom;
using System.Threading;

namespace RecTracActions
{
    public static class Ticket
    {
        public static void NavigateTicketManagement()
        {
            PageHome.Instance.Navigate("Ticket Management");
        }

        public static void AddTicket(string ticketCode)
        {
            
            PanelModuleBottomButtons.AddButtonClick();
            DialogDefaultRecordAdd dlg = new DialogDefaultRecordAdd();
            dlg.ContinueButtonClick();
            UpdatePanelPosTicket.Instance.SetTicketCode(ticketCode);
            UpdatePanelPosTicket.Instance.ButtonSaveClick();
        }

        public static void DeleteTicket(string ticketCode)
        {
            SelectTicket(ticketCode);
            PanelModuleBottomButtons.MoreButtonClick();
            PanelModuleBottomButtons.DeleteButtonClick();
            DialogInformation dlg = new DialogInformation("Information");
            dlg.ClickButtonByButtonTitle("Yes");
            // a delay is required here because selenium runs so fast that the next elements may not be ready to receive
            // input but also present so it does not fail
            Thread.Sleep(2000);

        }

        public static bool IsTicketExists(string ticketCode)
        {
            return ModulePosTicketManagement.IsTicketExists(ticketCode);
            
        }

        private static void SelectTicket(string ticketCode)
        {
            _ = IsTicketExists(ticketCode);


        }
    }
}
