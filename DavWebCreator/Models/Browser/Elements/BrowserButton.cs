using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Resources.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserButton : BrowserElementWithEvent, IBrowserFont
    {
        public string FontFamily { get; set; }
        public string FontColor { get; set; }
        public BrowserTextAlign TextAlign { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }
        public string Text { get; set; }

        public BrowserButton(Position position, string text, string remoteEvent, string fontSize, string fontFamily, string color, BrowserTextAlign textAlign, bool bold = false)
            :base(BrowserElementType.Button, position, remoteEvent)
        {
            this.Text = text;
            this.FontFamily = fontFamily;
            this.FontSize = fontSize;
            this.Bold = bold;
            this.FontColor = color;
            this.TextAlign = textAlign;
        }
    }
}
