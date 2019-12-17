
using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserTextBox : BrowserElement
    {
        public string PlaceHolder { get; set; }
        public string Text { get; set; }      
        public bool ReadOnly { get; set; }
        public BrowserTextBox(Position position, string placeHolder, string text, bool readOnly)
            :base(BrowserElementType.TextBox, position)
        {
            this.PlaceHolder = placeHolder;
            this.Text = text;
            this.ReadOnly = readOnly;
        }
    }
}
