using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserCheckBox : BrowserElement
    {
        public string Text { get; set; }
        public bool IsChecked { get; set; }
        public BrowserCheckBox(Position position, string text, bool isChecked)
            :base(BrowserElementType.Checkbox, position)
        {
            this.Text = text;
            this.IsChecked = isChecked;
        }
    }
}
