using DavWebCreator.Server.Models.Browser.Elements.Fonts;

namespace DavWebCreator.Clients.ClientModels.Browser.Elements
{
    public interface IBrowserFont
    {
        /// <summary>
        /// https://getbootstrap.com/docs/4.0/content/typography/
        /// </summary>
        string FontFamily { get; set; }
        string FontSize { get; set; }
        string FontColor { get; set; }
        bool Bold { get; set; }
        BrowserTextAlign TextAlign { get; set; }
        
    }
}
