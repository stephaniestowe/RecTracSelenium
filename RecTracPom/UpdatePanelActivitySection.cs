using System.Collections.Generic;
using RecTracPom.OnScreenElements;
using OpenQA.Selenium;
using System.Threading;
using System;

namespace RecTracPom
{
    public class UpdatePanelActivitySection : IUpdatePanel
    {
        private static UpdatePanelActivitySection instance = null;

        private readonly By byActivityCodeTextbox = By.XPath("//input[starts-with(@id,'arsection_activitycode')]");
        private readonly By bySectionCode  = By.XPath("//input[starts-with(@id,'arsection_section')]");
        private readonly By byShortDescription = By.XPath("//input[starts-with(@id,'arsection_shortdescription')]");
        private readonly By byYear = By.XPath("//input[starts-with(@id,'arsection_year')]");
        private readonly By bySeasonTextbox = By.XPath("//input[starts-with(@id,'arsection_season')]");
        private readonly By byFacilityTextbox = By.XPath("//input[starts-with(@id,'arsection_facilitycombokey')]");
        private readonly By byBeginDatePicker = By.XPath("//input[starts-with(@id,'arsection_begindate')]");
        private readonly By byEndDatePicker = By.XPath("//input[starts-with(@id,'arsection_enddate')]");
        private readonly By byBeginTimeTextbox = By.XPath("//input[starts-with(@id,'arsection_begintime')]");
        private readonly By byEndTimeTextbox = By.XPath("//input[starts-with(@id,'arsection_endtime')]");
        private readonly By byMondayVisible = By.XPath("//input[starts-with(@id,'arsection_monday')]/following-sibling::span");
        private readonly By byTuesdayVisible = By.XPath("//input[starts-with(@id,'arsection_tuesday')]/following-sibling::span");
        private readonly By byWednesdayVisible = By.XPath("//input[starts-with(@id,'arsection_wednesday')]/following-sibling::span");
        private readonly By byThursdayVisible = By.XPath("//input[starts-with(@id,'arsection_thursday')]/following-sibling::span");
        private readonly By byFridayVisible = By.XPath("//input[starts-with(@id,'arsection_friday')]/following-sibling::span");
        private readonly By bySaturdayVisible = By.XPath("//input[starts-with(@id,'arsection_saturday')]/following-sibling::span");
        private readonly By bySundayVisible = By.XPath("//input[starts-with(@id,'arsection_sunday')]/following-sibling::span");

        private UpdatePanelActivitySection()
        {

        }

        public static UpdatePanelActivitySection Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpdatePanelActivitySection();
                }
                return instance;
            }
        }
        public void SetChangeValue(string value)
        {
            SetShortDescription(value);
        }

        public void SetActivityCodeByText(string code)
        {
            Textbox txt = new Textbox(byActivityCodeTextbox);
            txt.SetText(code);
        }

        public void SetSection(string code)
        {
            Textbox txt = new Textbox(bySectionCode);
            txt.SetText(code);
        }

        public void SetShortDescription(string value)
        {
            Textbox txt = new Textbox(byShortDescription);
            txt.SetText(value);
        }

        public void SetYear(string value)
        {
            Textbox txt = new Textbox(byYear);
            txt.SetText(value);

        }

        public void SetSeasonByText(string value)
        {
            Textbox txt = new Textbox(bySeasonTextbox);
            txt.SetText(value);
        }

        public void SetFacilityByText(string value)
        {
            Textbox txt = new Textbox(byFacilityTextbox);
            txt.SetText(value);
        }

        public void SetBeginDate(DateTime value)
        {
            DatePicker pick = new DatePicker(byBeginDatePicker);
            pick.SetDate(value);
        }

        public void SetEndDate(DateTime value)
        {
            DatePicker pick = new DatePicker(byEndDatePicker);
            pick.SetDate(value);
        }
        
        public void SetBeginTime(DateTime value)
        {
            // convert to correct time string
            string inputValue = value.ToString("hh:mm tt");
            Textbox txt = new Textbox(byBeginTimeTextbox);
            txt.SetText(inputValue);
        }

        public void SetEndTime(DateTime value)
        {
            string inputValue = value.ToString("hh:mm tt");
            Textbox txt = new Textbox(byEndTimeTextbox);
            txt.SetText(inputValue);
        }

        public void ClickAllDays()
        {
            ClickMonday();
            ClickTuesday();
            ClickWednesday();
            ClickThursday();
            ClickFriday();
            ClickSaturday();
            ClickSunday();
        }

        public void ClickMonday()
        {
            Element span = new Element(byMondayVisible);
            span.Click();
        }

        public void ClickTuesday()
        {
            Element span = new Element(byTuesdayVisible);
            span.Click();
        }
        public void ClickWednesday()
        {
            Element span = new Element(byWednesdayVisible);
            span.Click();
        }
        public void ClickThursday()
        {
            Element span = new Element(byThursdayVisible);
            span.Click();
        }
        public void ClickFriday()
        {
            Element span = new Element(byFridayVisible);
            span.Click();
        }
        public void ClickSaturday()
        {
            Element span = new Element(bySaturdayVisible);
            span.Click();
        }
        public void ClickSunday()
        {
            Element span = new Element(bySundayVisible);
            span.Click();
        }
    }
}

