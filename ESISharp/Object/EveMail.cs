using ESISharp.Enumerations;
using System.Collections.Generic;

namespace ESISharp.Object
{
    /// <summary>
    /// Object Representing and Eve Mail
    /// </summary>
    public class EveMail
    {
        /// <summary>
        /// Approved maximum CSPA cost
        /// </summary>
        public int ApprovedCost { get; }

        /// <summary>
        /// Eve Mail Message Body
        /// </summary>
        public string Body { get; }

        /// <summary>
        /// List of Recipients
        /// </summary>
        public List<Recipient> Recipients { get; }

        /// <summary>
        /// Eve Mail Message Subject
        /// </summary>
        public string Subject { get; }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipientID">(Int32) Recipient Character ID</param>
        /// <param name="MailRecipientType">(String) Recipient Type</param>
        public EveMail(string MailBody, string MailSubject, int MailRecipientID, string MailRecipientType)
        {
            Body = MailBody;
            Subject = MailSubject;
            Recipients = new List<Recipient>() { new Recipient(MailRecipientID, MailRecipientType) };
        }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipientID">(Int32) Recipient Character ID</param>
        /// <param name="MailRecipientType">(MailRecipientType) Recipient Type</param>
        public EveMail(string MailBody, string MailSubject, int MailRecipientID,  MailRecipientType MailRecipientType)
        {
            Body = MailBody;
            Subject = MailSubject;
            Recipients = new List<Recipient>() { new Recipient(MailRecipientID, MailRecipientType) };
        }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipientID">(Int32) Recipient Character ID</param>
        /// <param name="MailRecipientType">(String) Recipient Type</param>
        /// <param name="MailApprovedCost">(Int32) Approved maximum CSPA ISK cost</param>
        public EveMail(string MailBody, string MailSubject, int MailRecipientID, string MailRecipientType, int MailApprovedCost)
        {
            ApprovedCost = MailApprovedCost;
            Body = MailBody;
            Subject = MailSubject;
            Recipients = new List<Recipient>() { new Recipient(MailRecipientID, MailRecipientType) };
        }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipientID">(Int32) Recipient Character ID</param>
        /// <param name="MailRecipientType">(MailRecipientType) Recipient Type</param>
        /// <param name="MailApprovedCost">(Int32) Approved maximum CSPA ISK cost</param>
        public EveMail(string MailBody, string MailSubject, int MailRecipientID, MailRecipientType MailRecipientType, int MailApprovedCost)
        {
            ApprovedCost = MailApprovedCost;
            Body = MailBody;
            Subject = MailSubject;
            Recipients = new List<Recipient>() { new Recipient(MailRecipientID, MailRecipientType) };
        }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipient">(Recipient) Recipient</param>
        public EveMail(string MailBody, string MailSubject, Recipient MailRecipient)
        {
            Body = MailBody;
            Subject = MailSubject;
            Recipients = new List<Recipient>() { MailRecipient };
        }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipient">(Recipient) Recipient</param>
        /// <param name="MailApprovedCost">(Int32) Approved maximum CSPA ISK cost</param>
        public EveMail(string MailBody, string MailSubject, Recipient MailRecipient, int MailApprovedCost)
        {
            ApprovedCost = MailApprovedCost;
            Body = MailBody;
            Subject = MailSubject;
            Recipients = new List<Recipient>() { MailRecipient };
        }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipients">(Recipient List) Recipients</param>
        public EveMail(string MailBody, string MailSubject, List<Recipient> MailRecipients)
        {
            Body = MailBody;
            Subject = MailSubject;
            Recipients = MailRecipients;
        }

        /// <summary>
        /// Create a new Eve Mail
        /// </summary>
        /// <param name="MailBody">(String) Message Body</param>
        /// <param name="MailSubject">(String) Message Subject</param>
        /// <param name="MailRecipients">(Recipient List) Recipients</param>
        /// <param name="MailApprovedCost">(Int32) Approved maximum CSPA ISK cost</param>
        public EveMail(string MailBody, string MailSubject, List<Recipient> MailRecipient, int MailApprovedCost)
        {
            ApprovedCost = MailApprovedCost;
            Body = MailBody;
            Subject = MailSubject;
            Recipients = MailRecipient;
        }
    }

    /// <summary>
    /// Object Representing an Eve Mail Recipient
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Recipient Character ID
        /// </summary>
        public int RecipientID { get; }

        /// <summary>
        /// Recipient Type
        /// </summary>
        public string RecipientType { get; }

        /// <summary>
        /// Create a new Eve Mail Recipient
        /// </summary>
        /// <param name="MailRecipientID">(Int32) Recipient Character ID</param>
        /// <param name="MailRecipientType">(String) Recipient Type</param>
        public Recipient(int MailRecipientID, string MailRecipientType)
        {
            RecipientID = MailRecipientID;
            RecipientType = MailRecipientType;
        }

        /// <summary>
        /// Create a new Eve Mail Recipient
        /// </summary>
        /// <param name="MailRecipientID">(Int32) Recipient Character ID</param>
        /// <param name="MailRecipientType">(MailRecipientType) Recipient Type</param>
        public Recipient(int MailRecipientID, MailRecipientType MailRecipientType)
        {
            RecipientID = MailRecipientID;
            RecipientType = MailRecipientType.Value;
        }
    }
}
