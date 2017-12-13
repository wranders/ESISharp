namespace ESISharp.Enumeration
{
    public class MailRecipientType : Model.Abstract.FakeEnumerator
    {
        internal MailRecipientType(string value) : base(value) { }

        public static readonly MailRecipientType Alliance = new MailRecipientType("alliance");
        public static readonly MailRecipientType Character = new MailRecipientType("character");
        public static readonly MailRecipientType Corporation = new MailRecipientType("corporation");
        public static readonly MailRecipientType MailingList = new MailRecipientType("mailing_list");
    }
}
