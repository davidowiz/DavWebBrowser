using System;

namespace DavWebCreator.Resources.Models.Browser.Elements.Events
{
    [Serializable]
    public class BrowserRemoteReturnObject
    {
        public Guid Id { get; private set; }
        public Type ReturnTypeOfRemoteEvent { get; private set; }

        public BrowserRemoteReturnObject(Guid id, Type returnType)
        {
            this.Id = id;
            this.ReturnTypeOfRemoteEvent = returnType;
        }
    }
}
