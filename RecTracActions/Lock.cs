using RecTracPom;
using System.Threading;

namespace RecTracActions
{
    public class Lock : ManagementActor, IManagementActor
    {
        private static Lock instance = null;

        private Lock()
        {

        }

        public static Lock Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Lock();
                }
                return instance;
            }
        }

        public void Add(string code)
        {
            PanelModuleCommon.AddButtonClick();
            UpdatePanelLock.Instance.SetLockNumber(code);
            UpdatePanelsBottomButtons.SaveButtonClick();

        }

        public void Delete(string code)
        {
            bool exists = ModuleLock.Instance.IsExists(code);
            Thread.Sleep(1000);
            if (!exists)
            {
                string errorMessage = Resource.ItemDoesNotExist;
                throw new System.Exception(errorMessage);
            }
            base.Delete();
        }

        public bool IsExists(string code)
        {
            return ModuleLock.Instance.IsExists(code);
        }

        public void Navigate()
        {
            PageHome.Instance.Navigate("Lock Management");
        }

        public bool IsClonable
        {
            get
            {
                return true;
            }
        }
    }
}
