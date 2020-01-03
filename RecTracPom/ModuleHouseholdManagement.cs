using OpenQA.Selenium;
using RecTracPom.OnScreenElements;
using System.Collections.ObjectModel;
using System.Threading;

namespace RecTracPom
{
    public class ModuleHouseholdManagement : IModule
    {
        private static ModuleHouseholdManagement instance = null;

        private static readonly By byDataTable = By.XPath("//table[starts-with(@id, 'globalsaleslookup_hhdatagrid')]");
        private static readonly By byLookupText = By.XPath("//input[starts-with(@id, 'globalsaleslookup_lookupfillin')]");
        private static readonly By byLookupButton = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonlookupgroup')]");
        
        // The following set of BY variables are for the buttons exposed when the lookup button is clicked.
        private static readonly By byHouseholdNumber = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonhhnumber')]");
        private static readonly By byAddress = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonaddress')]");
        private static readonly By byEmail = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonemail')]");
        private static readonly By byFamilyMember = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonfm')]");
        private static readonly By byHouseholdLastName = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonhhlastname')]");
        private static readonly By byOrganizationName = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonorgname')]");
        private static readonly By byPhone = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonphone')]");
        private static readonly By byTeamName = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonteamname')]");

        private static By byEmailColumn = By.XPath("//td[@data-property='sahousehold_primaryemailaddress']/div"); // get the div within the cell for the text
        private static By byCityColumn = By.XPath("//td[@data-property='sahousehold_primarycity']/div"); // get the div within the cell for the text

        private static By byDeleteButton = By.XPath("//button[starts-with(@id, 'globalsaleslookup_buttonmaintenancedelete')]");
        
        private ModuleHouseholdManagement()
        {

        }

        public static ModuleHouseholdManagement Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModuleHouseholdManagement();
                }
                return instance;
            }
        }

        public enum LookupBy
        {
            Address,
            Email,
            FamilyMember,
            HouseholdLastName,
            HouseholdNumber,
            OrganizationName,
            Phone,
            TeamName
        }

        public Table DataGrid => new Table(byDataTable); //TODO: Team decide what we want for syntax, this or get ...

        /// <summary>
        /// This method is part of the IModule implementation. For a household, the primary filter is by household number. This method enters a value in the lookup text box and filters by Household Number using the lookup drop down.
        /// </summary>
        /// <param name="value"></param>
        public void DoPrimaryFilter(string value)
        {
            DoFilter(value, LookupBy.HouseholdLastName);

        }

        /// <summary>  Performs a filter on the household management page by entering the value passed in the lookup text box and selecting the Lookup button as indicated by seek.</summary>
        /// <param name="value">The value.</param>
        /// <param name="seek">The seek.</param>
        public void DoFilter(string value, LookupBy seek)
        {
            Textbox txtLookup = new Textbox(byLookupText);
            txtLookup.SetText(value);
            Button btnLookup = new Button(byLookupButton);
            btnLookup.Click();

            Button btnLookupType = new Button();
            switch(seek)
            {
                case (LookupBy.Address):
                    btnLookupType.Finder = byAddress;
                    break;
                case (LookupBy.Email):
                    btnLookupType.Finder = byEmail;
                    break;
                case (LookupBy.FamilyMember):
                    btnLookupType.Finder = byFamilyMember;
                    break;
                case (LookupBy.HouseholdLastName):
                    btnLookupType.Finder = byHouseholdLastName;
                    break;
                case (LookupBy.HouseholdNumber):
                    btnLookupType.Finder = byHouseholdNumber;
                    break;
                case (LookupBy.OrganizationName):
                    btnLookupType.Finder = byOrganizationName;
                    break;
                case (LookupBy.Phone):
                    btnLookupType.Finder = byPhone;
                    break;
                case (LookupBy.TeamName):
                    btnLookupType.Finder = byTeamName;
                    break;
                default:
                    btnLookupType.Finder = byHouseholdNumber;
                    break;
            }
            btnLookupType.Click();
            Thread.Sleep(1000);
        }

        public string GetPrimaryEmail()
        {
            Element lbl = new Element(byEmailColumn);
            return lbl.Text;
        }

        public string GetCity()
        {
            Element lbl = new Element(byCityColumn);
            return lbl.Text;
        }

        public string GetChangedText()
        {
            return GetCity();
        }

        /// <summary>  Determines if a household exists by<strong> household id</strong>.</summary>
        /// <param name="code">The code.</param>
        /// <returns>
        ///   <c>true</c> if the specified code is exists; otherwise, <c>false</c>.</returns>
        public bool IsExists(string lastName)
        {
            DoPrimaryFilter(lastName);

            Table table = new Table(byDataTable);

            foreach (IWebElement row in table.Rows)
            {
                try
                {
                    By byHouseholdLastNameColumn = By.XPath("//td[@data-property='sahousehold_lastname']/div"); // get the div within the cell for the text
                    ReadOnlyCollection<IWebElement> cols = row.FindElements(byHouseholdLastNameColumn);

                    foreach (IWebElement col in cols)
                    {
                        if (col.Text.ToLower() == lastName.ToLower())
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }

            }
            return false;
        }

        public void DeleteClick()
        {
            Button btn = new Button(byDeleteButton);
            btn.Click();
            DialogInformation info = new DialogInformation();
            info.ClickButtonByButtonTitle("Yes");

        }
        
    }
}

