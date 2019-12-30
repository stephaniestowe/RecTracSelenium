using RecTracPom.OnScreenElements;
using RecTracPom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecTracActions
{
    public class CrudDriver
    {

        private static CrudDriver instance = null;
        private static List<CrudItem> itemsToCrud = new List<CrudItem>();

        private CrudDriver()
        {
            ConfigureModulestoCrud();
        }

        public static CrudDriver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CrudDriver();
                }
                return instance;
            }
        }

        public List<CrudItem> Items
        {
            get
            {
                return itemsToCrud;
            }
        }

        private static void ConfigureModulestoCrud()
        {
            CrudItem item = new CrudItem();

            item = new CrudItem("Lock", UpdatePanelLock.Instance, ModuleLock.Instance, Lock.Instance);
            itemsToCrud.Add(item);

            item = new CrudItem("Household", UpdatePanelHousehold.Instance, ModuleHouseholdManagement.Instance, Household.Instance);
            itemsToCrud.Add(item);

            item = new CrudItem("Activity Section", UpdatePanelActivitySection.Instance, ModuleActivitySectionManagement.Instance, ActivitySection.Instance);
            itemsToCrud.Add(item);

            item = new CrudItem("Ticket", UpdatePanelPosTicket.Instance, ModulePosTicketManagement.Instance, Ticket.Instance);
            itemsToCrud.Add(item);

            item = new CrudItem("Activity", UpdatePanelActivity.Instance, ModuleActivityManagement.Instance, Activity.Instance);
            itemsToCrud.Add(item);

        }


    }
}
