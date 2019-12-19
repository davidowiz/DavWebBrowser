using Browsers.Models.BrowserModels.Elements;
using System;
using System.Collections.Generic;

namespace Browsers.Models.BrowserModels
{
    public class Browser : IBrowser
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public BrowserType Type { get; set; }
        public Position Position { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }
}
