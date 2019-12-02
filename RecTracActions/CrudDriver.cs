using RecTracPom.OnScreenElements;
using RecTracPom;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecTracActions
{
    public static class CRUDDriver
    {
        struct Item
        {
            internal string Navigator;
            internal IUpdatePanel Panel;
            internal IModule Module;
        }

        private static List<Item> itemsToCrud = new List<Item>();
        private static string itemKey;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public static bool Drive()
        {
            bool success = true;
            try
            {
                ConfigureModulestoCrud();
                foreach (Item item in itemsToCrud)
                {
                    // navigate
                    PageHome.Instance.Navigate(item.Navigator);
                    // Add item.
                    AddItem(item.Panel);
                    // Check item exists.
                    success = CheckItemExists(item.Module);
                    // Edit (read part of CRUD as well) Item
                    ReadEditItem(item.Panel);
                    success = CheckChangedItem(item.Module);
                    DeleteItem(item.Module);
                    success = !CheckItemExists(item.Module);
                }
            }
            
            catch (Exception e)
            {
                success = false;
            }
            return success;
        }

        private static void AddItem(IUpdatePanel panel)
        {
            itemKey = RandomString(10);
            PanelModuleBottomButtons.AddButtonClick();
            DialogDefaultRecordAdd addDialog = new DialogDefaultRecordAdd();
            addDialog.ContinueButtonClick();
            panel.SetRequiredValues(itemKey);
            UpdatePanelsBottomButtons.SaveButtonClick();

        }

        private static bool CheckItemExists(IModule module)
        {
            module.DoPrimaryFilter(itemKey);
            if (module.DataGrid.RowCount() == 1)
            {
                return true;
            }
            return false;
            
        }

        private static void DeleteItem(IModule module)
        {
            // This is in CRUD. The sequence already has the item selected.
            PanelModuleBottomButtons.DoDeleteEntire();

        }

        private static bool CheckChangedItem(IModule module)
        {
            string changedValue = module.GetChangedText();
            if (changedValue == itemKey)
            {
                return true;
            }
            return false;
        }

        /// <summary>  PreRequisite State: Desired item is selected in grid.</summary>
        /// <param name="panel">The panel.</param>
        private static void ReadEditItem(IUpdatePanel panel)
        {
            PanelModuleBottomButtons.ChangeButtonClick();
            panel.SetChangeValue(itemKey);
            UpdatePanelsBottomButtons.SaveButtonClick();
        }
        private static void ConfigureModulestoCrud()
        {
            Item item = new Item();
            item.Navigator = "Ticket Management";
            item.Panel = UpdatePanelPosTicket.Instance;
            item.Module = ModulePosTicketManagement.Instance;
            itemsToCrud.Add(item);

        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
