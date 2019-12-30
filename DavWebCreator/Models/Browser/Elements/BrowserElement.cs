using System;
using Browsers.Models.BrowserModels;

namespace DavWebCreator.Server.Models.Browser.Elements
{
    public class BrowserElement
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
        /// <summary>
        /// Checkout the following link to see the available classes.
        /// https://getbootstrap.com/docs/4.0/components/buttons/
        /// </summary>
        public string StyleClass { get; set; }


        public BrowserElement(BrowserElementType type, Position position)
        {
            this.Id = Guid.NewGuid();
            this.Type = type;
            this.Position = position;
            LoadingIndicator = false;
            //this.Width = "100px";
            //this.Height = "30px";
            //this.Cursor = "auto";
            //this.Margin = "2px 2px 2px 2px";
            //this.Padding = "2px 2px 2px 2px";
            this.StyleClass = "";
            this.AnimationType = BrowserElementAnimationType.None;
        }
    }
}
