using System;
using System.Collections.Generic;

namespace Browsers.Models.BrowserModels.Elements
{
    public class BrowserContainer : IBrowserElement
    {
        public Guid Id { get; set; }
        public int OrderIndex { get; set; }
        public BrowserElementType Type { get; set; }
        public Position Position { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public bool LoadingIndicator { get; set; }
        public List<IBrowserElement> Elements { get; set; }
    }
}
