using System;
using System.Collections.Generic;

namespace Resources.Models.Browser.Elements
{
    public class Browser : IBrowser
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public BrowserType Type { get; set; }
        public List<BrowserElement> Elements { get; set; }
        public Position Position { get; set; }



        public Browser(string title, BrowserType type, Position position)
        {
            this.Path = "DavWebCreater/Custom/Template.html";
            this.Type = type;
            this.Position = position;
            this.Elements.Add(new BrowserTitle(Position.Mid, "Hello", "12px", true));
          
        }


        public void OpenBrowser(double width, double height)
        {
            
        }

        public void AddElement(BrowserElement element)
        {
            this.Elements.Add(element);
        }
    }
}
