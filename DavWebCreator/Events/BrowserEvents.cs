using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Server.ClientModels.Browser.Elements;
using DavWebCreator.Server.ClientModels.Browser.Elements.Events;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Cards;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using GTANetworkAPI;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DavWebCreator.Events
{
    public class BrowserEvents : Script
    {
        public BrowserEvents()
        {

        }

        /// <summary>
        /// Generates the following CEF Browser ->
        /// <div>
        ///     <h1>Title</h1>
        ///     <input type="button"/>
        ///     <input type="button"/>
        /// </div>
        /// </summary>
        /// <param name="player"></param>
        [Command("b")]
        public void CreateExampleBrowser(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, Position.Mid, "100%", "100%");
            // Container
            BrowserCard card = new BrowserCard(Position.Mid, BrowserElementType.Card, BrowserCardType.HeaderAndContent,
                "Login", "Write more content",
                "The content prices having a peek right now. Login and see what the actual fish is going on there");

            card.Width = "600px";
            card.Height = "400px";
            card.TextAlign = BrowserTextAlign.center;
            card.Margin = "0px 0px 5px 1px";

            BrowserTextBox usernameTextBox = new BrowserTextBox(Position.Mid, "type in username...", "", "Username", false);
            
            card.AddElement(usernameTextBox.Id);
            browser.AddElement(usernameTextBox);

            BrowserTextBox passwordTextBox2 = new BrowserTextBox(Position.Mid, "type in password...", "", "Password", false);
            card.AddElement(passwordTextBox2.Id);
            browser.AddElement(passwordTextBox2);

            BrowserTextBox passwordTextBox3 = new BrowserTextBox(Position.Mid, "placeholder...", "", "More input", false);
            card.AddElement(passwordTextBox3.Id);
            browser.AddElement(passwordTextBox3);

            BrowserTextBox passwordTextBox5 = new BrowserTextBox(Position.Mid, "placeholder...", "", "Fisch", false);
            card.AddElement(passwordTextBox5.Id);
            browser.AddElement(passwordTextBox5);

            BrowserCheckBox checkBox = new BrowserCheckBox(Position.Mid, "Remember password?", true, "15px", "Verdana", false, "18px", "18px",
                "black", BrowserTextAlign.center);
            card.AddElement(checkBox.Id);
            browser.AddElement(checkBox);

            // Lets add a button which will fire a event. Additionally you can add return objects.
            BrowserButton button = new BrowserButton(Position.Mid, "Confirm", "RandomEvent");

            //If the button click event will be fired, the following values will be returned. (ORDER = You give order = you get same order back)

            button.AddReturnObject(checkBox, ReturnType.Boolean); // Check IsChecked Value
            button.AddReturnObject(passwordTextBox2); // Password Text Box Value
            button.AddReturnObject(usernameTextBox); // Username Text Box Value 

            //button.AddReturnObject(userNameTextBox);

            card.AddElement(button.Id);
            browser.AddElement(button);

            // Add the card to the browser elements.
            browser.AddElement(card);

            // Open the just defined CEF Browser for the player.
            browser.OpenBrowser(player);




            //browser.AddElement(new BrowserText(Position.Mid, "som long text that i should write but i have no clue what i should write so i will let my....",
            //                        "12px", "Arial", true, "red", "100%", "100px", BrowserTextAlign.right));
        }

        [RemoteEvent("BROWSER_")]
        public void LogMeIn(Client player, bool rememberPasswordCheckbox)
        {


            // Do stuff
        }

        [RemoteEvent("BROWSER_TEXT")]
        public void TEST(Client player, params object[] args)
        {
            foreach (object arg in args)
            {
                NAPI.Util.ConsoleOutput("DEBUG: " + arg.ToString());
            }

            // Do stuff
        }



        [RemoteEvent("RandomEvent")]
        public void ButtonClicked(Client player, object[] args)
        {
            List<BrowserClickEventResponse> responses = JsonConvert.DeserializeObject<List<BrowserClickEventResponse>>(args[0].ToString());


            BrowserClickEventResponse usernameTextBox = responses[0];
            BrowserClickEventResponse passwordTextBox = responses[1];
            BrowserClickEventResponse checkboxElement = responses[2];

            player.SendChatMessage("Username ist " + usernameTextBox.Value);
            player.SendChatMessage("Password ist " + passwordTextBox.Value);
            //player.SendChatMessage("Checkbox 1 ist " + checkboxElement.Value);
        }




        //[RemoteEvent("BROWER_CLOSED", typeof(Browser))]
        //public void BrowserJustClosed(Client player, Browser browser)
        //{
        //    player.SendChatMessage("Browser closed");
        //}


        public void CloseBrowser()
        {

        }
    }
}
