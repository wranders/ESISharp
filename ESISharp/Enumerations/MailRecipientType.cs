namespace ESISharp.Enumerations
{
    /// <summary>
    /// Mail Recipient Types
    /// </summary>
    public class MailRecipientType
    {
        /// <summary>Alliance</summary>
        public static readonly MailRecipientType Alliance = new MailRecipientType("alliance");
        /// <summary>Character</summary>
        public static readonly MailRecipientType Character = new MailRecipientType("character");
        /// <summary>Corporation</summary>
        public static readonly MailRecipientType Corporation = new MailRecipientType("corporation");
        /// <summary>Mailing List</summary>
        public static readonly MailRecipientType MailingList = new MailRecipientType("mailing_list");

        internal MailRecipientType(string val)
        {
            Value = val;
        }

        /// <summary>Recipient Type</summary>
        public string Value { get; }
    }
}
