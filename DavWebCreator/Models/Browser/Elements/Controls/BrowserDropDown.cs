using System;
using System.Collections.Generic;
using System.Text;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;

namespace DavWebCreator.Server.Models.Browser.Elements.Controls
{
    [Serializable]
    public class BrowserDropDown : BrowserElement
    {
        public BrowserText Label { get; set; }

        public List<BrowserDropDownValue> Values { get; set; }

        public BrowserDropDown(string labelText) : base(BrowserElementType.DropDown)
        {
            this.Values = new List<BrowserDropDownValue>();
            this.Label = new BrowserText("", labelText, BrowserTextAlign.center);
        }

        public void AddDropDownValue(string value, string hiddenValue)
        {
            this.Values.Add(new BrowserDropDownValue(value, hiddenValue));
        }
    }
}
