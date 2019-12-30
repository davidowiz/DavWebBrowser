using DavWebCreator.Server.Models.Browser.Elements;

namespace DavWebCreator.Server.Events
{
    public class BrowserEventResponse
    {
        public string Id { get; set; }
        public string HiddenValue { get; set; }
        public string Value { get; set; }
        public BrowserElementType Type { get; set; }
    }
}
