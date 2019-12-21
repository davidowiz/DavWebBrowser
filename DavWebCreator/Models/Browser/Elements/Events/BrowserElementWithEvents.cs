using DavWebCreator.Resources.Models.Browser.Elements.Events;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using System;
using System.Collections.Generic;
using DavWebCreator.Server.ClientModels.Browser.Elements;
using DavWebCreator.Server.ClientModels.Browser.Elements.Events;

namespace DavWebCreator.Resources.Models.Browser.Elements
{
    [Serializable]
    public class BrowserElementWithEvent : BrowserElement
    {
        // Remote Events
       // public string Title { get; set; }
        public string RemoteEvent { get; set; }

        public List<BrowserRemoteReturnObject> ReturnObjects { get; set; }

        public BrowserElementWithEvent(BrowserElementType type, Position position,
            string remoteEvent, bool bold = false) : base(type, position)
        {
            this.RemoteEvent = remoteEvent;
    

            this.ReturnObjects = new List<BrowserRemoteReturnObject>();
        }
        
        public void AddReturnObject(BrowserElement element, ReturnType returnType)
        {
            this.ReturnObjects.Add(new BrowserRemoteReturnObject(element.Id, element.Type, returnType));
        }
    }
}
