using System.Collections.Generic;
using System.Text;

namespace DavWebCreator.Client.Models.Communication
{
    public class Communication
    {
        public string JsonResults;
        public int CurrentLength;
        public int Length;

        public Communication(int length)
        {
            this.Length = length;
            Reset();
        }

        public void Reset()
        {
            this.JsonResults = "";
            this.CurrentLength = 0;
        }
    }
}
