using ESISharp.Enumeration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Model.Object
{
    public class EveMail
    {
        private int _ApprovedCost;
        private string _Body;
        private string _Subject;
        private IEnumerable<EveMailRecipient> _Recipients;

        [JsonProperty(PropertyName = "approved_cost")]
        public int ApprovedCost { get => _ApprovedCost; set => _ApprovedCost = value; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get => _Body; set => _Body = value; }

        [JsonProperty(PropertyName = "subject")]
        public string Subject { get => _Subject; set => _Subject = value; }

        [JsonProperty(PropertyName = "recipients")]
        public IEnumerable<EveMailRecipient> Recipients { get => _Recipients; set => _Recipients = value; }

        private EveMail(string body, string subject)
        {
            Body = body;
            Subject = subject;
        }

        public EveMail(string body, string subject, int recipientid, string recipienttype)
            : this(body, subject)
        {
            Recipients = new List<EveMailRecipient>() { new EveMailRecipient(recipientid, recipienttype) };
        }

        public EveMail(string body, string subject, int recipientid, MailRecipientType recipienttype)
            : this(body, subject, recipientid, (string)recipienttype.Value) { }

        public EveMail(string body, string subject, EveMailRecipient recipient)
            : this(body, subject)
        {
            Recipients = new List<EveMailRecipient>() { recipient };
        }

        public EveMail(string body, string subject, IEnumerable<EveMailRecipient> recipients)
            : this(body, subject)
        {
            Recipients = recipients.ToList();
        }

        public EveMail(string body, string subject, int recipientid, string recipienttype, int approvedcost)
            : this(body, subject, recipientid, recipienttype)
        {
            ApprovedCost = approvedcost;
        }

        public EveMail(string body, string subject, int recipientid, MailRecipientType recipienttype, int approvedcost)
            : this(body, subject, recipientid, (string)recipienttype.Value)
        {
            ApprovedCost = approvedcost;
        }

        public EveMail(string body, string subject, EveMailRecipient recipient, int approvedcost)
            : this(body, subject, recipient)
        {
            ApprovedCost = approvedcost;
        }

        public EveMail(string body, string subject, IEnumerable<EveMailRecipient> recipients, int approvedcost)
            : this(body, subject, recipients)
        {
            ApprovedCost = approvedcost;
        }
    }
}
