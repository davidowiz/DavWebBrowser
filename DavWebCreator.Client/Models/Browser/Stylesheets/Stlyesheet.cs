namespace DavWebCreator.Client.ClientModels.Browser.Stylesheets
{
    /// <summary>
    ///  Kind of useless right now but will be important on later development. (When the code gets more cleaned/Less dirty)
    /// </summary>
    public class Stylesheet
    {
        public string Attribut { get; set; }
        public string Value { get; set; }

        public Stylesheet(string attribut, string value)
        {
            this.Attribut = attribut;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{Attribut}:{Value};";
        }
    }
}
