using System;

namespace Browsers.Models.BrowserModels.Elements
{
    public class BrowserElement
    {
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public BrowserElementType Type { get; set; }
        public Position Position { get; set; }
        public Guid Parent { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Margin { get; set; }
        public string Padding { get; set; }
        public string Cursor { get; set; }
        public bool LoadingIndicator { get; set; }
        /// <summary>
        /// Checkout the following link to see the available classes.
        /// https://getbootstrap.com/docs/4.0/components/buttons/
        /// </summary>
        public string StyleClass { get; set; }

        public BrowserElement()
        {
            Width = "100px";
            Height = "100px";
            LoadingIndicator = false;
        }


        public BrowserElement(BrowserElementType type, Position position, string width = "100px", string height = "30px", string cursor = "auto", string margin = "2px 2px 2px 2px", string padding = "2px 2px 2px 2px", string styleClasses = "")
        {
            this.Id = Guid.NewGuid();
            this.Type = type;
            this.Position = position;
            LoadingIndicator = false;
            this.Width = width;
            this.Height = height;
            this.Cursor = cursor;
            this.StyleClass = styleClasses;
            this.Margin = margin;
            this.Padding = padding;
        }
    }
}
