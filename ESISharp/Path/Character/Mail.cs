using ESISharp.Enumerations;
using ESISharp.Object;
using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;

namespace ESISharp.ESIPath.Character
{
    /// <summary>
    /// Authenticated Character Mail paths
    /// </summary>
    public class CharacterMail
    {
        protected EveSwagger SwaggerObject;

        internal CharacterMail(EveSwagger e)
        {
            SwaggerObject = e;
        }

        /// <summary>
        /// Return Mail Headers (50 most recent)
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects representing mails</returns>
        public string GetHeaders(int CharacterID)
        {
            return GetHeaders(CharacterID, null, null);
        }

        /// <summary>
        /// Return Mail Headers with the specified label
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Label">(Int64) Mail Label</param>
        /// <returns>JSON Array of Objects representing mails</returns>
        public string GetHeaders(int CharacterID, long Label)
        {
            return GetHeaders(CharacterID, new List<long>() { Label }, null);
        }

        /// <summary>
        /// Return Mail Headers with the specified label
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Labels">(Int64) Mail Label</param>
        /// <returns>JSON Array of Objects representing mails</returns>
        public string GetHeaders(int CharacterID, List<long> Labels)
        {
            return GetHeaders(CharacterID, Labels, null);
        }

        /// <summary>
        /// Return Mail Headers up to and including specified mail ID
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="LastMailID">(Int32) Last Mail ID to include</param>
        /// <returns>JSON Array of Objects representing mails</returns>
        public string GetHeaders(int CharacterID, int LastMailID)
        {
            return GetHeaders(CharacterID, null, LastMailID);
        }

        /// <summary>
        /// Return Mail Headers with specified label up to and including specified mail ID
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Label">(Int64) Mail Label</param>
        /// <param name="LastMailID">(Int32) Last Mail ID to include</param>
        /// <returns>JSON Array of Objects representing mails</returns>
        public string GetHeaders(int CharacterID, long Label, int LastMailID)
        {
            return GetHeaders(CharacterID, new List<long>() { Label }, LastMailID);
        }

        /// <summary>
        /// Return Mail Headers with the specified label
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Labels">(Int64) Mail Label</param>
        /// <param name="LastMailID">(Int32) Last Mail ID to include</param>
        /// <returns>JSON Array of Objects representing mails</returns>
        public string GetHeaders(int CharacterID, List<long> Labels, int? LastMailID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/";
            object Data = new { labels = Labels.ToArray(), last_mail_id = LastMailID };
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get(Data);
        }

        /// <summary>
        /// Send a new Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="RecipientID">(Int32) Recipient Character ID</param>
        /// <param name="RecipientType">(String) Recipient Type</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string SendNew(int CharacterID, string MailBody, string MailSubject, int RecipientID, string RecipientType)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, RecipientID, RecipientType));
        }

