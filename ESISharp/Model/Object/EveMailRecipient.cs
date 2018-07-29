using ESISharp.Enumeration;
using Newtonsoft.Json;

namespace ESISharp.Model.Object
{
    public class EveMailRecipient
    {
        [JsonProperty(PropertyName = "recipient_id")]
        public int RecipientID { get; set; }

        [JsonProperty(PropertyName = "recipient_type")]
        public string RecipientType { get; set; }

        public EveMailRecipient(int recipientid, string recipienttype)
        {
            RecipientID = recipientid;
            RecipientType = recipienttype;
        }

        public EveMailRecipient(int recipientid, MailRecipientType recipienttype)
            : this(recipientid, (string)recipienttype.Value) { }
    }
}
