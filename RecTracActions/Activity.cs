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
                throw new System.Exception("Cannot delete item. Item does not exist");
            }
            base.Delete();
        }
    }
}
