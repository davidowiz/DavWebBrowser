using System;
using System.Collections.Generic;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;

namespace DavWebCreator.Server.Models.Browser.Elements.Cards
{
    public class BrowserCard : BrowserElement, IBrowserFont
    {
        public string FontFamily { get; set; }
        public string FontSize { get; set; }
        public string FontColor { get; set; }
        public bool Bold { get; set; }
        public bool ExitButton { get; set; }
        public string ContentTitle { get; set; }
        public string ContentText { get; set; }
        public string CardTitle { get; set; }
        public BrowserTextAlign TextAlign { get; set; }
        public BrowserCardType CardType { get; set; }
        public BrowserContentAlign ItemsAlign { get; set; }
        public string Image { get; set; }
        public int CurrentRow { get; set; }

        public List<Guid> ChildElements { get; private set; }


        public BrowserCard(BrowserElementType type, BrowserCardType cardType, string cardTitle, string contentTitle, string contentText) : base(type)
        {
            this.CardTitle = cardTitle;
            this.ContentTitle = contentTitle;
            this.ContentText = contentText;
            this.ChildElements = new List<Guid>();
            this.CardType = cardType;
            this.ExitButton = true;
            this.CurrentRow = 1;
            this.Row = 1;
            this.Padding = "0 0 0 0";
            this.Margin = "5px 0 5px 0";
        }

        public int AddElement(Guid id)
        {
            this.ChildElements.Add(id);
            return CurrentRow;
        }

        public void NextRow()
        {
            CurrentRow++;
        }


    }
}
