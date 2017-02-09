namespace ESISharp.Enumerations
{
    /// <summary>Mail Label Color</summary>
    public class MailLabelColor
    {
        /// <summary>White</summary>
        public static readonly MailLabelColor White = new MailLabelColor("#ffffff");
        /// <summary>Yellow</summary>
        public static readonly MailLabelColor Yellow = new MailLabelColor("#ffff01");
        /// <summary>Orange</summary>
        public static readonly MailLabelColor Orange = new MailLabelColor("#ff6600");
        /// <summary>Red Orange</summary>
        public static readonly MailLabelColor RedOrange = new MailLabelColor("#fe0000");
        /// <summary>Brown</summary>
        public static readonly MailLabelColor Brown = new MailLabelColor("#9a0000");
        /// <summary>Purple</summary>
        public static readonly MailLabelColor Purple = new MailLabelColor("#660066");
        /// <summary>Blue</summary>
        public static readonly MailLabelColor Blue = new MailLabelColor("#0000fe");
        /// <summary>Light Blue</summary>
        public static readonly MailLabelColor LightBlue = new MailLabelColor("#0099ff");
        /// <summary>Cyan</summary>
        public static readonly MailLabelColor Cyan = new MailLabelColor("#01ffff");
        /// <summary>Chartreuse</summary>
        public static readonly MailLabelColor Chartreuse = new MailLabelColor("#00ff33");
        /// <summary>Dark Green</summary>
        public static readonly MailLabelColor DarkGreen = new MailLabelColor("#349800");
        /// <summary>Olive Drab</summary>
        public static readonly MailLabelColor ODGreen = new MailLabelColor("#006634");
        /// <summary>Dark Grey</summary>
        public static readonly MailLabelColor DarkGrey = new MailLabelColor("#666666");
        /// <summary>Grey</summary>
        public static readonly MailLabelColor Grey = new MailLabelColor("#999999");
        /// <summary>Light Grey</summary>
        public static readonly MailLabelColor LightGrey = new MailLabelColor("#e6e6e6");
        /// <summary>Light Yellow</summary>
        public static readonly MailLabelColor LightYellow = new MailLabelColor("#ffffcd");
        /// <summary>Pale Blue</summary>
        public static readonly MailLabelColor PaleBlue = new MailLabelColor("#99ffff");
        /// <summary>Green Yellow</summary>
        public static readonly MailLabelColor GreenYellow = new MailLabelColor("#ccff9a");

        internal MailLabelColor(string val)
        {
            Value = val;
        }

        /// <summary>Hexadecimal Color</summary>
        public string Value { get; }
    }
}
