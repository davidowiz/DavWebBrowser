using Browsers.Models.BrowserModels.Elements;

namespace DavWebCreator.Server.ClientModels.Browser.Elements.Events
{
    public class BrowserClickEventResponse
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public BrowserElementType Type { get; set; }
    }
}
