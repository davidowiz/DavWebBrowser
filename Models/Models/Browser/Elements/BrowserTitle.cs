using System;
using System.Runtime.Serialization;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    [DataContract(Name = "BrowserTitle", Namespace = "Browsers.Models.BrowserModels.Elements")]
    public class BrowserTitle : BrowserElement
    {
        public string Title { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }

        public BrowserTitle()
            :base(BrowserElementType.Title, Position.Mid)
        {

        }
        public BrowserTitle(Position position, string title, string fontSize, bool bold)
            :base(BrowserElementType.Title, position)
        {
            this.Title = title;
            this.FontSize = fontSize;
            this.Bold = bold;
        }
    }
}
