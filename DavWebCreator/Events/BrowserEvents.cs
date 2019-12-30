using System.Collections.Generic;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Server.Models.Browser;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Cards;
using DavWebCreator.Server.Models.Browser.Elements.Controls;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using DavWebCreator.Server.Models.Browser.Elements.Textboxes;
using GTANetworkAPI;
using Newtonsoft.Json;

namespace DavWebCreator.Server.Events
{
    public class BrowserEvents : Script
    {

        public BrowserEvents()
        {

        }


        /// <summary>
        /// Generates a example Drop Down CEF Browser
        /// <div>
        ///     <h1>Title</h1>
        ///     <input type="button"/>
        ///     <input type="button"/>
        /// </div>
        /// </summary>
        /// <param name="player"></param>
        [Command("d")]
        public void CreateExampleDropDownBrowser(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, Position.Mid, "100%", "100%");
            // Container
            BrowserCard card = new BrowserCard(Position.Mid, BrowserElementType.Card, BrowserCardType.HeaderAndContent,
                "Login", "Write more content", "The content prices having a peek right now. Login and see what the actual fish is going on there");

            card.Width = "600px";
            card.Height = "350px";
            card.TextAlign = BrowserTextAlign.center;
            card.Margin = "0px 0px 5px 1px";

            BrowserTextBox usernameTextBox = new BrowserTextBox(Position.Mid, "type in username...", "", "Username", false);
            usernameTextBox.TextAlign = BrowserTextAlign.center;
            usernameTextBox.Width = "180px";
            usernameTextBox.Margin = "0 5% 0 0";

            card.AddElement(usernameTextBox.Id);
            browser.AddElement(usernameTextBox);

            BrowserPasswordTextBox passwordTextBox = new BrowserPasswordTextBox(Position.Mid, "placeholder...", "sumthing", "Fisch", false, false);
            passwordTextBox.MinLength = 6;
            passwordTextBox.IsRequired = true;
            passwordTextBox.Width = "180px";
            passwordTextBox.Margin = "0 0 0 5%";

            card.AddElement(passwordTextBox.Id);
            browser.AddElement(passwordTextBox);

            BrowserButton button = new BrowserButton(Position.Mid, "Confirm", "RandomEvent");
            button.AnimationType = BrowserElementAnimationType.HeartBeat;

            button.AddReturnObject(usernameTextBox, "hiddenval");
            button.AddReturnObject(passwordTextBox, "anoterHittenValue");

            card.AddElement(button.Id);
            browser.AddElement(button);

            // Add the card to the browser elements.
            browser.AddElement(card);

            // Open the just defined CEF Browser for the player.
            browser.OpenBrowser(player);
        }

        /// <summary>
        /// Generates a example login CEF Browser
        /// <div>
        ///     <h1>Title</h1>
        ///     <input type="button"/>
        ///     <input type="button"/>
        /// </div>
        /// </summary>
        /// <param name="player"></param>
        [Command("examplelogin")]
        public void CreateExampleBrowser(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, Position.Mid, "100%", "100%");
            // Container
            BrowserCard card = new BrowserCard(Position.Mid, BrowserElementType.Card, BrowserCardType.HeaderAndContent,
                "Login", "Write more content", "The content prices having a peek right now. Login and see what the actual fish is going on there");

            card.Width = "600px";
            card.Height = "360px";
            card.TextAlign = BrowserTextAlign.center;
            card.Margin = "0px 0px 5px 1px";

            BrowserTextBox usernameTextBox = new BrowserTextBox(Position.Mid, "type in username...", "", "Username", false);
            usernameTextBox.TextAlign = BrowserTextAlign.center;
            usernameTextBox.Width = "180px";
            usernameTextBox.Margin = "0 5% 0 0";

            card.AddElement(usernameTextBox.Id);
            browser.AddElement(usernameTextBox);

            BrowserPasswordTextBox passwordTextBox = new BrowserPasswordTextBox(Position.Mid, "placeholder...", "sumthing", "Fisch", false, false);
            passwordTextBox.MinLength = 6;
            passwordTextBox.IsRequired = true;
            passwordTextBox.Width = "180px";
            passwordTextBox.Margin = "0 0 0 5%";

            card.AddElement(passwordTextBox.Id);
            browser.AddElement(passwordTextBox);

            BrowserCheckBox checkBox = new BrowserCheckBox(Position.Mid, "Remember password?", true, "15px", "Verdana", false, "18px", "18px",
                "black", BrowserTextAlign.center);

            checkBox.Margin = "15px 0 15px 0";
            card.AddElement(checkBox.Id);
            browser.AddElement(checkBox);

            //// Lets add a button which will fire a event. Additionally you can add return objects.
            BrowserButton button = new BrowserButton(Position.Mid, "Confirm", "RandomEvent");
            //button.AnimationType = BrowserElementAnimationType.HeartBeat;



            //If the button click event will be fired, the following values will be returned. (ORDER = You give order = you get same order back)
            button.AddReturnObject(checkBox, "someHiddenValue");
            button.AddReturnObject(usernameTextBox, "someHiddenValue");
            button.AddReturnObject(passwordTextBox, "someHiddenValue");

            card.AddElement(button.Id);
            browser.AddElement(button);

            // Add the card to the browser elements.
            browser.AddElement(card);

            // Open the just defined CEF Browser for the player.
            browser.OpenBrowser(player);
        }

        /// <summary>
        /// Generates a "Yes No Dialog" with the given information.
        /// <div>
        ///     <h1>Title</h1>
        ///     <input type="button"/>
        ///     <input type="button"/>
        /// </div>
        /// </summary>
        /// <param name="player"></param>
        [Command("b")]
        public void YesNoDialogExample(Client player)
        {
            Browser browser = new Browser("YesNoDialog", BrowserType.YesNoDialog, Position.Mid, "100%", "100%");
    
            browser.AddYesNoDialog("YES_NO_EXAMPLE", "Character Deletion", "WARNING", "Do you really want to delete your character?",
                "Yes", "No");


            browser.OpenBrowser(player);
        }

        [RemoteEvent("YES_NO_EXAMPLE")]
        public void YesNoExample(Client player, params object[] args)
        {
            if (args == null)
                return;

            List<BrowserEventResponse> responses = JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());


            var buttonResponse = responses[0];

            player.SendChatMessage(buttonResponse.Value + " Clicked");

            player.TriggerEvent("CLOSE_BROWSER");


            // Do stuff
        }

        [RemoteEvent("CLOSE_BROWSER")]
        public void CloseBrowser(Client player)
        {
            // Add validations?

            player.TriggerEvent("CLOSE_BROWSER_EXECUTION");
        }


        [RemoteEvent("BROWSER_")]
        public void LogMeIn(Client player, bool rememberPasswordCheckbox)
        {


            // Do stuff
        }

        [RemoteEvent("BROWSER_TEXT")]
        public void TEST(Client player, params object[] args)
        {
            if (args == null)
                return;

            foreach (object arg in args)
            {
                NAPI.Util.ConsoleOutput("DEBUG: " + arg.ToString());
            }

            // Do stuff
        }






        [RemoteEvent("RandomEvent")]
        public void ButtonClicked(Client player, object[] args)
        {
            List<BrowserEventResponse> responses = JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());

            foreach (var resp in responses)
            {
                player.SendChatMessage(resp.Value);
            }

        }


        public void CloseBrowser()
        {

        }
    }
}
