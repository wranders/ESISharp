using ESISharp.Enumeration;
using Newtonsoft.Json;

namespace ESISharp.Model.Object
{
    public class EveMailRecipient
    {
        private int _RecipientID;
        private string _RecipientType;

        [JsonProperty(PropertyName = "recipient_id")]
        public int RecipientID { get => _RecipientID; set => _RecipientID = value; }

        [JsonProperty(PropertyName = "recipient_type")]
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