        /// <summary>
        /// Send a new Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="RecipientID">(Int32) Recipient Character ID</param>
        /// <param name="RecipientType">(MailRecipientType) Recipient Type</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string SendNew(int CharacterID, string MailBody, string MailSubject, int RecipientID, MailRecipientType RecipientType)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, RecipientID, RecipientType));
        }

        /// <summary>
        /// Send a new Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipient">(Recipient) Recipient Object</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string SendNew(int CharacterID, string MailBody, string MailSubject, Recipient MailRecipient)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipient));
        }

        /// <summary>
        /// Send a new Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipients">(Recipient List) Recipient Objects</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string SendNew(int CharacterID, string MailBody, string MailSubject, List<Recipient> MailRecipients)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipients));
        }

        /// <summary>
        /// Send a new Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipient">(Recipient) Recipient Object</param>
        /// <param name="ApprovedCost">(Int32) Approved CSPA cost</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string SendNew(int CharacterID, string MailBody, string MailSubject, Recipient MailRecipient, int ApprovedCost)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipient, ApprovedCost));
        }

        /// <summary>
        /// Send a new Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipients">(Recipient List) Recipient Object</param>
        /// <param name="ApprovedCost">(Int32) Approved CSPA cost</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string SendNew(int CharacterID, string MailBody, string MailSubject, List<Recipient> MailRecipients, int ApprovedCost)
        {
            return SendNew(CharacterID, new EveMail(MailBody, MailSubject, MailRecipients, ApprovedCost));
        }

        /// <summary>
        /// Send a new Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "send_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Mail">(EveMail) Eve Mail Object</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string SendNew(int CharacterID, EveMail Mail)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/";
            object Data = new
            {
                approved_cost = Mail.ApprovedCost,
                body = Mail.Body,
                recipients = Mail.Recipients.Select(r => new { recipient_id = r.RecipientID, recipient_type = r.RecipientType }).ToArray(),
                subject = Mail.Subject
            };
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(Data);
        }

        /// <summary>
        /// Get Mail Labels
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Object containing total unread count and array of label objects containing label information</returns>
        public string GetLabels(int CharacterID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/labels/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Create a Mail Label
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Name">(String) Label Name</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string CreateLabel(int CharacterID, string Name)
        {
            return CreateLabel(CharacterID, Name, MailLabelColor.White);
        }

        /// <summary>
        /// Create a Mail Label
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Name">(String) Label Name</param>
        /// <param name="Color">(MailLabelColor) MailLabelColor enumeration</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string CreateLabel(int CharacterID, string Name, MailLabelColor Color)
        {
            return CreateLabel(CharacterID, Name, Color.Value);
        }

        /// <summary>
        /// Create a Mail Label
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="Name">(String) Label Name</param>
        /// <param name="Color">(String) Hexadecimal Color</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string CreateLabel(int CharacterID, string Name, string Color)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/labels/";
            object Data = new
            {
                color = Color,
                name = Name
            };
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Post(Data);
        }

        /// <summary>
        /// Delete Mail Label
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="LabelID">(Int32) Mail Label ID</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string DeleteLabel(int CharacterID, int LabelID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/labels/{LabelID.ToString()}/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Delete();
        }

        /// <summary>
        /// Get All Mailing List Subscriptions
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <returns>JSON Array of Objects containing mailing list name and mailing list ID</returns>
        public string GetMailingListSubscriptions(int CharacterID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/lists/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Delete Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string DeleteMail(int CharacterID, int MailID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/{MailID.ToString()}/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Delete();
        }

        /// <summary>
        /// Get A Single Mail
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "read_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <returns>JSON Object representing an Eve Mail</returns>
        public string GetMail(int CharacterID, int MailID)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/{MailID.ToString()}/";
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Get();
        }

        /// <summary>
        /// Update Mail Metadata
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="Read">(Boolean) Read</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string UpdateMail(int CharacterID, int MailID, bool Read)
        {
            return UpdateMail(CharacterID, MailID, null, Read);
        }

        /// <summary>
        /// Update Mail Metadata
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="LabelID">(Int32) Mail Label ID</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string UpdateMail(int CharacterID, int MailID, int LabelID)
        {
            return UpdateMail(CharacterID, MailID, new List<int>() { LabelID }, null);
        }

        /// <summary>
        /// Update Mail Metadata
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="LabelID">(Int32) Mail Label ID</param>
        /// <param name="Read">(Boolean) Read</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string UpdateMail(int CharacterID, int MailID, int LabelID, bool Read)
        {
            return UpdateMail(CharacterID, MailID, new List<int>() { LabelID }, Read);
        }

        /// <summary>
        /// Update Mail Metadata
        /// </summary>
        /// <remarks>Requires SSO Authentication, using "organize_mail" scope</remarks>
        /// <param name="CharacterID">(Int32) Character ID</param>
        /// <param name="MailID">(Int32) Mail ID</param>
        /// <param name="LabelIDs">(Int32 List) Mail Label IDs</param>
        /// <param name="Read">(Boolean) Read</param>
        /// <returns>Normally nothing, error if one was encountered</returns>
        public string UpdateMail(int CharacterID, int MailID, List<int> LabelIDs, bool? Read)
        {
            string Path = $"/characters/{CharacterID.ToString()}/mail/{MailID.ToString()}/";
            object Data = new
            {
                labels = LabelIDs,
                read = Read
            };
            EsiAuthRequest EsiAuthRequest = new EsiAuthRequest(SwaggerObject, Path);
            return EsiAuthRequest.Put(Data);
        }
    }
}
