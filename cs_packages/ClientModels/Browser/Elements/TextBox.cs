
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;

namespace Browsers.Models.BrowserModels.Elements
{
    public class BrowserTextBox : IBrowserElement
    {
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public BrowserElementType Type { get; set; }
        public Position Position { get; set; }
        public BrowserTextAlign TextAlign { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public bool LoadingIndicator { get; set; }
        public string PlaceHolder { get; set; }
        public string Text { get; set; }      
        public bool ReadOnly { get; set; }
    }
}
