using RecTracPom;
using System.Threading;

namespace RecTracActions
{
    public class Household : ManagementActor, IManagementActor
    {
        private static Household instance = null;
        private const string navString = "Household Management";

        private Household()
        {

        }

        public static Household Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Household();
                }
                return instance;
            }
        }

        public void Add(string code)
        {
            PanelModuleCommon.AddButtonClick();
            UpdatePanelHousehold.Instance.SetFirstName(code);
            UpdatePanelHousehold.Instance.SetLastName(code);
            UpdatePanelsBottomButtons.SaveButtonClick();
        }

        public void Delete(string code)
        {
            Select(code);
            ModuleHouseholdManagement.Instance.DeleteClick();
        }

        public bool IsExists(string code)
        {
            return ModuleHouseholdManagement.Instance.IsExists(code);
        }

        public void Select(string code)
        {
            _ = IsExists(code);

        }

        public void Navigate()
        {
            PageHome.Instance.Navigate(navString);
        }

        public bool IsClonable
        {
            get
            {
                return false;
            }
        }
    }
}
