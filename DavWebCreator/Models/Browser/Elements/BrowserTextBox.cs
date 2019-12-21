
using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserTextBox : BrowserElement, IBrowserFont
    {
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

        public BrowserTextBox(Position position, string placeHolder, string text, string labelText, bool readOnly, string fontSize, string fontColor, string fontFamily, BrowserTextAlign textAlign, bool bold = false, short maxLength = 50, string width = "120px", string height = "25px", string cursor = "pointer")
            :base(BrowserElementType.TextBox, position, width, height, cursor, styleClasses: "")
        {
            this.PlaceHolder = placeHolder;
            this.LabelText = labelText;
            this.Text = text;
            this.ReadOnly = readOnly;
            this.Bold = bold;
            this.FontFamily = fontFamily;
            this.FontColor = fontColor;
            this.FontSize = fontSize;
            this.MaxLength = maxLength;
            this.TextAlign = textAlign;
        }
    }
}
