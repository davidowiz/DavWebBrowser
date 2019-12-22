
using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using System;
using DavWebCreator.Server.Models.Browser.Elements;

namespace Browsers.Models.BrowserModels.Elements
{

    [Serializable]
    public class BrowserPasswordTextBox : BrowserTextBox, IBrowserFont
    {

        public BrowserPasswordTextBox(Position position, string text, string labelText, string placeHolder, bool readOnly)
            :base(position, placeHolder, text, labelText, readOnly)
        {
            this.Type = BrowserElementType.Password;

        }
    }
}
