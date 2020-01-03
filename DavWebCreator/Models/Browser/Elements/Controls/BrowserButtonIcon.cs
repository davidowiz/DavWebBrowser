using System;
using Browsers.Models.BrowserModels;
using DavWebCreator.Resources.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;

namespace DavWebCreator.Server.Models.Browser.Elements.Controls
{
    /// <summary>
    /// Checkout the following link to see the available style classes.
    /// https://getbootstrap.com/docs/4.0/components/buttons/
    /// </summary>
    [Serializable]
    public class BrowserButtonIcon : BrowserElementWithEvent, IBrowserFont
    {
        public string FontFamily { get; set; }
        public string FontColor { get; set; }
        public BrowserTextAlign TextAlign { get; set; }
        public string FontSize { get; set; }
        public bool Bold { get; set; }
        public string Text { get; set; }

        public BrowserButtonIcon(string text, string remoteEvent)
            :base(BrowserElementType.Icon, remoteEvent)
        {
            this.Text = text;
            this.TextAlign = BrowserTextAlign.right;
            this.Width = "30px";
            this.Height = "30px";
            this.Cursor = "pointer";
            this.SetPredefinedButtonStyle(BrowserIcon.ArrowDown);
        }

        public void SetPredefinedButtonStyle(BrowserIcon style)
        {
            switch (style)
            {
                case BrowserIcon.ArrowDown:
                    this.StyleClass = " fas fa-arrow-alt-circle-up";
                    break;
                case BrowserIcon.ArrowUp:
                    this.StyleClass = " fas fa-arrow-alt-circle-down";
                    break;
            }
        }

        public enum BrowserIcon
        {
            ArrowUp = 1,
            ArrowDown = 2
        }
    }
}
