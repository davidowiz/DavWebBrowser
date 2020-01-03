using System;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Resources.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Controls;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;

namespace DavWebCreator.Server.Models.Browser.Components
{
    [Serializable]
    public class BrowserYesNoDialog : BrowserElementWithEvent, IBrowserFont
    {
        public BrowserTitle Title { get; set; }
        public BrowserTitle SubTitle { get; set; }
        public BrowserButton SuccessButton { get; set; }
        public BrowserText Text { get; set; }
        public BrowserButton DismissButton { get; set; }
        public string FontFamily { get; set; }
        public string FontSize { get; set; }
        public string FontColor { get; set; }
        public bool Bold { get; set; }
        public BrowserTextAlign TextAlign { get; set; }

        public BrowserYesNoDialog(Position position, string remoteEvent, string title, string subTitle, string text, string successButtonText, string dismissButtonText) : base(BrowserElementType.YesNoDialog, remoteEvent)
        {
            this.Title = new BrowserTitle(title, BrowserTextAlign.center);
            this.SubTitle = new BrowserTitle(subTitle, BrowserTextAlign.center);
            this.Text = new BrowserText(text, BrowserTextAlign.center);

            this.SuccessButton = new BrowserButton(successButtonText, remoteEvent);
            this.SuccessButton.SetPredefinedButtonStyle(BrowserButtonStyle.Green);
            this.SuccessButton.Width = "150px";
            this.SuccessButton.Height = "40px";
            this.SuccessButton.TextAlign = BrowserTextAlign.center;
            this.SuccessButton.Margin = "0 0 0 8px";
            this.SuccessButton.AddReturnObject(SuccessButton, "someHiddenValue");

            this.DismissButton = new BrowserButton(dismissButtonText, remoteEvent);
            this.DismissButton.SetPredefinedButtonStyle(BrowserButtonStyle.Red);
            this.DismissButton.Width = "150px";
            this.DismissButton.Height = "40px";
            this.DismissButton.TextAlign = BrowserTextAlign.center;
            this.DismissButton.Margin = "0 8px 0 0";
            this.DismissButton.AddReturnObject(DismissButton, "someHiddenValue"); // Return Dismiss Button Text to let know which button was pressed


            this.Margin = "30% 30% 30% 30%";
        }

        public void SetSuccessButtonDesign()
        {

        }

    }
}
