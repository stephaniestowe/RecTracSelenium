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

        public string Title { get; set; }

        public IManagementActor Actor { get; set; }

        public CrudItem(IUpdatePanel panel, IModule module, IManagementActor actor)
        {
            Panel = panel;
            Module = module;
            Actor = actor;
        }

        public CrudItem(string title, IUpdatePanel panel, IModule module, IManagementActor actor)
        {
            this.Title = title;
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
            Code = Utilities.RandomString(codeLength);
            Actor.Add(Code);
        }

        public bool CheckExists()
        {
            return Module.IsExists(Code);
            
        }

        public bool CheckChange()
        {
            Module.DoPrimaryFilter(Code);
            Thread.Sleep(1000); // paint of the table needs time
            string changedValue = Module.GetChangedText();
            if (changedValue == Code)
            {
                return true;
            }
            return false;
        }


        public void Change()
        {
            Thread.Sleep(1000); // table paint needs time as well as recognizing selection of row
            Module.DoPrimaryFilter(Code);
            PanelModuleCommon.ChangeButtonClick();
            Panel.SetChangeValue(Code);
            UpdatePanelsBottomButtons.SaveButtonClick();
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
