using DavWebCreator.Resources.Models.Browser.Elements;
using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class BrowserButton : BrowserElementWithEvent
    {
        public BrowserButton(Position position, string title, string fontSize, string remoteEvent, bool bold = false)
            :base(title, fontSize, BrowserElementType.Title, position, remoteEvent, bold)
        {
            this.Title = title;
            this.FontSize = fontSize;
            this.Bold = bold;
        }
    }
}
