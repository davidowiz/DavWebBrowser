using Browsers.Models.BrowserModels.Elements;
using System;
using System.Collections.Generic;

namespace Browsers.Models.BrowserModels
{
    [Serializable]
    public class Browser : IBrowser
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public BrowserType Type { get; set; }
        public List<BrowserElement> Elements { get; set; }
        public Position Position { get; set; }

        public Browser()
        {

        }

        public Browser(string title, BrowserType type, Position position)
        {
            this.Id = Guid.NewGuid();
            this.Path = $"package://statics/DavWebCreater/Custom/Template.html";
            this.Type = type;
            this.Position = position;
            this.Elements = new List<BrowserElement>();
        }


        public void OpenBrowser(double width, double height)
        {
            
        }

        public void AddElement(BrowserElement element)
        {
            this.Elements.Add(element);
        }

        public override string ToString()
        {
            return string.Format(this.Id + " | " + this.Path + " | " + this.Position + " | " + this.Type);
        }
    }
}
