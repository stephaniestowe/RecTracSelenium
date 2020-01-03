using RecTracPom;
using RecTracPom.OnScreenElements;

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
            DialogInformation dlg = new DialogInformation();
            dlg.ClickButtonByButtonTitle(Resource.Yes);
            // a delay is required here because selenium runs so fast that the next elements may not be ready to receive
            // input but also present so it does not fail to find the element
            Thread.Sleep(2000);
        }

        public static void CloseActiveTab()
        {
            PanelModuleCommon.DoCloseActiveTabEntire();
        }

        public void Clone(string code)
        {
            string clonedValue = code + Resource.CloneSuffix;
            PanelModuleCommon.CloneButtonClick();
            DialogFileMaintenanceClone dlg = new DialogFileMaintenanceClone();
            dlg.SetNewRecordCodeList(clonedValue);
            dlg.ContinueButtonClick();

            DialogInformation dlgInfo = new DialogInformation();
            dlg.ClickButtonByButtonTitle(Resource.ProcessButtonTitle);
            Dialog dlgSuccess = new Dialog(Resource.SuccessDialogTitle);
            dlgSuccess.CloseDialogByCloseButton();

        }

    }
}
