using System;

namespace Browsers.Models.BrowserModels.Elements
{
    [Serializable]
    public enum BrowserElementType
    {
        TextBox = 1,
        Button,
        Checkbox,
        MultiSelection,
        MultiDropDown,
        Grid,
        Title,
        SubTitle,
        Text,
        Image,
        Container,
        Card,
        Password
    }
}
