using ESISharp.Enumeration;

namespace ESISharp.Model.Object
{
    public class EveMailRecipient
    {
        private int _RecipientID;
        private string _RecipientType;

        public int RecipientID { get => _RecipientID; set => _RecipientID = value; }
        public string RecipientType { get => _RecipientType; set => _RecipientType = value; }

        public EveMailRecipient(int recipientid, string recipienttype)
        {
            RecipientID = recipientid;
            RecipientType = recipienttype;
        }

        public EveMailRecipient(int recipientid, MailRecipientType recipienttype)
            : this(recipientid, (string)recipienttype.Value) { }
    }
}
