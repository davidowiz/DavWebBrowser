using System;
using Browsers.Models.BrowserModels;

namespace DavWebCreator.Server.Models.Browser.Elements
{
    public abstract class BrowserElement
    {
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public BrowserElementType Type { get; set; }
        public BrowserElementAnimationType AnimationType { get; set; }
        public Position Position { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Margin { get; set; }
        public string Padding { get; set; }
        public string Cursor { get; set; }
        public bool LoadingIndicator { get; set; }
        public string BackGroundColor { get; set; }
        public string Opacity { get; set; }
        public string StyleClass { get; set; }
        public int Row { get; set; }


        protected BrowserElement(BrowserElementType type)
        {
            this.Id = Guid.NewGuid();
            this.Type = type;
            LoadingIndicator = false;
            this.StyleClass = "";
            this.AnimationType = BrowserElementAnimationType.None;
            this.Row = 1;
        }
    }
}
