using System.Collections.Generic;

namespace Resources.Models.Browser.Elements
{
    public class BrowserContainer : BrowserElement
    {
        public List<BrowserElement> Elements { get; set; }
        public BrowserContainer(Position position)
            : base(BrowserElementType.Container, position)
        {
            Elements = new List<BrowserElement>();
        }

        public void AddElement(BrowserElement browserElement)
        {
            this.Elements.Add(browserElement);
        }
    }
}
