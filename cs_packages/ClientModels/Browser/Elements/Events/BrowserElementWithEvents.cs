using DavWebCreator.Resources.Models.Browser.Elements.Events;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using System;
using System.Collections.Generic;

namespace DavWebCreator.Resources.Models.Browser.Elements
{
    public class BrowserElementWithEvent : IBrowserElement
    {

        public Guid Id { get; set; }
        public BrowserElementType Type { get; set; }
        public Position Position { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public bool LoadingIndicator { get; set; }
        public int OrderIndex { get; set; }

        // Remote Events
        public string RemoteEvent { get; set; }

        public List<BrowserRemoteReturnObject> ReturnObjects { get; set; }

        // CSS Properties
        public string Title { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }

        public BrowserElementWithEvent(string title, string fontSize, BrowserElementType type, Position position,
            string remoteEvent, bool bold = false)
        {
            this.RemoteEvent = remoteEvent;
            this.Type = type;
            this.Position = position;
            this.Title = title;
            this.FontSize = fontSize;
            this.Bold = bold;

            this.ReturnObjects = new List<BrowserRemoteReturnObject>();
        }
        
        public void AddReturnObject(Guid id, Type returnType)
        {
            this.ReturnObjects.Add(new BrowserRemoteReturnObject(id, returnType));
        }
    }
}
