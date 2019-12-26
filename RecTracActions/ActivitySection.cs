using RecTracPom;
using System.Threading;
using System.Configuration;
using System;

namespace RecTracActions
{
    public class ActivitySection : ManagementActor , IManagementActor
    {
        private static ActivitySection instance = null;

        // When adding a NEW Activity Section, in particular, there are fields on the form that are required.
        // A test may not need to specify these values. So default values are provided in the properties.
        // A test need simply SET a new value to over ride the default.
        public string Season { get; set; } = "Fall";
        public string Activity { get; set; } = "ZZDefaultActivity";
        public string Year { get; set; } = Utilities.GetCurrentYearString();
        public string FacilityText { get; set; } = ConstructFacilityText();
        public DateTime BeginDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);
        public DateTime BeginTime { get; set; } = Convert.ToDateTime("01:00 PM");
        public DateTime EndTime { get; set; } = Convert.ToDateTime("02:00 PM");
        

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
            throw new System.NotImplementedException();
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

    }
}
