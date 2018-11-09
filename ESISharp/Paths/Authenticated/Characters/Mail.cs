using ESISharp.Enumeration;
using ESISharp.Model.Abstract;
using ESISharp.Model.Attribute;
using ESISharp.Model.Object;
using ESISharp.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Paths.Authenticated.Characters
{
    public class Mail : ApiPath
    {
        internal Mail(EsiConnection esiconnection) : base(esiconnection) { }

        public EsiRequest GetHeaders(int characterid)
            => GetHeaders(characterid, null, -1);

        public EsiRequest GetHeaders(int characterid, int label)
            => GetHeaders(characterid, new int[] { label }, -1);

        public EsiRequest GetHeaders(int characterid, IEnumerable<int> labels)
            => GetHeaders(characterid, labels, -1);

        public EsiRequest GetHeaders(int characterid, int label, int lastmailid)
            => GetHeaders(characterid, new int[] { label }, lastmailid);

        [Path("/characters/{character_id}/mail/", WebMethods.GET)]
        public EsiRequest GetHeaders(int characterid, IEnumerable<int> labels, int lastmailid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail" };
            if (labels != null || lastmailid >= 0)
            {
                var data = new EsiRequestData { Query = new Dictionary<string, dynamic>() };
                if (labels.Any())
                    data.Query["labels"] = labels;
                if (lastmailid >= 0)
                    data.Query["last_mail_id"] = lastmailid;
                return new EsiRequest(EsiConnection, path, WebMethods.GET, data);
            }
            else
            {
                return new EsiRequest(EsiConnection, path, WebMethods.GET);
            }
        }

        [Path("/characters/{character_id}/mail/", WebMethods.POST)]
        public EsiRequest SendMail(int characterid, EveMail mail)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail" };
            var data = new EsiRequestData
            {
                Body = mail
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/characters/{character_id}/mail/{mail_id}/", WebMethods.DELETE)]
        public EsiRequest DeleteMail(int characterid, int mailid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail", mailid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.DELETE);
        }

        [Path("/characters/{character_id}/mail/{mail_id}/", WebMethods.GET)]
        public EsiRequest GetContents(int characterid, int mailid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail", mailid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest UpdateMail(int characterid, int mailid, int label, bool read)
            => UpdateMail(characterid, mailid, new int[] { label }, read);

        [Path("/characters/{character_id}/mail/{mail_id}/", WebMethods.PUT)]
        public EsiRequest UpdateMail(int characterid, int mailid, IEnumerable<int> labels, bool read)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail", mailid.ToString() };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["labels"] = labels,
                    ["read"] = read
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.PUT, data);
        }

        [Path("/characters/{character_id}/mail/labels/", WebMethods.GET)]
        public EsiRequest GetLabelsAndUnread(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail", "labels" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }

        public EsiRequest CreateLabel(int characterid, string name)
            => CreateLabel(characterid, name, MailLabelColor.White);

        [Path("/characters/{character_id}/mail/labels/", WebMethods.POST)]
        public EsiRequest CreateLabel(int characterid, string name, MailLabelColor color)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail", "labels" };
            var data = new EsiRequestData
            {
                BodyKvp = new Dictionary<string, dynamic>
                {
                    ["color"] = color.Value,
                    ["name"] = name
                }
            };
            return new EsiRequest(EsiConnection, path, WebMethods.POST, data);
        }

        [Path("/characters/{character_id}/mail/labels/{label_id}/", WebMethods.DELETE)]
        public EsiRequest DeleteLabel(int characterid, int labelid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail", "labels", labelid.ToString() };
            return new EsiRequest(EsiConnection, path, WebMethods.DELETE);
        }

        [Path("/characters/{character_id}/mail/lists/", WebMethods.GET)]
        public EsiRequest GetMailingLists(int characterid)
        {
            var path = new EsiRequestPath { "characters", characterid.ToString(), "mail", "lists" };
            return new EsiRequest(EsiConnection, path, WebMethods.GET);
        }
    }
}
