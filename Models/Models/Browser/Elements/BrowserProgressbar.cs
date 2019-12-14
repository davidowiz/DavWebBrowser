using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using System;

namespace DavWebCreator.Resources.Models.Browser.Elements
{
    [Serializable]
    public class BrowserProgressbar : BrowserElementWithEvent
    {
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int CurrentValue { get; private set; }
        public int MillesecondsProgressInterval { get; private set; }

        public BrowserProgressbar(int minValue, int maxValue, int currentValue, int progressStep, int millisecondsProgressInterval,
            string title, string fontSize, BrowserElementType type, Position position, string remoteEvent, bool bold = false) 
                : base(title, fontSize, type, position, remoteEvent, bold)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.CurrentValue = currentValue;
            this.MillesecondsProgressInterval = millisecondsProgressInterval;
        }
    }
}
