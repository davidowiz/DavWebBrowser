using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Browsers.Models.BrowserModels.Elements
{
    public class Browser : IBrowser
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public BrowserType Type { get; set; }
        public List<BrowserElement> Elements { get; set; }
        public Position Position { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }

        public Browser()
        {

        }

        public Browser(string title, BrowserType type, Position position, string width, string height)
        {
            this.Id = Guid.NewGuid();
            this.Path = $"package://statics/DavWebCreator/Custom/Template.html";
            this.Type = type;
            this.Position = position;
            this.Elements = new List<BrowserElement>();
            this.Width = width;
            this.Height = height;
        }

        

        public void OpenBrowser(Client player)
        {
            player.TriggerEvent("INITIALIZE_CEF_BROWSER", JsonConvert.SerializeObject(this),
                JsonConvert.SerializeObject(this.Elements.Where(w => w.Type == BrowserElementType.Title)),
                JsonConvert.SerializeObject(this.Elements.Where(w => w.Type == BrowserElementType.Text)));
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
