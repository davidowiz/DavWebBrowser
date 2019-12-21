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
            string remoteEvent, bool bold = false, string cursor = "pointer", string styleClasses = "", string width = "120px", string height ="35px", string margin = "2px 2px 2px 2px", string padding = "2px 2px 2px 2px") : base(type, position, width, height, cursor, margin, padding,styleClasses)
        {
            this.RemoteEvent = remoteEvent;   
            this.ReturnObjects = new List<BrowserRemoteReturnObject>();
        }
        
        /// <summary>
        /// The passed elements will be later returned to the remote event, including the current value of the DOM (HTML) Element.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="returnType"></param>
        public void AddReturnObject(BrowserElement element, ReturnType returnType = ReturnType.Text)
        {
            this.ReturnObjects.Add(new BrowserRemoteReturnObject(element.Id, element.Type, returnType));
        }
    }
}
