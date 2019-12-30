using System;

namespace DavWebCreator.Server.Models.Browser.Elements.Controls
{
    [Serializable]
    public class BrowserDropDownValue
    {
        public string HiddenValue { get; set; }
        public string Value { get; set; }

        public BrowserDropDownValue(string value, string hiddenValue)
        {
            this.HiddenValue = hiddenValue;
            this.Value = value;
        }
    }
}
