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


        public BrowserCard(string fontFamily, string fontSize, string fontColor, bool bold, string cardTitle, string contentTitle, string contentText, BrowserCardType cardType,BrowserElementType type, Position position, string width = "100px", string height = "30px", string cursor = "auto", string styleClasses = "") : base(type, position, width, height, cursor, styleClasses)
        {
            this.FontColor = fontColor;
            this.FontSize = fontSize;
            this.FontFamily = fontFamily;
            this.Bold = bold;
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
