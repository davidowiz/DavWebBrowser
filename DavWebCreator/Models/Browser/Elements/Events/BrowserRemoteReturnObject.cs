using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Server.ClientModels.Browser.Elements;
using DavWebCreator.Server.ClientModels.Browser.Elements.Events;
using System;

namespace DavWebCreator.Resources.Models.Browser.Elements.Events
{
    [Serializable]
    public class BrowserRemoteReturnObject
    {
        public Guid Id { get; set; }
        public BrowserElementType ElementType { get; set; }
        public ReturnType ReturnTypeOfRemoteEvent { get; set; }

        public BrowserRemoteReturnObject(Guid id, BrowserElementType elementType, ReturnType returnType)
        {
            this.Id = id;
            this.ReturnTypeOfRemoteEvent = returnType;
            this.ElementType = elementType;
        }
    }
}
