using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;

namespace DavWebCreator.Server.Models.Browser.Elements
{
    public class BrowserText : BrowserElement, IBrowserFont
    {
        public string Text { get; set; }
        public string FontSize { get; set; }
        public string FontFamily { get; set; }
        public string LabelText { get; set; }
        public bool Bold { get; set; }
        public string FontColor { get; set; }
        public BrowserTextAlign TextAlign { get; set; }
        
        public BrowserText(Position position,string labelText, string text, string fontSize, string fontFamily, bool bold, string fontColor, string width, string height, BrowserTextAlign textAlign)
            : base(BrowserElementType.Text, position)
        {
            this.Text = text;
            this.FontSize = fontSize;
            this.FontFamily = fontFamily;
            this.LabelText = labelText;
            this.Bold = bold;
            this.FontColor = fontColor;
            this.Width = width;
            this.Height = height;
            this.TextAlign = textAlign;
        }

        public BrowserText(Position position, string text, BrowserTextAlign textAlign)
            : base(BrowserElementType.Text, position)
        {
            this.Text = text;
            this.TextAlign = textAlign;
        }
    }
}
