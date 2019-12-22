using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Cards;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;
using System.Collections.Generic;

namespace DavWebCreator.Server.Models.Browser.Elements
{
    public class BrowserCard : BrowserElement, IBrowserFont
    {
        public string FontFamily { get; set; }
        public string FontSize { get; set; }
        public string FontColor { get; set; }
        public bool Bold { get; set; }
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        public string CardTitle { get; set; }
        public BrowserTextAlign TextAlign { get; set; }
        public BrowserCardType CardType { get; set; }

        public List<Guid> ChildElements { get; private set; }


        public BrowserCard(Position position, BrowserElementType type, BrowserCardType cardType, string cardTitle, string contentTitle, string contentText) : base(type, position)
        {
            this.CardTitle = cardTitle;
            this.ContentTitle = contentTitle;
            this.ContentText = contentText;
            this.ChildElements = new List<Guid>();
            this.CardType = cardType;
        }

        public void AddElement(Guid id)
        {
            this.ChildElements.Add(id);
        }


    }
}
