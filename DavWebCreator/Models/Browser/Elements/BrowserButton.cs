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

        public BrowserButton(Position position, string text, string remoteEvent)
            :base(BrowserElementType.Button, position, remoteEvent)
        {
            this.Text = text;
            this.TextAlign = BrowserTextAlign.center;
            this.Width = "100%";
            this.Height = "60px";
            this.Cursor = "pointer";
            this.StyleClass = "btn btn-primary";
            this.TextAlign = BrowserTextAlign.center;
        }
    }
}
