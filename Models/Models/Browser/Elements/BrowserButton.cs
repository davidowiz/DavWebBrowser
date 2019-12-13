using DavWebCreator.Resources.Models.Browser.Elements;

namespace Resources.Models.Browser.Elements
{
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
