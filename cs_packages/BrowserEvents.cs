using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using DavWebCreator.Client.ClientModels.Browser.Stylesheets;
using DavWebCreator.Clients.ClientModels.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements;
using DavWebCreator.Server.Models.Browser.Elements.Fonts;
using Newtonsoft.Json;
using RAGE;
using RAGE.Ui;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DavWebCreator.Clients.Events
{
    public class CEFBrowserEvents : RAGE.Events.Script
    {

        private HtmlWindow BrowserWindow;
        private Browser BrowserModel;

        public CEFBrowserEvents()
        {
            Cursor.Visible = false;
            RAGE.Events.Add("INITIALIZE_CEF_BROWSER", CreateBrowserEvents);
        }

        public void Destroy()
        {
            if (BrowserWindow != null)
            {
                BrowserWindow.Destroy();
                BrowserWindow = null;
                BrowserModel = null;
                Cursor.Visible = false;
            }
        }


        public void CreateBrowserEvents(params object[] args)
        {
            this.BrowserModel = JsonConvert.DeserializeObject<Browser>(args[0].ToString());
            List<BrowserTitle> elementsBrowserTitle = JsonConvert.DeserializeObject<List<BrowserTitle>>(args[1].ToString()); // Titles
            List<BrowserText> elementsBrowserTexts = JsonConvert.DeserializeObject<List<BrowserText>>(args[2].ToString()); // Texts
            List<BrowserCheckBox> elementsBrowserCheckboxes = JsonConvert.DeserializeObject<List<BrowserCheckBox>>(args[3].ToString()); // Texts
            // ..... dirty

            Chat.Output(BrowserModel.ToString());
            if (BrowserWindow != null)
            {
                BrowserWindow.Destroy();
                BrowserWindow = null;
            }
            BrowserWindow = new HtmlWindow(BrowserModel.Path)
            {
                Active = true
            };

            Cursor.Visible = true;

            StringBuilder innerHtml = new StringBuilder();

            switch (this.BrowserModel.Type)
            {
                case BrowserType.Custom: // Default
                    switch (this.BrowserModel.Position)
                    {
                        case Position.Mid:
                            BrowserWindow.ExecuteJs($"document.getElementById('DavWebCreator').setAttribute(\"style\",\"text-align:center;display:block; width:{this.BrowserModel.Width};height:{this.BrowserModel.Height}\");");
                            break;
                        default:
                            BrowserWindow.ExecuteJs($"document.getElementById('DavWebCreator').setAttribute(\"style\",\"width:{this.BrowserModel.Width};height:{this.BrowserModel.Height}\");");
                            break;
                    }


                    Chat.Output("width: " + this.BrowserModel.Width);
                    Chat.Output("height: " + this.BrowserModel.Height);

                    // Set browser width and height
                    //BrowserWindow.ExecuteJs($"document.getElementById('DavWebCreator').style.width =\"{this.BrowserModel.Width};\"");
                    //BrowserWindow.ExecuteJs($"document.getElementById('DavWebCreator').style.height =\"{this.BrowserModel.Height};\"");
                    break;
                case BrowserType.YesNoDialog: // not implemented
                                              // BrowserWindow.ExecuteJs($"document.getElementById('DavWebCreator').style.width =\"300px;\"");
                    break;
                case BrowserType.Form: // not implemented

                    break;
            }



            // Build priority
            // #1 Elements which are not inside of a container
            // #2 Container with elements (order should be implemented later)

            // Render order
            // #1 Titles

            List<IBrowserElement> allElements = new List<IBrowserElement>();

            allElements.AddRange(elementsBrowserTitle);
            allElements.AddRange(elementsBrowserTexts);
            allElements.AddRange(elementsBrowserCheckboxes);

            string topLeft = "";
            string topMid = "";
            string topRight = "";

            string midLeft = "";
            string mid = "";
            string midRight = "";

            string bottomLeft = "";
            string bottomMid = "";
            string bottomRight = "";

            foreach (IBrowserElement element in allElements.OrderBy(w => w.OrderIndex))
            {
                string rawHtml = "";

                switch (element.Type)
                {
                    case BrowserElementType.Title:
                        BrowserTitle titleElement = element as BrowserTitle;
                   
                        rawHtml = GetHtmlToAppendByBrowserTitle(titleElement);
                 
                        break;
                    case BrowserElementType.Text:
                        BrowserText textElement = element as BrowserText;
                        rawHtml = GetHtmlToAppendByBrowserTextElement(textElement);
                        break;
                    case BrowserElementType.Checkbox:
                        BrowserCheckBox checkBoxElement = element as BrowserCheckBox;
                        rawHtml = GetHtmlToAppendByCheckBox(checkBoxElement);
                        break;
                }
                //Chat.Output(rawHtml);

                switch (element.Position)
                {
                    case Position.Top_Left:
                        topLeft += rawHtml;
                        break;
                    case Position.Top_Mid:
                        topMid += rawHtml;
                        break;
                    case Position.Top_Right:
                        topRight += rawHtml;
                        break;

                    case Position.Mid_Left:
                        midLeft += rawHtml;
                        break;
                    case Position.Mid:
                        mid += rawHtml;
                        break;
                    case Position.Mid_Right:
                        midRight += rawHtml;
                        break;

                    case Position.Bottom_Left:
                        bottomLeft += rawHtml;
                        break;
                    case Position.Bottom_Mid:
                        bottomMid += rawHtml;
                        break;
                    case Position.Bottom_Right:
                        bottomRight += rawHtml;
                        break;
                }
            }


            if (!string.IsNullOrEmpty(topLeft))
            {
                // BrowserWindow.ExecuteJs($"document.getElementById('{Position.Top_Left}').style.background)
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Top_Left.ToString()}').innerHTML = '\"{topLeft.ToString()}\"';");
            }
            if (!string.IsNullOrEmpty(topMid))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Top_Mid.ToString()}').innerHTML = '{topMid.ToString()}';");
            }
            if (!string.IsNullOrEmpty(topRight))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Top_Right.ToString()}').innerHTML = '{topRight.ToString()}';");
            }

            if (!string.IsNullOrEmpty(midLeft))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Mid_Left.ToString()}').innerHTML = '{midLeft.ToString()}';");
            }
            if (!string.IsNullOrEmpty(mid))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Mid.ToString()}').innerHTML = '{mid.ToString()}';");
            }
            if (!string.IsNullOrEmpty(midRight))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Mid_Right.ToString()}').innerHTML = '{midRight.ToString()}';");
            }

            if (!string.IsNullOrEmpty(bottomLeft))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Bottom_Left.ToString()}').innerHTML = '{bottomLeft.ToString()}';");
            }
            if (!string.IsNullOrEmpty(bottomMid))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Bottom_Mid.ToString()}').innerHTML = '{bottomMid.ToString()}';");
            }
            if (!string.IsNullOrEmpty(bottomRight))
            {
                BrowserWindow.ExecuteJs($"document.getElementById('{Position.Bottom_Right.ToString()}').innerHTML = '{bottomRight.ToString()}';");
            }

            Chat.Output($"document.getElementById('DavWebCreator').innerHTML = '{innerHtml.ToString()};");
        }


        public string GetHtmlToAppendByBrowserFont(IBrowserFont text)
        {
            var fontFamily = new Stylesheet("font-family", text.FontFamily).ToString();
            var fontSize = new Stylesheet("font-size", text.FontSize).ToString();
            var color = new Stylesheet("color", text.FontColor).ToString();
            var textAlign = new Stylesheet("text-align", text.TextAlign.ToString()).ToString();
            var fontWeight = "";

            if (text.Bold)
                fontWeight = new Stylesheet("font-weight", "bold").ToString();

            return fontFamily + " " + fontSize + " " + color + " " + textAlign + " " + fontWeight;
        }

        public string GetWidthAndHeightStyling(IBrowserElement browserElement)
        {
                string width = new Stylesheet("width", browserElement.Width).ToString();
                string height = new Stylesheet("height", browserElement.Height).ToString();

            return width + " " + height;
        }

        #region Html Converter for Models
        public string GetHtmlToAppendByBrowserTitle(BrowserTitle titleElement)
        {
            string styles = GetHtmlToAppendByBrowserFont(titleElement)
                + GetWidthAndHeightStyling(titleElement);


            return $"<h1 id=\"{titleElement.Id}\" style=\"{styles}\">{titleElement.Title}</h1>";
        }
        public string GetHtmlToAppendByCheckBox(BrowserCheckBox checkBox)
        {
            string widthAndHeight = GetWidthAndHeightStyling(checkBox);
            string fontSettings = GetHtmlToAppendByBrowserFont(checkBox);


            return $"<div class=\"all-divs\"><label for=\"{checkBox.Id}\" style=\"{fontSettings}\">{checkBox.Text} <input id=\"{checkBox.Id}\" type=\"checkbox\" style=\"{fontSettings}{widthAndHeight}\" {(checkBox.IsChecked ? "checked" : "")}></label></div>";
        }

        public string GetHtmlToAppendByBrowserTextElement(BrowserText textElement)
        {
            string fontSettings = GetHtmlToAppendByBrowserFont(textElement);
            string widthAndHeight = GetWidthAndHeightStyling(textElement);

            return $"<p id=\"{textElement.Id}\" class=\"text-break\" style=\"{fontSettings}{widthAndHeight}\">{textElement.Text}</p>";
        }





        public string GetTextAlignByPosition(BrowserTextAlign position)
        {
            var block = new Stylesheet("display", "block");

            string alignValue = "center";

            switch (position)
            {
                case BrowserTextAlign.center:
                    alignValue = "center";
                    break;
                case BrowserTextAlign.left:
                    alignValue = "left";
                    break;
                case BrowserTextAlign.right:
                    alignValue = "right";
                    break;
            }
            var textAlign = new Stylesheet("text-align", alignValue);

            return block +" " + textAlign;
        }


        //T ConvertObject<T>(object M) where T : BrowserElement
        //{
        //    // Serialize the original object to json
        //    // Desarialize the json object to the new type 
        //    T obj = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(M));
        //    return obj;
        //}
        #endregion


    }
}
