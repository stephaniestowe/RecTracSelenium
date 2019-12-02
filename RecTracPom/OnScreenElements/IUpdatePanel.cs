using OpenQA.Selenium;
using System.Collections.Generic;


namespace RecTracPom.OnScreenElements
{
    public interface IUpdatePanel
    {

        List<Textbox> Required { get;  }

        void SetRequiredValues(string value);

        void SetChangeValue(string value);

    }
}
