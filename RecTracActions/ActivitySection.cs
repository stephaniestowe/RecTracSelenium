using RecTracPom;
using System.Threading;
using System.Configuration;
using System;

namespace RecTracActions
{
    public class ActivitySection : ManagementActor , IManagementActor
    {
        private static ActivitySection instance = null;
        // These values only apply to activies thus are constants here rather than available through a resource.
        private static readonly DateTime defaultBeginTime = Convert.ToDateTime("01:00 PM");
        private static readonly DateTime defaultEndTime = Convert.ToDateTime("02:00 PM");

        // When adding a NEW Activity Section, in particular, there are fields on the form that are required.
        // A test may not need to specify these values. So default values are provided in the properties.
        // A test need simply SET a new value to over ride the default.
        public string Season { get; set; } = "Fall";
        public string Activity { get; set; } = "ZZDefaultActivity";
        public string Year { get; set; } = Utilities.GetCurrentYearString();
        public string FacilityText { get; set; } = ConstructFacilityText();
        public DateTime BeginDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);
        public DateTime BeginTime { get; set; } = defaultBeginTime;
        public DateTime EndTime { get; set; } = defaultEndTime;
        

        private ActivitySection()
        {

        }

        public static ActivitySection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ActivitySection();
                }
                return instance;
            }
        }

        /// <summary>Activity Section Add requires an activity code to which the section will be added in addition to the section code itself. To use this method one can
        /// set the properties for desired values (like Activity code and Season) or use the default values. </summary>
        /// <param name="code">The code.</param>
        public void Add(string code)
        {
            PanelModuleCommon.AddButtonClick();
            DialogDefaultRecordAdd dlg = new DialogDefaultRecordAdd();
            dlg.ContinueButtonClick();
            UpdatePanelActivitySection.Instance.SetActivityCodeByText(Activity);
            UpdatePanelActivitySection.Instance.SetSection(code);
            UpdatePanelActivitySection.Instance.SetYear(Year);
            UpdatePanelActivitySection.Instance.SetSeasonByText(Season);
            UpdatePanelActivitySection.Instance.SetFacilityByText(FacilityText);
            UpdatePanelActivitySection.Instance.SetBeginDate(BeginDate);
            UpdatePanelActivitySection.Instance.SetEndDate(EndDate);
            UpdatePanelActivitySection.Instance.SetBeginTime(BeginTime);
            UpdatePanelActivitySection.Instance.SetEndTime(EndTime);
            UpdatePanelActivitySection.Instance.ClickAllDays();

            Thread.Sleep(500); // Let the underlying page actions complete.

            UpdatePanelsBottomButtons.SaveButtonClick();
        }

        public void Delete(string code)
        {
            bool exists = ModuleActivitySectionManagement.Instance.IsExists(code);
            if (!exists)
            {
                string errorMessage = Resource.ItemDoesNotExist;
                throw new System.Exception(errorMessage);
            }
            ModuleActivitySectionManagement.Instance.DataGrid.SelectRow(1);
            base.Delete();

        }

        public bool IsExists(string code)
        {
            return ModuleActivitySectionManagement.Instance.IsExists(code);
        }

        public void Navigate()
        {
            PageHome.Instance.Navigate("Activity Section Management");
        }


        private static string ConstructFacilityText()
        {
            return "Lap pool_Fantasy Land_Fantasy Land Fitness Pool Two"; //TODO: Figure out some kind of config so not using hard coded values.
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
