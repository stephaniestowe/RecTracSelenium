using OpenQA.Selenium;
using System.Collections.Generic;


namespace RecTracPom.OnScreenElements
{
    //TODO: Would this be better as an abstract class? Can I set default implementations so the things that are totally the same across 
    // implementations would not have to be redone? Don't think so. Not sure I could write to an abstract class the same way as an interface....
    public interface IUpdatePanel
    {

        List<Textbox> Required { get;  }

        void SetRequiredValues(string value);

        void SetChangeValue(string value);

    }
}
