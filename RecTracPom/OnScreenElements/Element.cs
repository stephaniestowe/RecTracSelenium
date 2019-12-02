using OpenQA.Selenium;

namespace RecTracPom.OnScreenElements
{
    public class Element
    {
        private By finder;

        public Element(By finder)
        {
            this.finder = finder;
        }

        public Element()
        {

        }

        public By Finder
        {
            set
            {
                // TODO: Re think SINGLTEON (which I have not done here, why do I do it in pages?).
                // Does ANYTHING have to be a singleton if we are just using the contrsuctor to get a 
                // new instance of the brwoser window instance?
                finder = value;
            }


        }

        public IWebElement WebElement
        {
            get
            {
                return BrowserWindow.Instance.Driver.FindElement(finder);
            }
        }

        public string Text
        {
            get
            {
                return WebElement.Text;
            }
        }

    }
}
