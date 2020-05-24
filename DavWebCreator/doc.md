# DavWebCreator

DavWebCreator is a c# class library which provides you the possibility to generate HTML structures with according stylesheets and logic behind each element.

Lets get right into some examples...

# Yes No Dialog Example
[![Image from Gyazo](https://i.gyazo.com/e9376b9f3a988cee9f818ed8057720ee.png)](https://gyazo.com/e9376b9f3a988cee9f818ed8057720ee)
  
### Code Snippet
~~~#region YesNo Dialog Example
        [Command("yesno")]
        public void YesNoDialogExample(Client player)
        {
            Browser browser = new Browser("YesNoDialog", BrowserType.Custom, BrowserContentAlign.Center, "520px",
                "100%");

            var yesNoDialog = browser.GetYesNoDialog("YES_NO_EXAMPLE", "Character Deletion", "WARNING", "Do you really want to delete your character?",
                "Yes", "No");

            // Customize
            yesNoDialog.Card.ContentTitle.FontSize = "30px";
            yesNoDialog.Card.Margin = "33% 0 0 0";

            // Add to browser
            browser.AddYesNoDialog(yesNoDialog);

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

        #endregion
~~~


# Selection with images example
[![Image from Gyazo](https://i.gyazo.com/68cc714983320fadb4ebdfa09410c058.gif)](https://gyazo.com/68cc714983320fadb4ebdfa09410c058)
## Code snippet
~~~
        [Command("card")]
        public void CreateExampleBoxes(Client player)
        {

            Browser browser = new Browser("Disdas", BrowserType.Custom, BrowserContentAlign.Center, "100%", "100%")
            {
                BackgroundColor = "white",
                Margin = "100px 0 0 0",
            };

            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Garage", "", "")
            {
                Width = "90%",
                Height = "80%",
                TextAlign = BrowserTextAlign.left,
                ItemAlignment = BrowserContentAlign.Start,
                Image = $"package://DavWebCreator/Images/sumArt.png",
                ScrollBarY = true,
                FlexDirection = BrowserFlexDirection.flex_lg_row,
                FlexWrap = BrowserFlexWrap.flex_wrap
            };

            card.CardTitle.TextAlign = BrowserTextAlign.left;

            browser.AddElement(card);
            foreach (VehicleDummy dummy in vehicleDummys)
            {
                BrowserCard insideCard = new BrowserCard(BrowserCardType.HeaderDescriptionAndButtonWithIcon,
                    "", dummy.Name, "")
                {
                    TextAlign = BrowserTextAlign.left,
                    ItemAlignment = BrowserContentAlign.Center_small,
                    FlexDirection = BrowserFlexDirection.flex_lg_row,
                    FlexWrap = BrowserFlexWrap.flex_wrap,
                    Width = "300px",
                    Height = "215px",
                    Margin = "15px",
                    Row = 1
                };

                insideCard.ContentTitle.TextAlign = BrowserTextAlign.left;
                insideCard.ContentTitle.Margin = "8px";

                insideCard.Image = $"package://DavWebCreator/Images/sumArt.png";

                BrowserText browserText = new BrowserText($"Fuel: {dummy.Fuel}/{dummy.MaxFuel} Liter<br/>Kofferraumplatz: {dummy.CurrentWeight}/{dummy.MaxWeight}kg", BrowserTextAlign.left);
                browserText.Margin = "0 30px 10px 0";
                browserText.Padding = "0 100px 0 0";
                browserText.FontSize = "11px";


                insideCard.AddElement(browserText.Id);

                BrowserButton buyButton = new BrowserButton("BUY", "BUY_VEHICLE");
                buyButton.Width = "110px";
                buyButton.Height = "35px";
                buyButton.ItemAlignment = BrowserContentAlign.End;
                buyButton.AddReturnObject(buyButton, dummy.Id.ToString());
                insideCard.AddElement(buyButton.Id);

                BrowserButton edit = new BrowserButton("DETAILS", "SHOW_VEHICLE_DETAILS");
                edit.SetPredefinedButtonStyle(BrowserButtonStyle.Grey_Outline);
                edit.ItemAlignment = BrowserContentAlign.End;
                edit.Width = "110px";
                edit.Height = "35px";
                edit.Margin = "0 10px 0 0";
                edit.AddReturnObject(edit, dummy.Id.ToString());
                insideCard.AddElement(edit.Id);

                if (dummy.IsAvailable)
                {
                    buyButton.SetPredefinedButtonStyle(BrowserButtonStyle.Red_Outline);
                    buyButton.Enabled = false;
                    buyButton.Text = "OUT OF STOCK";
                    buyButton.FontSize = "13px";
                }
                else
                {
                    buyButton.SetPredefinedButtonStyle(BrowserButtonStyle.Green_Outline);
                }

                card.AddElement(insideCard.Id);

                browser.AddElement(insideCard);
                browser.AddElement(browserText);
                browser.AddElement(edit);
                browser.AddElement(buyButton);
            }

            browser.OpenBrowser(player);
        }

        [RemoteEvent("BUY_VEHICLE")]
        public void BuyVehicle(Client player, params object[] args)
        {
            if (args == null)
                return;

            List<BrowserEventResponse> responses = JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());


            BrowserEventResponse buttonResponse = responses[0];

            player.SendChatMessage(buttonResponse.Value + " was clicked");
            player.SendChatMessage(buttonResponse.HiddenValue + " is the hidden value!");

            //     player.TriggerEvent("CLOSE_BROWSER");
        }


        [RemoteEvent("SHOW_VEHICLE_DETAILS")]
        public void ShowVehicleDetails(Client player, params object[] args)
        {
            if (args == null)
                return;

            List<BrowserEventResponse> responses = JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());


            BrowserEventResponse buttonResponse = responses[0];

            player.SendChatMessage(buttonResponse.Value + " Clicked");
            player.SendChatMessage(buttonResponse.HiddenValue + " is the hidden value!");
            //  player.TriggerEvent("CLOSE_BROWSER");
        }
        
~~~

# Customized selection example
[![Image from Gyazo](https://i.gyazo.com/cbd3c518792c7ba3b437df11c8e6c462.gif)](https://gyazo.com/cbd3c518792c7ba3b437df11c8e6c462)
## Code snippet

~~~
  [Command("card2")]
        public void CreateExampleBoxesWithoutPictures(Client player)
        {

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
            Browser browser = new Browser("Disdas", BrowserType.Custom, BrowserContentAlign.Center, "100%", "100%")
            {
                Margin = "5% 0 0 0",
            };

            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Garage", "", "")
            {
                Width = "90%",
                FontColor = "white",
                BackGroundColor = "#292b2c",
                Height = "80%",
                TextAlign = BrowserTextAlign.left,
                ItemAlignment = BrowserContentAlign.Start,
                ScrollBarY = true,
                FlexDirection = BrowserFlexDirection.flex_lg_row,
                FlexWrap = BrowserFlexWrap.flex_wrap
            };


            browser.AddElement(card);
            foreach (VehicleDummy dummy in vehicleDummys)
            {
                BrowserCard insideCard = new BrowserCard(BrowserCardType.HeaderDescriptionAndButtonWithIcon,
                    "", dummy.Name, "")
                {
                    TextAlign = BrowserTextAlign.left,
                    BackGroundColor = "#0275d8",
                    FontColor = "white",
                    ItemAlignment = BrowserContentAlign.Start,
                    FlexDirection = BrowserFlexDirection.flex_lg_row,
                    FlexWrap = BrowserFlexWrap.flex_wrap,
                    Width = "300px",
                    Height = "140px",
                    Margin = "15px",
                    Row = 1
                };


                BrowserText browserText = new BrowserText($"Fuel: {dummy.Fuel}/{dummy.MaxFuel} Liter<br/>Kofferraumplatz: {dummy.CurrentWeight}/{dummy.MaxWeight}kg", BrowserTextAlign.left);
                browserText.Margin = "0 30px 10px 0";
                browserText.Padding = "0 100px 0 0";
                browserText.FontSize = "11px";
                browserText.FontColor = "white";
                insideCard.AddElement(browserText.Id);

                BrowserButton buyButton = new BrowserButton("BUY", "BUY_VEHICLE");
                buyButton.Width = "110px";
                buyButton.Height = "35px";
                buyButton.ItemAlignment = BrowserContentAlign.End;
                buyButton.AddReturnObject(buyButton, dummy.Id.ToString());
                insideCard.AddElement(buyButton.Id);

                BrowserButton edit = new BrowserButton("DETAILS", "SHOW_VEHICLE_DETAILS");
                edit.SetPredefinedButtonStyle(BrowserButtonStyle.Grey_Outline);
                edit.ItemAlignment = BrowserContentAlign.End;
                edit.Width = "110px";
                edit.Height = "35px";
                edit.Margin = "0 10px 0 0";
                edit.SetPredefinedButtonStyle(BrowserButtonStyle.Grey);
                edit.AddReturnObject(edit, dummy.Id.ToString());
                insideCard.AddElement(edit.Id);

                if (dummy.IsAvailable)
                {
                    buyButton.SetPredefinedButtonStyle(BrowserButtonStyle.Red);
                    buyButton.Enabled = false;
                    buyButton.Text = "OUT OF STOCK";
                    buyButton.FontSize = "13px";
                }
                else
                {
                    buyButton.SetPredefinedButtonStyle(BrowserButtonStyle.Green);
                }

                card.AddElement(insideCard.Id);

                browser.AddElement(insideCard);
                browser.AddElement(browserText);
                browser.AddElement(edit);
                browser.AddElement(buyButton);
            }

            browser.OpenBrowser(player);
        }
~~~

# Login example
[![Image from Gyazo](https://i.gyazo.com/f002e1d5320f61f90f363d0d8ffbb9e5.gif)](https://gyazo.com/f002e1d5320f61f90f363d0d8ffbb9e5)
## Code snippet
~~~
  [Command("login")]
        public void CreateExampleLogin(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, BrowserContentAlign.Center, "100%", "100%");
            browser.Margin = "10% 0 0 0";

            // Container
            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Login", "Write more content", "The content prices having a peek right now. Login and see what the actual fish is going on there")
            {
                BackGroundColor = "#292b2c",
                FontColor = "white",
                Width = "500px",
                Height = "330px",
                TextAlign = BrowserTextAlign.center,
                Margin = "0px 0px 5px 1px",
                ItemAlignment = BrowserContentAlign.Center,
                FlexDirection = BrowserFlexDirection.flex_row,
                FlexWrap = BrowserFlexWrap.flex_wrap,
            };

            BrowserTextBox usernameTextBox = new BrowserTextBox("type in username...", "", "Username", true)
            {
                TextAlign = BrowserTextAlign.center,
                ItemAlignment = BrowserContentAlign.Center,
                Width = "180px",
                Margin = "0 0 0 0",
                Text = player.Name
            };

            usernameTextBox.Label.FontColor = "white";

            card.AddElement(usernameTextBox.Id);
            browser.AddElement(usernameTextBox);

            BrowserPasswordTextBox passwordTextBox = new BrowserPasswordTextBox("placeholder...", "*****", "Password", false, false)
            {
                MinLength = 6,
                ItemAlignment = BrowserContentAlign.Center,
                IsRequired = true,
                Width = "180px",
                Margin = "0 0 0 0"
            };

            passwordTextBox.Label.FontColor = "white";

            card.AddElement(passwordTextBox.Id);
            browser.AddElement(passwordTextBox);

            BrowserButton button = new BrowserButton("Login", "RandomEvent")
            {
                AnimationType = BrowserElementAnimationType.HeartBeat,
                ItemAlignment = BrowserContentAlign.Center,
                Width = "160px",
                Height = "35px",
            };

            button.SetPredefinedButtonStyle(BrowserButtonStyle.LightBlue);

            button.AddReturnObject(usernameTextBox, "hiddenval");
            button.AddReturnObject(passwordTextBox, "anoterHiddenValue");

            card.AddElement(button.Id);
            browser.AddElement(button);

            // Add the card to the browser elements.
            browser.AddElement(card);

            // Open the just defined CEF Browser for the player.
            browser.OpenBrowser(player);
        }
        
        [RemoteEvent("RandomEvent")]
        public void ButtonClicked(Client player, object[] args)
        {
            List<BrowserEventResponse> responses =
                JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());

            // same order as you added them as return values
            // var usernameTextBoxReponse = responses[0];
            // var passwordTextBoxResponse = responses[1];


            foreach (BrowserEventResponse resp in responses)
            {
                player.SendChatMessage(resp.Value);
            }
        }

        [RemoteEvent("BROWSER_CLOSED_EXAMPLE")]
        public void BrowserCloseEvent(Client player)
        {
            player.SendChatMessage("Browser closed");
        }

~~~

# Login example 2
[![Image from Gyazo](https://i.gyazo.com/0c3dcaa0fe41971fc622250b57d44f5e.gif)](https://gyazo.com/0c3dcaa0fe41971fc622250b57d44f5e)
## Code snippet
~~~
        [Command("examplelogin")]
        public void CreateExampleLoginBrowser2(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, BrowserContentAlign.Center, "100%", "100%")
            {
                // Opacity = "0.5", fuked with fly in animation
                CloseEvent = "BROWSER_CLOSED_EXAMPLE",
                Margin = "10% 0 0 0"
            };

            // Container
            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Login", "Write more content", "The content prices having a peek right now. Login and see what the actual fish is going on there")
            {
                Width = "580px",
                Height = "380px",
                TextAlign = BrowserTextAlign.center,
                ItemAlignment = BrowserContentAlign.Center,
                FlexDirection = BrowserFlexDirection.flex_lg_row,
                FlexWrap = BrowserFlexWrap.flex_wrap,
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
            //BrowserButtonIcon button = new BrowserButtonIcon("Confirm", "RandomEvent", BrowserIcon.ArrowUp);
            BrowserButton button = new BrowserButton("Confirm", "RandomEvent");
            button.Width = "400px";
            button.Padding = "5px";
            button.Margin = "5px";
            button.SetPredefinedButtonStyle(BrowserButtonStyle.Blue);

            //button.AnimationType = BrowserElementAnimationType.HeartBeat;



            //If the button click event will be fired, the following values will be returned. (ORDER = You give order = you get same order back)
            button.AddReturnObject(checkBox, "someHiddenValue");
            button.AddReturnObject(usernameTextBox, "someHiddenValue2");
            button.AddReturnObject(passwordTextBox, "someHiddenValue3");

            card.AddElement(button.Id);
            browser.AddElement(button);

            // Add the card to the browser elements.
            browser.AddElement(card);

            // Open the just defined CEF Browser for the player.
            browser.OpenBrowser(player);
        }

        [RemoteEvent("RandomEvent")]
        public void ButtonClicked(Client player, object[] args)
        {
            List<BrowserEventResponse> responses =
                JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());

            // var usernameTextBoxReponse = responses[0];
            // var passwordTextBoxResponse = responses[1];
            // var checkboxResponse = responses[1];


            foreach (BrowserEventResponse resp in responses)
            {
                player.SendChatMessage(resp.Value);
            }
        }

        [RemoteEvent("BROWSER_CLOSED_EXAMPLE")]
        public void BrowserCloseEvent(Client player)
        {
            player.SendChatMessage("Browser closed");
        }

~~~

# Select single item example
[![Image from Gyazo](https://i.gyazo.com/4ad256ec235725137ea69d1bafbd734b.gif)](https://gyazo.com/4ad256ec235725137ea69d1bafbd734b)
## Code snippet
~~~
 [Command("selector")]
        public void CreateExampleSelection(Client player)
        {

            Browser browser = new Browser("Disdas", BrowserType.Custom, BrowserContentAlign.Center, "100%", "800px")
            {
                BackgroundColor = "white",
                Margin = "10% 0 0 0"
            };

            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Selection Example", "", "")
            {
                Width = "500px",
                Height = "500px",
                TextAlign = BrowserTextAlign.center,
                ItemAlignment = BrowserContentAlign.Center,
                Image = $"package://DavWebCreator/Images/sumArt.png",
                ScrollBarY = false,
                FlexDirection = BrowserFlexDirection.flex_column
            };

            browser.AddElement(card);

            BrowserDropDown dropDown = new BrowserDropDown("Select Fish Color");
            dropDown.Label.BorderStyle = BorderStyle.solid;
            dropDown.Label.BorderWidth = "1px";
            dropDown.Label.BorderColor = "black";
            dropDown.Label.Width = "200px";


            dropDown.BorderStyle = BorderStyle.solid;
            dropDown.BorderWidth = "1px";
            dropDown.BorderColor = "black";
            dropDown.Height = "100%";

            dropDown.FontColor = "black";
            dropDown.Width = "210px";
            dropDown.Bold = true;
            dropDown.TextAlign = BrowserTextAlign.center;
            // dropDown.Width = "100%";

            BrowserButton button = new BrowserButton("CONFIRM FISH COLOR", "SELECTED_FISH_COLOR");
            button.Margin = "200px 0 0 0";
            button.FontSize = "16px";
            button.Bold = true;
            button.AddReturnObject(dropDown);

            dropDown.AddDropDownValue("Red", "1");
            dropDown.AddDropDownValue("Green", "2");
            dropDown.AddDropDownValue("Orange", "3");



            card.AddElement(button.Id);
            card.AddElement(dropDown.Id);

            browser.AddElement(dropDown);
            browser.AddElement(button);

            browser.OpenBrowser(player);
        }
        
        [RemoteEvent("SELECTED_FISH_COLOR")]
        public void SelectedFishColor(Client player, params object[] args)
        {
            if (args == null)
                return;

            List<BrowserEventResponse> responses = JsonConvert.DeserializeObject<List<BrowserEventResponse>>(args[0].ToString());


            BrowserEventResponse dropDownResponse = responses[0];

            player.SendChatMessage(dropDownResponse.Value + " Clicked");
            player.SendChatMessage(dropDownResponse.HiddenValue + " is the hidden value!");

            player.TriggerEvent("CLOSE_BROWSER");
        }
~~~

# Static progress-bar example
[![Image from Gyazo](https://i.gyazo.com/cc49b521dccbfba1ed719fbe3684d471.jpg)](https://gyazo.com/cc49b521dccbfba1ed719fbe3684d471)

## Code snippet
~~~
 [Command("noprogress")]
        public void CreateExampleInactiveProgressBar(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, BrowserContentAlign.Center, "100%", "100%");
            browser.Margin = "10% 0 0 0";

            // Container
            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Example Progress-bar", "Sir,", "This progress-bar triggers is static.")
            {
                Width = "600px",
                Height = "200px",
                TextAlign = BrowserTextAlign.center,
                ItemAlignment = BrowserContentAlign.Center,
                FlexDirection = BrowserFlexDirection.flex_column,
                FlexWrap = BrowserFlexWrap.flex_wrap,
                Margin = "0px 0px 5px 1px"
            };

            BrowserProgressBar progressBar = new BrowserProgressBar(50, 5, 1000)
            {
                ShowCurrentValue = true,
                TextAlign = BrowserTextAlign.center,
                StartTimerInstant = false,
            };

            // Add the progress-bar to the card, that the card includes it in the view.
            card.AddElement(progressBar.Id);

            // Add the progress-bar to the browser elements.
            browser.AddElement(progressBar);

            // Add the card to the browser elements.
            browser.AddElement(card);

            browser.OpenBrowser(player);
        }

~~~

# Progress-bar example
Progress-bar will call a method when the progress-bar reached the max-value. (server side timer)
[![Image from Gyazo](https://i.gyazo.com/dc982b0be3d383f970d75699798609ee.gif)](https://gyazo.com/dc982b0be3d383f970d75699798609ee)
## Code snippet
~~~
   [Command("progress")]
        public void CreateExampleProgressBar(Client player)
        {
            Browser browser = new Browser("ExampleBrowser", BrowserType.Custom, BrowserContentAlign.Center, "100%", "100%");
            browser.Margin = "10% 0 0 0";

            // Container
            BrowserCard card = new BrowserCard(BrowserCardType.HeaderAndContent,
                "Example Progress-bar", "Sir,", "This progress-bar triggers a function and starts automatically.")
            {
                Width = "600px",
                Height = "200px",
                TextAlign = BrowserTextAlign.center,
                ItemAlignment = BrowserContentAlign.Center,
                FlexDirection = BrowserFlexDirection.flex_column,
                FlexWrap = BrowserFlexWrap.flex_wrap,
                Margin = "0px 0px 5px 1px"
            };

            BrowserProgressBar progressBar = new BrowserProgressBar(50, 5, 1000)
            {
                ShowCurrentValue = true,
                TextAlign = BrowserTextAlign.center,
                FontColor = "black",

                ProgressBarFinishedEvent = (client, progBar) =>
                {
                    //Timer finished CurrentValue >= MaxValue (e.g. 100/100)

                    NAPI.Util.ConsoleOutput(player.Name + progBar.CurrentValue + " TIMER FINISHED");
                }
            };

            progressBar.SetPredefinedProgressBarStyle(BrowserProgressBarStyle.Red_Striped);

            // Add the progress-bar to the card, that the card includes it in the view.
            card.AddElement(progressBar.Id);

            // Add the progress-bar to the browser elements.
            browser.AddElement(progressBar);

            // Add the card to the browser elements.
            browser.AddElement(card);

            browser.OpenBrowser(player);
        }
~~~


### Browser Elements
######  You can customize the font settings of each element which has text. 
#

 ~~~
 FontFamily = "Arial"
 FontSize = "16px"
 FontColor = "rgba(0,0,0,1.0)" or "#ffffff" or "red"
 Bold = true or false
 TextAlign = TextAlign.right or TextAlign.center or TextAlign.left
~~~

###### Each element has atleast the following style options
#
~~~
BrowserElementAnimationType = BrowserElementAnimationType.None or BrowserElementAnimationType.HeartBeat or BrowserElementAnimationType.Rotation - BrowserFlexDirection 

Width = "100px" or "100%" or "12rem"
Height = "100px" or "100%" or "12rem"
Margin = "10px 5px 10px 5px" (TOP -> RIGHT -> BOTTOM -> LEFT)
Padding = "10px 5px 10px 5px"
Cursor = "cursor" or "pointer" .... see css documentation for cursors for more
BackgroundColor = "red" or "rgba(255,23,25,1.0)" or "#63345"
Opacity = "1.0" or "0.0" or "0.4" ....
ScrollBarX = true or false
ScrollBarY = true or false
BorderWidth = "1px"
BorderColor = "red" ...
BorderStyle = BorderStyle.Dashed ....
~~~



### Installation
1. Add the [DavWebCreator.Server](https://www.nuget.org/packages/DavWebCreator.Server/) nuget package to your C# class library server project.
2. Add the [DavWebCreator.Client](https://www.nuget.org/packages/DavWebCreator.Client/) nuget package to your C# class library client project.
3. Download the client packages [here](https://mega.nz/#!UFwghKab!8oA4pwA8SFzbp5qWcOrsPl_rTNvT4j39lMM3yhiAR7E) and extract them to "ragemp_install_folder\server-files\client_packages\".

### Development

Want to contribute? Great!
Project will be published soon to GitHub, stay tuned.


### Todos
 - Add Image as element with click event
 - Add detailed documentation
 - Add more examples
 - Add more templates
 - Add key inputs to improve the user experience


