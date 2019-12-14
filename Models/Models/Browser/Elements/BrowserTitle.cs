using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserTitle : BrowserElement
    {
        public string Title { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }

        public BrowserTitle(Position position, string title, string fontSize, bool bold)
            :base(BrowserElementType.Title, position)
        {
            this.Title = title;
            this.FontSize = fontSize;
            this.Bold = bold;
        }
    }
}
