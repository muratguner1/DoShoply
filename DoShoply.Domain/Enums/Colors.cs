using System;
using System.ComponentModel;

namespace DoShoply.Domain.Enums
{
    //var color = Colors.Red;
    //var ColorDescription = color.GetDescription();
    public enum Colors
    {
        [Description("Red")]
        Red,
        [Description("Orange")]
        Orange,
        [Description("Yellow")]
        Yellow,
        [Description("Green")]
        Green,
        [Description("Blue")]
        Blue,
        [Description("Indigo")]
        Indigo,
        [Description("Violet")]
        Violet,
        [Description("Black")]
        Black,
        [Description("White")]
        White,
        [Description("Brown")]
        Brown,
        [Description("Pink")]
        Pink,
        [Description("Purple")]
        Purple,
        [Description("Gray")]
        Gray,
        [Description("Silver")]
        Silver,
        [Description("Gold")]
        Gold
    }
}
