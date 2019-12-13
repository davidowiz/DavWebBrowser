using DavWebCreator.Resources.Models.Browser.Elements.Events;
using GTANetworkAPI;
using Resources.Models.Browser;
using Resources.Models.Browser.Elements;
using System.Collections.Generic;

namespace DavWebCreator.Events
{
    public class BrowserEvents : Script
    {
        public BrowserEvents()
        {

        }

        [Command("browser")]
        public void CreateExampleBrowser(Client player)
        {
            Browser browser = new Browser("Example Title", BrowserType.Custom, Position.Mid);

            var loginContainer = new BrowserContainer(Position.Mid);

            // Title
            loginContainer.AddElement(new BrowserTitle(Position.Mid, "Hello", "12px", bold: true));

            // Input fields
            var userNameTextBox = new BrowserTextBox(Position.Mid, "type....", "Username", readOnly: false);

            var passwordTextBox = new BrowserTextBox(Position.Bottom_Mid, "type...", "Password", readOnly: false);

            

            loginContainer.AddElement(userNameTextBox);
            loginContainer.AddElement(passwordTextBox);

            // Remember Password
            var rememberPasswordCheckBox = new BrowserCheckBox(Position.Bottom_Mid, "Remember password", false);
            loginContainer.AddElement(rememberPasswordCheckBox);

            // Login Button
            var loginButton = new BrowserButton(Position.Bottom_Mid, "Einloggen", "12px", "LOGIN_REMOTE_EVENT");
            loginButton.AddReturnObject(userNameTextBox.Id, typeof(string));
            loginButton.AddReturnObject(passwordTextBox.Id, typeof(string));
            loginButton.AddReturnObject(rememberPasswordCheckBox.Id, typeof(bool));

            loginContainer.AddElement(loginButton);
            
            // Add the login (div)Container to the Browser's elements
            browser.Elements.Add(loginContainer);

            // Open CEF with desired width and height
            browser.OpenBrowser(width: 600.00, height: 600.00);
        }


        [RemoteEvent("BROWER_CLOSED", typeof(Browser))]
        public void BrowserJustClosed(Client player, Browser browser)
        {
            player.SendChatMessage("Browser closed");
        }


        public void CloseBrowser()
        {

        }
    }
}
