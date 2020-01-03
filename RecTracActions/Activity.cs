using RecTracPom;
using System.Threading;

namespace RecTracActions
{
    public class Activity : ManagementActor , IManagementActor
    {

        private static Activity instance = null;
        
        private Activity()
        {

        }

        public string Season { get; set; } = "Fall";
        public string Year { get; set; } = Utilities.GetCurrentYearString();
        public static Activity Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Activity();
                }
                return instance;
            }
        }
        public void Add(string code)
        {
            PanelModuleCommon.AddButtonClick();
            DialogDefaultRecordAdd dlg = new DialogDefaultRecordAdd();
            dlg.ContinueButtonClick();
            UpdatePanelActivity.Instance.SetActivityCode(code);
            UpdatePanelActivity.Instance.SetLongDescription(code);
            Thread.Sleep(2000); // There is a bug in RecTrac Activity Add that this setting of short description and waiting is meant to work around.

            UpdatePanelsBottomButtons.SaveButtonClick();
        }


        public bool IsExists(string code)
        {
            return ModuleActivityManagement.Instance.IsExists(code);
        }

        public void Navigate()
        {
            PageHome.Instance.Navigate("Activity Management");
        }

        public void Delete(string code)
        {
            
            bool exists = ModuleActivityManagement.Instance.IsExists(code);
            if (!exists)
            {
                string errorMessage = Resource.ItemDoesNotExist;
                throw new System.Exception(errorMessage);
            }
            ModuleActivityManagement.Instance.DataGrid.SelectRow(1);
            base.Delete();
        }

        public bool IsClonable
        {
            get
            {
                return true;
            }
        }

        public new void Clone(string code)
        {
            string clonedValue = code + Resource.CloneSuffix;
            PanelModuleCommon.CloneButtonClick();

            DialogFileMaintenanceClone cloneDlg = new DialogFileMaintenanceClone();
            cloneDlg.SetNewRecordCodeList(clonedValue);
            cloneDlg.SetNewSeason(Season);
            cloneDlg.SetNewYear(Year);
            cloneDlg.ContinueButtonClick();
            DialogInformation infoDlg = new DialogInformation();
            infoDlg.ClickButtonByButtonTitle("Process");
            RecTracPom.OnScreenElements.Dialog dialog = new RecTracPom.OnScreenElements.Dialog("Success");
            dialog.CloseDialogByCloseButton();
        }
    }
}
