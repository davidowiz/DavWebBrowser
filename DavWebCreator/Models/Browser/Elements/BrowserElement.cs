using System;

namespace Browsers.Models.BrowserModels.Elements
{
    public class BrowserElement
    {
        public Guid Id { get; set; }
        public BrowserElementType Type { get; set; }
        public Position Position { get; set; }
        public Guid? Parent { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public bool LoadingIndicator { get; set; }

        public BrowserElement()
        {
            Width = "100px";
            Height = "100px";
            LoadingIndicator = false;
        }

        public BrowserElement(BrowserElementType type, Position position)
        {
            this.Id = Guid.NewGuid();
            this.Type = type;
            this.Position = position;

            Width = "100px";
            Height = "100px";
            LoadingIndicator = false;
        }
    }
}
