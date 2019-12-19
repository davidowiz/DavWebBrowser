using System;

namespace DavWebCreator.Resources.Models.Browser.Elements.Events
{
    public class BrowserRemoteReturnObject
    {
        public Guid Id { get; set; }
        public Type ReturnTypeOfRemoteEvent { get; set; }

        public BrowserRemoteReturnObject(Guid id, Type returnType)
        {
            this.Id = id;
            this.ReturnTypeOfRemoteEvent = returnType;
        }
    }
}
