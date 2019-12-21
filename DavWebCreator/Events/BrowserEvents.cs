using GTANetworkAPI;
using Newtonsoft.Json;
using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using System.Collections.Generic;
using System.Reflection.Metadata;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using DavWebCreator.Server.ClientModels.Browser.Elements;
using DavWebCreator.Server.ClientModels.Browser.Elements.Events;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Cards;

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
            var card = new BrowserCard("Verdana", "16px", "black", true, "Login", "Write more content",
                "The content prices having a peek right now. Login and see what the actual fish is going on there",
                BrowserCardType.HeaderAndContent, BrowserElementType.Card, Position.Mid, "100%", "100%");

            //var userNameTextBox = new BrowserTextBox(Position.Mid, "", "", "Username", false, "12px", "black", "Verdana",
            //    BrowserTextAlign.center, false, 300, "90%", "30px");
            //card.AddElement(userNameTextBox.Id);
            //browser.AddElement(userNameTextBox);

            var passwordTextBox = new BrowserTextBox(Position.Mid, "asd", "asd", "sumnamus", false, "12px", "black", "Verdana",
                BrowserTextAlign.center, false, 300, "90%", "30px");
            card.AddElement(passwordTextBox.Id);
            browser.AddElement(passwordTextBox);

            var passwordTextBox2 = new BrowserTextBox(Position.Mid, "asd", "dsa", "passwordus", false, "12px", "black", "Verdana",
                BrowserTextAlign.center, false, 300, "90%", "30px");
            card.AddElement(passwordTextBox2.Id);
            browser.AddElement(passwordTextBox2);

            var checkBox = new BrowserCheckBox(Position.Mid, "Remember password?", true, "15px", "Verdana", false, "18px", "18px",
                "black", BrowserTextAlign.center);
            card.AddElement(checkBox.Id);
            browser.AddElement(checkBox);

            // Lets add a button which will fire a event. Additionally you can add return objects.
            var button = new BrowserButton(Position.Mid, "Confirm", "RandomEvent", "32px", "Verdana", "white", BrowserTextAlign.center, "100%",
                "60px" , false, "pointer", "2px 2px 2px 2px", "2px 2px 2px 2px", "btn btn-primary");

            //If the button click event will be fired, the following values will be returned. (ORDER = You give order = you get same order back)
      
            button.AddReturnObject(checkBox, ReturnType.Boolean); // Check IsChecked Value
            button.AddReturnObject(passwordTextBox2); // Password Text Box Value
            button.AddReturnObject(passwordTextBox); // Username Text Box Value 

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
            foreach (var arg in args)
            {
                NAPI.Util.ConsoleOutput("DEBUG: " + arg.ToString());
            }

            // Do stuff
        }

        

        [RemoteEvent("RandomEvent")]
        public void ButtonClicked(Client player, object[] args)
        {
            var responses = JsonConvert.DeserializeObject<List<BrowserClickEventResponse>>(args[0].ToString());

         
            var usernameTextBox = responses[0];
            var passwordTextBox = responses[1];
            var checkboxElement = responses[2];

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
