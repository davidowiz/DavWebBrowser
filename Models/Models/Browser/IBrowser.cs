using Resources.Models.Browser.Elements;

namespace Resources.Models.Browser
{
    public interface IBrowser
    {
        void OpenBrowser(double width, double height);
        void AddElement(BrowserElement element);
    }
}
