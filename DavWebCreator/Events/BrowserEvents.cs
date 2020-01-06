using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Server.Models;
using DavWebCreator.Server.Models.Browser;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Cards;
using DavWebCreator.Server.Models.Browser.Elements.Controls;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using DavWebCreator.Server.Models.Browser.Elements.Textboxes;
using DavWebCreator.Server.Models.Dummys;
using GTANetworkAPI;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DavWebCreator.Server.Events
{
    /// <summary>
    /// Contains example browser
    /// </summary>
    public class BrowserEvents : Script
    {
        #region Dummy Variables
        List<VehicleDummy> vehicleDummys = new List<VehicleDummy>
        {
            new VehicleDummy(2, "Sultan RS6", 200, 100, 50, 60, true),
            new VehicleDummy(3, "Lambo Diablo GT", 140, 20, 43, 50, false),
            new VehicleDummy(4, "Banshee", 120, 30, 23, 45, false),
            new VehicleDummy(5, "Glendale", 240, 70, 63, 85, true),
            new VehicleDummy(6, "DavMobil", 240, 70, 63, 85, true),
            new VehicleDummy(6, "DavMobil", 240, 70, 63, 85, true),
            new VehicleDummy(6, "DavMobil", 240, 70, 63, 85, true),
            new VehicleDummy(6, "DavMobil", 240, 70, 63, 85, true)
        };
        #endregion

        public BrowserEvents()
        {

        }


        [Command("selector")]
        public void CreateExampleSelection(Client player)
        {

            Browser browser = new Browser("Disdas", BrowserType.Selection, Position.Mid, "100%", "800px")
            {
                BackgroundColor = "white"
            };

            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Selection Example", "", "")
            {
                Width = "500px",
                Height = "355px",
                TextAlign = BrowserTextAlign.center,
                ItemsAlign = BrowserContentAlign.Center,
                Image = $"package://statics/DavWebCreator/Custom/Images/sumArt.png",
                ScrollBarY = false
            };

            browser.AddElement(card);

            BrowserDropDown dropDown = new BrowserDropDown("Select sumthing");
            dropDown.FontColor = "black";
            dropDown.Bold = true;
            dropDown.TextAlign = BrowserTextAlign.center;
            dropDown.Width = "100%";

            BrowserButton button = new BrowserButton("sumthing", "sum");
            button.Margin = "60px 0 0 0";
            button.AddReturnObject(dropDown, "yeaas");

            dropDown.AddDropDownValue("halp", "mo");
            dropDown.AddDropDownValue("test", "goesWrong");

            card.AddElement(button.Id);
            card.AddElement(dropDown.Id);
            browser.AddElement(dropDown);
            browser.AddElement(button);

            browser.OpenBrowser(player);
        }

        [Command("card")]
        public void CreateExampleBoxes(Client player)
        {

            Browser browser = new Browser("Disdas", BrowserType.Selection, Position.Mid, "100%", "800px")
            {
                BackgroundColor = "white"
            };

            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Garage", "", "")
            {
                Width = "100%",
                Height = "800px",
                TextAlign = BrowserTextAlign.left,
                ItemsAlign = BrowserContentAlign.Start,
                Image = $"package://statics/DavWebCreator/Custom/Images/sumArt.png",
                ScrollBarY = true,
            };


            browser.AddElement(card);
            foreach (VehicleDummy dummy in vehicleDummys)
            {
                BrowserCard insideCard = new BrowserCard(BrowserCardType.HeaderDescriptionAndButtonWithIcon,
                    "", dummy.Name, "")
                {
                    TextAlign = BrowserTextAlign.left,
                    Width = "16rem",
                    Margin = "15px",
                    Row = 1
                };

                insideCard.Image = $"package://statics/DavWebCreator/Custom/Images/sumArt.png";

                insideCard.Row = card.AddElement(insideCard.Id);

                BrowserText browserText = new BrowserText($"Fuel: {dummy.Fuel}/{dummy.MaxFuel} Liter<br/>Kofferraumplatz: {dummy.CurrentWeight}/{dummy.MaxWeight}kg", BrowserTextAlign.left);
                browserText.Margin = "0 0 10px 0";
                browserText.Padding = "0";
                browserText.FontSize = "11px";

                browserText.Row = insideCard.AddElement(browserText.Id);

                BrowserButton button = new BrowserButton("Ausparken", "ADDO");
                button.Width = "95px";
                button.Height = "35px";

                BrowserButton edit = new BrowserButton("Details", "ADDO");
                edit.SetPredefinedButtonStyle(BrowserButtonStyle.Grey_Outline);
                edit.Width = "95px";
                edit.Height = "35px";
                edit.Margin = "0 10px 0 0";
                edit.AddReturnObject(edit, dummy.Id.ToString());
                edit.Row = insideCard.AddElement(edit.Id);
                //BrowserButtonIcon icon = new BrowserButtonIcon("Ausparken", "CallMe");

                //icon.SetPredefinedButtonStyle(BrowserButtonIcon.BrowserIcon.ArrowDown);
                //icon.Row = insideCard.AddElement(icon.Id);

                //BrowserButtonIcon icon2 = new BrowserButtonIcon("Ausparken", "CallMe");

                //icon2.SetPredefinedButtonStyle(BrowserButtonIcon.BrowserIcon.ArrowUp);
                //icon2.Row = insideCard.AddElement(icon2.Id);
                //icon2.Width = "48px";
                //icon2.Height = "48px";

                if (dummy.ParkedIn)
                {
                    button.SetPredefinedButtonStyle(BrowserButtonStyle.Red_Outline);
                    button.Text = "Park";
                }
                else
                {
                    button.SetPredefinedButtonStyle(BrowserButtonStyle.Green_Outline);
                    button.Text = "Get out!";
                }

                button.Row = insideCard.AddElement(button.Id);

                browser.AddElement(insideCard);
                browser.AddElement(browserText);
                browser.AddElement(edit);
                //browser.AddElement(icon);
                //browser.AddElement(icon2);
                browser.AddElement(button);

            }

            browser.OpenBrowser(player);
        }

        [Command("container")]
        public void CreateExampleContainer(Client player)
        {
            Browser browser = new Browser("Disdas", BrowserType.Custom, Position.Mid, "100%", "100%");

            BrowserContainer container = new BrowserContainer(Position.Mid)
            {
                BackGroundColor = "red"
            };

            BrowserText browserText = new BrowserText("yeas", "Yes", BrowserTextAlign.center);

            browser.AddElement(browserText);
            container.AddElement(browserText.Id);


            browser.OpenBrowser(player);
        }

        
        [Command("progress")]
        public void CreateExampleProgressBar(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, Position.Mid, "100%", "100%");
            // Container
            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Login", "Write more content", "The content prices having a peek right now. Login and see what the actual fish is going on there")
            {
                Width = "600px",
                Height = "350px",
                TextAlign = BrowserTextAlign.center,
                Margin = "0px 0px 5px 1px"
            };

            BrowserProgressBar progressBar = new BrowserProgressBar(0, 5, 1000)
            {
                ShowCurrentValue = true,

                ProgressBarFinishedEvent = (client, progBar) =>
                {
                    NAPI.Util.ConsoleOutput(player.Name + " TIMER FINISHED");
                }
            };

            card.AddElement(progressBar.Id);

            browser.AddElement(progressBar);

            BrowserButton button = new BrowserButton("Confirm", "RandomEvent")
            {
                AnimationType = BrowserElementAnimationType.Rotation
            };


            card.AddElement(button.Id);
            browser.AddElement(button);

            // Add the card to the browser elements.
            browser.AddElement(card);

            // Open the just defined CEF Browser for the player.
            browser.OpenBrowser(player);
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
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, Position.Mid, "600px", "660px");
            // Container
            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Login", "Write more content", "The content prices having a peek right now. Login and see what the actual fish is going on there")
            {
                Width = "100%",
                Height = "100%",
                TextAlign = BrowserTextAlign.center,
                Margin = "0px 0px 5px 1px"
            };

            BrowserTextBox usernameTextBox = new BrowserTextBox("type in username...", "", "Username", true)
            {
                TextAlign = BrowserTextAlign.center,
                Width = "180px",
                Margin = "0 0 0 0",
                Text =  player.SocialClubName
            };

            card.AddElement(usernameTextBox.Id);
            browser.AddElement(usernameTextBox);

            BrowserPasswordTextBox passwordTextBox = new BrowserPasswordTextBox("placeholder...", "*****", "Password", false, false)
            {
                MinLength = 6,
                IsRequired = true,
                Width = "180px",
                Margin = "0 0 0 0"
            };

            card.AddElement(passwordTextBox.Id);
            browser.AddElement(passwordTextBox);

            BrowserButton button = new BrowserButton("Confirm", "RandomEvent")
            {
                AnimationType = BrowserElementAnimationType.HeartBeat,
                Width = "160px",
                Height = "35px"
            };

            button.AddReturnObject(usernameTextBox, "hiddenval");
            button.AddReturnObject(passwordTextBox, "anoterHiddenValue");

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
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, Position.Mid, "100%", "100%")
            {
               // Opacity = "0.5", fuked with fly in animation
                CloseEvent = "BROWSER_CLOSED_EXAMPLE"
            };

            // Container
            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Login", "Write more content", "The content prices having a peek right now. Login and see what the actual fish is going on there")
            {
                Width = "580px",
                Height = "80%",
                TextAlign = BrowserTextAlign.center,
                Margin = "0px 0px 5px 1px"
            };

            BrowserTextBox usernameTextBox = new BrowserTextBox("type in username...", "", "Username", false)
            {
                TextAlign = BrowserTextAlign.center,
                Width = "180px",
                Margin = "0 0 0 0"
            };

            card.AddElement(usernameTextBox.Id);
            browser.AddElement(usernameTextBox);

            BrowserPasswordTextBox passwordTextBox = new BrowserPasswordTextBox("placeholder...", "sumthing", "Fisch", false, true)
            {
                MinLength = 6,
                Width = "180px",
                Margin = "0 0 0 0"
            };

            card.AddElement(passwordTextBox.Id);
            browser.AddElement(passwordTextBox);

            BrowserCheckBox checkBox = new BrowserCheckBox("Remember password?", true, "15px", "Verdana", false, "18px", "18px",
                "black", BrowserTextAlign.center)
            {
                Margin = "0px 0 0px 0"
            };
            card.AddElement(checkBox.Id);
            browser.AddElement(checkBox);

            //// Lets add a button which will fire a event. Additionally you can add return objects.
            BrowserButtonIcon button = new BrowserButtonIcon("Confirm", "RandomEvent", BrowserIcon.ArrowUp);
            button.Padding = "5px";
            button.Margin = "5px";
            button.SetSize(BrowserIconSize.lg);

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


            BrowserEventResponse buttonResponse = responses[0];

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

        [RemoteEvent("BROWSER_CLOSED_EXAMPLE")]
        public void BrowserCloseEvent(Client player)
        {
            player.SendChatMessage("Browser closed");
        }





        [RemoteEvent("RandomEvent")]
        public void ButtonClicked(Client player, object[] args)
        {
            List<BrowserEventResponse> responses =
                JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());

            foreach (BrowserEventResponse resp in responses)
            {
                player.SendChatMessage(resp.Value);
            }
        }


    }
}
