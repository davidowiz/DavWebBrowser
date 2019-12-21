using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserCheckBox : BrowserElement, IBrowserFont
    {
        public string Text { get; set; }
        public string FontSize { get; set; }
        public string FontFamily { get; set; }
        public bool Bold { get; set; }
        public string FontColor { get; set; }
        public bool IsChecked { get; set; }
        public BrowserTextAlign TextAlign { get; set; }

        public BrowserCheckBox(Position position, string text, bool isChecked, string fontSize, string fontFamily, bool bold, string width, string height,string color, BrowserTextAlign textAlign)
            :base(BrowserElementType.Checkbox, position)
        {
            this.Text = text;
            this.IsChecked = isChecked;
            this.FontSize = fontSize;
            this.FontFamily = FontFamily;
            this.Bold = bold;
            this.Width = width;
            this.Height = height;
            this.TextAlign = textAlign;
            this.FontColor = color;
            this.FontFamily = fontFamily;
        }
    }
}
