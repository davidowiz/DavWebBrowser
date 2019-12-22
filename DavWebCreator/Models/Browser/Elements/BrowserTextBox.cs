
using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;
using DavWebCreator.Server.Models.Browser.Elements;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserTextBox : BrowserElement, IBrowserFont
    {
        private BrowserElementType textBox;

        public string PlaceHolder { get; set; }
        public string LabelText { get; set; }      
        public string Text { get; set; }
        public bool ReadOnly { get; set; }
        public string FontFamily { get; set; }
        public string FontSize { get; set; }
        public string FontColor { get; set; }
        public bool Bold { get; set; }
        public short MaxLength { get; set; }
        public BrowserTextAlign TextAlign { get; set; }

        public BrowserTextBox(Position position, string placeHolder, string text, string labelText, bool readOnly)
            :base(BrowserElementType.TextBox, position)
        {
            this.PlaceHolder = placeHolder;
            this.LabelText = labelText;
            this.Text = text;
            this.ReadOnly = readOnly;
            this.Bold = false;
            this.MaxLength = 50;
            this.Width = "120px";
            this.Height = "25ox";
            this.Cursor = "pointer";
            this.TextAlign = BrowserTextAlign.center;
            this.ReadOnly = false;
            this.Width = "100%";
            this.Height = "30px";
        }
    }
}
