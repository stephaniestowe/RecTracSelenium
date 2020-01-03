using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


using System;

namespace RecTracPom.OnScreenElements
{

    public class DatePicker : Element
    {

        private readonly By byMonthSelect = By.XPath("//div[@id='ui-datepicker-div']/div/div/select[@data-handler='selectMonth']");
        private readonly By byYearSelect = By.XPath("//div[@id='ui-datepicker-div']/div/div/select[@data-handler='selectYear']");
        private readonly By ByCalendar = By.XPath("//table[@class='ui-datepicker-calendar'");
        private By finder;


        /// <summary>
        /// The finder for the date picker refers to the element that is CLICKED in order to expose the date picker containing the drop downs for month and year as well as the table of day hyperlinks.
        /// </summary>
        /// <param name="finder">The finder.</param>
        public DatePicker(By finder) : base(finder)
        {
            this.finder = finder;
        }

        public DatePicker() : base()
        {

        }

        public void SetDate(DateTime value)
        {
            string month = value.ToString("MMMM").Substring(0, 3);
            string day = value.Day.ToString();
            string year = value.Year.ToString();

            // click the element from the finder
            Textbox txt = new Textbox(finder);
            txt.Click();

            // Select the desired month
            IWebElement selMonth = new Element(byMonthSelect).WebElement;
            SelectElement options = new SelectElement(selMonth);
            options.SelectByText(month);

            // select the desired year
            IWebElement selYear = new Element(byYearSelect).WebElement;
            options = new SelectElement(selYear);
            options.SelectByText(year);

            // get calendar table and then us
            Table calendar = new Table(ByCalendar);
            By dayAnchor = By.XPath("//a[contains(text(), '" + day + "')]");
            IWebElement aDay = new Element(dayAnchor).WebElement;
            aDay.Click();

        }

    }
}
