using RecTracPom;
using RecTracPom.OnScreenElements;
using System;
using System.Linq;
using System.Threading;

namespace RecTracActions
{
    public class CrudItem
    {
        const int codeLength = 10;

        public IUpdatePanel Panel { get; set; }
        public IModule Module { get; set; }
        public string Code { get; set; }

        public IManagementActor Actor { get; set; }

        public CrudItem(IUpdatePanel panel, IModule module, IManagementActor actor)
        {
            Panel = panel;
            Module = module;
            Actor = actor;
        }

        public CrudItem() { }
        public void Navigate()
        {
            Actor.Navigate();
        }

        public void Add()
        {
            Code = RandomString(codeLength);
            Actor.Add(Code);
        }

        public bool CheckExists()
        {
            Module.DoPrimaryFilter(Code);
            Thread.Sleep(2000); //TODO: How do I use waits to wait for rows in a table? I don't think I do.
            if (Module.DataGrid.RowCount() == 1)
            {
                return true;
            }
            return false;
        }

        public bool CheckChange()
        {
            string changedValue = Module.GetChangedText();
            if (changedValue == Code)
            {
                return true;
            }
            return false;
        }


        public void Change()
        {
            PanelModuleCommon.ChangeButtonClick();
            Panel.SetChangeValue(Code);
            UpdatePanelsBottomButtons.SaveButtonClick();
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void CloseActiveTab()
        {
            PanelModuleCommon.DoCloseActiveTabEntire();
        }

        public void Delete()
        {
            Actor.Delete();
        }
    }
}
