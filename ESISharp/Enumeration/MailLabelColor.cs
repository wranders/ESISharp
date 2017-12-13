namespace ESISharp.Enumeration
{
    public class MailLabelColor : Model.Abstract.FakeEnumerator
    {
        internal MailLabelColor(string value) : base(value) { }

        public static readonly MailLabelColor White = new MailLabelColor("#ffffff");
        public static readonly MailLabelColor Yellow = new MailLabelColor("#ffff01");
        public static readonly MailLabelColor Orange = new MailLabelColor("#ff6600");
        public static readonly MailLabelColor RedOrange = new MailLabelColor("#fe0000");
        public static readonly MailLabelColor Brown = new MailLabelColor("#9a0000");
        public static readonly MailLabelColor Purple = new MailLabelColor("#660066");
        public static readonly MailLabelColor Blue = new MailLabelColor("#0000fe");
        public static readonly MailLabelColor LightBlue = new MailLabelColor("#0099ff");
        public static readonly MailLabelColor Cyan = new MailLabelColor("#01ffff");
        public static readonly MailLabelColor Chartreuse = new MailLabelColor("#00ff33");
        public static readonly MailLabelColor DarkGreen = new MailLabelColor("#349800");
        public static readonly MailLabelColor ODGreen = new MailLabelColor("#006634");
        public static readonly MailLabelColor DarkGrey = new MailLabelColor("#666666");
        public static readonly MailLabelColor Grey = new MailLabelColor("#999999");
        public static readonly MailLabelColor LightGrey = new MailLabelColor("#e6e6e6");
        public static readonly MailLabelColor LightYellow = new MailLabelColor("#ffffcd");
        public static readonly MailLabelColor PaleBlue = new MailLabelColor("#99ffff");
        public static readonly MailLabelColor GreenYellow = new MailLabelColor("#ccff9a");
    }
}
