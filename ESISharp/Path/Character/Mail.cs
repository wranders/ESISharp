using ESISharp.Enumerations;
using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath.Character
{
    /// <summary>Authenticated Character Mail paths</summary>
    public class CharacterMail
    {
        protected ESIEve EasyObject;

        internal CharacterMail(ESIEve e)
        {
            EasyObject = e;
        }

        /// <summary>Return Mail Headers (50 most recent)</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetHeaders(int CharacterID)
        {
            return GetHeaders(CharacterID, null, null);
        }

        /// <summary>Return Mail Headers with the specified label</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Label">(Int64) Mail Label</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetHeaders(int CharacterID, long Label)
        {
            return GetHeaders(CharacterID, new long[] { Label }, null);
        }

        /// <summary>Return Mail Headers with the specified label</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Labels">(Int64) Mail Label</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetHeaders(int CharacterID, IEnumerable<long> Labels)
        {
            return GetHeaders(CharacterID, Labels, null);
        }

        /// <summary>Return Mail Headers up to and including specified mail ID</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="LastMailID">(Int32) Last Mail ID to include</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetHeaders(int CharacterID, int LastMailID)
        {
            return GetHeaders(CharacterID, null, LastMailID);
        }

        /// <summary>Return Mail Headers with specified label up to and including specified mail ID</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Label">(Int64) Mail Label</param>
        /// <param name="LastMailID">(Int32) Last Mail ID to include</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetHeaders(int CharacterID, long Label, int LastMailID)
        {
            return GetHeaders(CharacterID, new long[] { Label }, LastMailID);
        }

        /// <summary>Return Mail Headers with the specified label</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Labels">(Int64) Mail Label</param>
        /// <param name="LastMailID">(Int32) Last Mail ID to include</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetHeaders(int CharacterID, IEnumerable<long> Labels, int? LastMailID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/";
            var Data = new { labels = Labels.ToArray(), last_mail_id = LastMailID };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet, Data);
        }

        /// <summary>Send a new Mail</summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="RecipientID">(Int32) Recipient Character ID</param>
        /// <param name="RecipientType">(String) Recipient Type</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SendNew(int CharacterID, string MailBody, string MailSubject, int RecipientID, string RecipientType)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, RecipientID, RecipientType));
        }

        /// <summary>Send a new Mail</summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="RecipientID">(Int32) Recipient Character ID</param>
        /// <param name="RecipientType">(MailRecipientType) Recipient Type</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SendNew(int CharacterID, string MailBody, string MailSubject, int RecipientID, MailRecipientType RecipientType)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, RecipientID, RecipientType));
        }

        /// <summary>Send a new Mail</summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipient">(Recipient) Recipient Object</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SendNew(int CharacterID, string MailBody, string MailSubject, Recipient MailRecipient)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipient));
        }

        /// <summary>Send a new Mail</summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipients">(Recipient List) Recipient Objects</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SendNew(int CharacterID, string MailBody, string MailSubject, List<Recipient> MailRecipients)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipients));
        }

        /// <summary>Send a new Mail</summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipient">(Recipient) Recipient Object</param>
        /// <param name="ApprovedCost">(Int32) Approved CSPA cost</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SendNew(int CharacterID, string MailBody, string MailSubject, Recipient MailRecipient, int ApprovedCost)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipient, ApprovedCost));
        }

        /// <summary>Send a new Mail</summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipients">(Recipient List) Recipient Object</param>
        /// <param name="ApprovedCost">(Int32) Approved CSPA cost</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SendNew(int CharacterID, string MailBody, string MailSubject, List<Recipient> MailRecipients, int ApprovedCost)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipients, ApprovedCost));
        }

        /// <summary>Send a new Mail</summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Mail">(EveMail) Eve Mail Object</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SendNew(int CharacterID, EveMail Mail)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/";
            var Data = new
            {
                approved_cost = Mail.ApprovedCost,
                body = Mail.Body,
                recipients = Mail.Recipients.Select(r => new { recipient_id = r.RecipientID, recipient_type = r.RecipientType }).ToArray(),
                subject = Mail.Subject
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, Data);
        }

        /// <summary>Get Mail Labels</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetLabels(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/labels/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Create a Mail Label</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Name">(String) Label Name</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest CreateLabel(int CharacterID, string Name)
        {
            return CreateLabel(CharacterID, Name, MailLabelColor.White);
        }

        /// <summary>Create a Mail Label</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Name">(String) Label Name</param>
        /// <param name="Color">(MailLabelColor) MailLabelColor enumeration</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest CreateLabel(int CharacterID, string Name, MailLabelColor Color)
        {
            return CreateLabel(CharacterID, Name, Color.Value);
        }

        /// <summary>Create a Mail Label</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Name">(String) Label Name</param>
        /// <param name="Color">(String) Hexadecimal Color</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest CreateLabel(int CharacterID, string Name, string Color)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/labels/";
            var Data = new
            {
                color = Color,
                name = Name
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, Data);
        }

        /// <summary>Delete Mail Label</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="LabelID">(Int32) Mail Label ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest DeleteLabel(int CharacterID, int LabelID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/labels/{LabelID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthDelete);
        }

        /// <summary>Get All Mailing List Subscriptions</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMailingListSubscriptions(int CharacterID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/lists/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Delete Mail</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest DeleteMail(int CharacterID, int MailID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/{MailID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthDelete);
        }

        /// <summary>Get A Single Mail</summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest GetMail(int CharacterID, int MailID)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/{MailID.ToString()}/";
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthGet);
        }

        /// <summary>Update Mail Metadata</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="Read">(Boolean) Read</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest UpdateMail(int CharacterID, int MailID, bool Read)
        {
            return UpdateMail(CharacterID, MailID, null, Read);
        }

        /// <summary>Update Mail Metadata</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="LabelID">(Int32) Mail Label ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest UpdateMail(int CharacterID, int MailID, int LabelID)
        {
            return UpdateMail(CharacterID, MailID, new List<int>() { LabelID }, null);
        }

        /// <summary>Update Mail Metadata</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="LabelID">(Int32) Mail Label ID</param>
        /// <param name="Read">(Boolean) Read</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest UpdateMail(int CharacterID, int MailID, int LabelID, bool Read)
        {
            return UpdateMail(CharacterID, MailID, new List<int>() { LabelID }, Read);
        }

        /// <summary>Update Mail Metadata</summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="LabelIDs">(Int32 List) Mail Label IDs</param>
        /// <param name="Read">(Boolean) Read</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest UpdateMail(int CharacterID, int MailID, IEnumerable<int> LabelIDs, bool? Read)
        {
            var Path = $"/characters/{CharacterID.ToString()}/mail/{MailID.ToString()}/";
            var Data = new
            {
                labels = LabelIDs,
                read = Read
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPut, Data);
        }
    }
}
