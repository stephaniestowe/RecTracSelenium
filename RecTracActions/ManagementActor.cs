using RecTracPom;
using System.Threading;

namespace RecTracActions
{
    public class ManagementActor
    {
        /// <summary>Deletes <font color="#ff0000"><strong>selected</strong></font>item from the active management actor's page. This assumes that the item is already selected.</summary>
        public void Delete()
        {
            PanelModuleCommon.MoreButtonClick();
            PanelModuleCommon.DeleteButtonClick();
            DialogInformation dlg = new DialogInformation("Information");
            dlg.ClickButtonByButtonTitle("Yes");
            // a delay is required here because selenium runs so fast that the next elements may not be ready to receive
            // input but also present so it does not fail
            Thread.Sleep(2000);
        }

        public static void CloseActiveTab()
        {
            PanelModuleCommon.DoCloseActiveTabEntire();
        }

    }
}
