using GTANetworkAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using DavWebCreator.Server.Models.Browser.Elements;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public class Browser : IBrowser
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public BrowserType Type { get; set; }
        public BrowserGridLayout GridLayout {get; set; }
        public virtual List<BrowserButton> Buttons { get; set; }
        [JsonIgnore] 
        // Elements are seperated by position 
        public List<BrowserElement> Elements { get; private set; }

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
            this.Buttons = new List<BrowserButton>();
            this.Width = width;
            this.Height = height;
        }

        

        public void OpenBrowser(Client player)
        {
            //NAPI.Util.ConsoleOutput(JsonConvert.SerializeObject(this));
            player.TriggerEvent("INITIALIZE_CEF_BROWSER", JsonConvert.SerializeObject(this),
                JsonConvert.SerializeObject(this.Elements.Where(w => w.Type == BrowserElementType.Title)),
                JsonConvert.SerializeObject(this.Elements.Where(w => w.Type == BrowserElementType.Text)),
                JsonConvert.SerializeObject(this.Elements.Where(w => w.Type == BrowserElementType.Checkbox)),
                JsonConvert.SerializeObject(this.Elements.Where(w=> w.Type == BrowserElementType.Button)),
                JsonConvert.SerializeObject(this.Elements.Where(w=> w.Type == BrowserElementType.TextBox)),
                JsonConvert.SerializeObject(this.Elements.Where(w=> w.Type == BrowserElementType.Card)));


            //NAPI.Util.ConsoleOutput(this.Elements.Where(w => w.Type == BrowserElementType.Button).ToString());
        }

        public void AddElement(BrowserElement element)
        {
            element.OrderIndex = this.Elements.Count + 1;
            switch (element.Type)
            {
                //case BrowserElementType.Button:
                //    BrowserButton button = element as BrowserButton;
                    
                //    Buttons.Add(button);
                //    break;
                default:
                    this.Elements.Add(element);
                    break;
            }
          
        }

        public override string ToString()
        {
            return string.Format(this.Id + " | " + this.Path + " | " + this.Position + " | " + this.Type);
        }
    }
}
