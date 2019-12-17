using DavWebCreator.Clients.ClientModels.Browser.Elements;

namespace Browsers.Models.BrowserModels.Elements
{
    public class BrowserTitle : BrowserElement, IBrowserFont
    {
        public string Title { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }
        public string FontFamily { get; set; }
        public string FontColor { get; set; }

        public BrowserTitle()
            : base(BrowserElementType.Title, Position.Mid)
        {

        }

        public BrowserTitle(Position position, string title, string fontSize, string fontFamily, bool bold, string width, string height, string fontColor)
            : base(BrowserElementType.Title, position)
        {
            this.Title = title;
            this.FontSize = fontSize;
            this.Bold = bold;
            this.Width = width;
            this.Height = height;
            this.FontFamily = fontFamily;
            this.FontColor = fontColor;
        }
    }
}
