using Browsers.Models.BrowserModels.Elements;
using System;
using System.Collections.Generic;

namespace Browsers.Models.BrowserModels
{
    public interface IBrowser
    {
        Guid Id { get; set; }
        string Path { get; set; }
        BrowserType Type { get; set; }
        Position Position { get; set; }
        List<BrowserButton> Buttons { get; set; }
        string Width { get; set; }
        string Height { get; set; }
    }
}
