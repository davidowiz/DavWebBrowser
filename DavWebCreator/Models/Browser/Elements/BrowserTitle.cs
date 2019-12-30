using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;

namespace Browsers.Models.BrowserModels.Elements
{
    public class BrowserTitle : BrowserElement, IBrowserFont
    {
        public string Title { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }
        /// <summary>
        /// https://getbootstrap.com/docs/4.0/content/typography/
        /// </summary>
        public string FontFamily { get; set; }
        public string FontColor { get; set; }
        public BrowserTextAlign TextAlign { get; set; }

        public BrowserTitle()
            : base(BrowserElementType.Title, Position.Mid)
        {

        }

        public BrowserTitle(Position position, string title, string fontSize, string fontFamily, bool bold, string width, string height, string fontColor, BrowserTextAlign textAlign)
            : base(BrowserElementType.Title, position)
        {
            this.Title = title;
            this.FontSize = fontSize;
            this.Bold = bold;
            this.FontFamily = fontFamily;
            this.FontColor = fontColor;
            this.TextAlign = textAlign;
        }
        public BrowserTitle(Position position, string title, BrowserTextAlign textAlign)
            : base(BrowserElementType.Title, position)
        {
            this.Title = title;
            this.TextAlign = textAlign;
        }
    }
}
