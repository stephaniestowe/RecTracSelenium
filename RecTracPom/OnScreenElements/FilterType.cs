using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Threading;

namespace RecTracPom.OnScreenElements
{
    public class FilterType
    {
        private By finder;

        /// <summary>
        ///   <para>
        /// A filter on a module management page is made up of three things:</para>
        ///   <list type="bullet">
        ///     <item>A button that is clicked to expose a "drop down". This button has no readily identiable properties.</item>
        ///     <item>A Select tag that is a sibling of the button which has a uniquely identifiable name. This select remains hidden but is used to find the button which is to be clicked.</item>
        ///     <item>A UL tag with an LI which is exposed at button click. This UL is not uniquely identifiable, so after button click, the ULs with that class will be looped and the <em>displayed</em> one used.</item>
        ///   </list>
        /// </summary>
        /// <param name="finder">The finder for the hidden select which is the next sibling after the desired filter button.</param>
        public FilterType(By finder)
        {
            
            this.finder = finder;
            
        }

        public void SelectOption(string displayText)
        {
            string buttonFinder = finder.ToString();
            buttonFinder = buttonFinder.Replace("By.XPath: ", "");
            buttonFinder = buttonFinder + "/preceding-sibling::button";

            Button button = new Button(By.XPath(buttonFinder));

            button.Click();

            // get the desired UL. There is no unique identifier for the correct UL, so the DISPLAYED property of both the SELECT and the corresponding 
            // LINK is checked to find the correct one.
            string className = "ui-autocomplete ui-front ui-menu ui-widget ui-widget-content";
            By ulFinder = By.XPath("//ul[@class='" + className + "']");
            ReadOnlyCollection<IWebElement> elements =  BrowserWindow.Instance.Driver.FindElements(ulFinder);
            foreach (var element in elements)
            {
                if (element.Displayed == true)
                {
                    // this is the desired element
                    By itemToSelect = By.XPath("//a[text()='" + displayText + "']");
                    IWebElement link = element.FindElement(itemToSelect);
                    if (link.Displayed)
                    {
                        link.Click();
                        break;
                    }
                }
            }
        }
        

    }
}
