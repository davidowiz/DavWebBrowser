using System;
using System.Collections.Generic;
using DavWebCreator.Server.Models.Browser.Elements;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
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
            browserElement.Parent = this.Id;
            this.Elements.Add(browserElement);
        }
    }
}
