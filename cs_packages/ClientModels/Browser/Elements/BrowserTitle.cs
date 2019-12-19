using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]


    public class BrowserTitle : IBrowserElement, IBrowserFont
    {
        public string Title { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public Guid? Parent { get; set; }
        public BrowserElementType Type { get; set; }
        public Position Position { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public bool LoadingIndicator { get; set; }
        public string FontFamily { get; set; }
        public string FontColor { get; set; }
        public BrowserTextAlign TextAlign { get; set; }

    }
}
