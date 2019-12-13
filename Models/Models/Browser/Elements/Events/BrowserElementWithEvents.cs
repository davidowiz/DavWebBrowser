using DavWebCreator.Resources.Models.Browser.Elements.Events;
using Resources.Models.Browser;
using Resources.Models.Browser.Elements;
using System;
using System.Collections.Generic;

namespace DavWebCreator.Resources.Models.Browser.Elements
{
    public class BrowserElementWithEvent : BrowserElement
    {
        // Remote Events
        public string RemoteEvent { get; set; }

        public List<BrowserRemoteReturnObject> ReturnObjects { get; set; }

        // CSS Properties
        public string Title { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }

        public BrowserElementWithEvent(string title, string fontSize, BrowserElementType type, Position position,
            string remoteEvent, bool bold = false) : base(type, position)
        {
            this.RemoteEvent = remoteEvent;
            this.Title = title;
            this.FontSize = fontSize;
            this.Bold = bold;
        }
        
        public void AddReturnObject(Guid id, Type returnType)
        {
            this.ReturnObjects.Add(new BrowserRemoteReturnObject(id, returnType));
        }
    }
}
