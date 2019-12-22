using Browsers.Models.BrowserModels;
using Browsers.Models.BrowserModels.Elements;
using System;

namespace DavWebCreator.Resources.Models.Browser.Elements
{
    [Serializable]
    public class BrowserProgressbar : BrowserElementWithEvent
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }
        public int MillesecondsProgressInterval { get; set; }

        public BrowserProgressbar(int minValue, int maxValue, int currentValue, int progressStep, int millisecondsProgressInterval,
            string title, string fontSize, BrowserElementType type, Position position, string remoteEvent) 
                : base(type, position,remoteEvent)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.CurrentValue = currentValue;
            this.MillesecondsProgressInterval = millisecondsProgressInterval;
        }
    }
}
