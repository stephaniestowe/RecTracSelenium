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

        /// <summary>
        ///   <para>
        ///  Deletes <font color="#ff0000"><strong>selected </strong></font>item from the active management actor's page. This assumes that the item is already selected.
        /// </para>
        ///   <para>This over rides (hides) the base method which uses the common bottom buttons which are not avialable on the Household Management page.</para>
        /// </summary>
        public new void Delete()
        {
            ModuleHouseholdManagement.Instance.DeleteClick();
            DialogInformation dlg = new DialogInformation("Information");
            dlg.ClickButtonByButtonTitle("Yes");
            // a delay is required here because selenium runs so fast that the next elements may not be ready to receive
            // input but also present so it does not fail
            Thread.Sleep(2000);
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
    }
}
