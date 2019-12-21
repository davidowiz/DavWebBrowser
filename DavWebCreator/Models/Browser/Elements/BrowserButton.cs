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

        public BrowserButton(Position position, string text, string remoteEvent, string fontSize, string fontFamily, string color, BrowserTextAlign textAlign, string width = "200px", string height = "160px", bool bold = false, string cursor = "pointer", string margin = "2px 2px 2px 2px", string padding = "2px 2px 2px 2px", string styleClasses = "")
            :base(BrowserElementType.Button, position, remoteEvent ,false, cursor, styleClasses, width, height, margin,padding)
        {
            this.Text = text;
            this.FontFamily = fontFamily;
            this.FontSize = fontSize;
            this.Bold = bold;
            this.FontColor = color;
            this.TextAlign = textAlign;
            this.Width = width;
            this.Height = height;
        }
    }
}
