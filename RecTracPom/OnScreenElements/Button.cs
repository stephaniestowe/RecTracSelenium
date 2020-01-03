using OpenQA.Selenium;
using System.Threading;

namespace RecTracPom.OnScreenElements
{
    internal class Button : Element
    {
        public Button(By finder) : base(finder)
        {
        }

        public Button(IWebElement root, By finder) : base(root, finder)
        {

        }
        public Button() : base()
        {

        }
    }
}
