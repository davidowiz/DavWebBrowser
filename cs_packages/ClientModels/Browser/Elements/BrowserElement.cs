using System;

namespace Browsers.Models.BrowserModels.Elements
{
    public interface IBrowserElement
    {
        Guid Id { get; set; }
        int OrderIndex { get; set; }
        BrowserElementType Type { get; set; }
        Position Position { get; set; }
        string Width { get; set; }
        string Height { get; set; }
        bool LoadingIndicator { get; set; }
    }
}
