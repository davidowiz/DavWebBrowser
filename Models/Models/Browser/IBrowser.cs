using Browsers.Models.BrowserModels.Elements;
using System;

namespace Browsers.Models.BrowserModels
{
    public interface IBrowser
    {
        void OpenBrowser(double width, double height);
        void AddElement(BrowserElement element);
    }
}
