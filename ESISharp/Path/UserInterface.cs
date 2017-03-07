using ESISharp.Web;
using System.Collections.Generic;

namespace ESISharp.ESIPath
{
    /// <summary>Authenticated User Interface paths</summary>
    public class UserInterface
    {
        private readonly ESIEve EasyObject;

        internal UserInterface(ESIEve EasyEve)
        {
            EasyObject = EasyEve;
        }

        /// <summary>Add a waypoint to the current route</summary>
        /// <remarks> Requires SSO Authentication and "write_waypoint" scope</remarks>
        /// <param name="DestinationID">(Int64) Destination ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SetWaypoint(long DestinationID)
        {
            return SetWaypoint(DestinationID, false, false);
        }

        /// <summary>Add a waypoint to the current route.
        /// <para>If <paramref name="ClearWaypoints"/> is true, the current route will be cleared.</para></summary>
        /// <remarks> Requires SSO Authentication and "write_waypoint" scope</remarks>
        /// <param name="DestinationID">(Int64) Destination ID</param>
        /// <param name="ClearWaypoints">(Boolean) Clear Current Waypoints</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SetWaypoint(long DestinationID, bool ClearWaypoints)
        {
            return SetWaypoint(DestinationID, ClearWaypoints, false);
        }

        /// <summary>Add a waypoint to the current route.
        /// <para>If <paramref name="ClearWaypoints"/> is true, the current route will be cleared.</para>
        /// <para>If <paramref name="AddToBeginning"/> is true, the specified waypoint will be prepended to the current route.</para></summary>
        /// <remarks> Requires SSO Authentication and "write_waypoint" scope</remarks>
        /// <param name="DestinationID">(Int64) Destination ID</param>
        /// <param name="ClearWaypoints">(Boolean) Clear Current Waypoints</param>
        /// <param name="AddToBeginning">(Boolean) Prepend waypoint to the current route</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest SetWaypoint(long DestinationID, bool ClearWaypoints, bool AddToBeginning)
        {
            var Path = "/ui/autopilot/waypoint/";
            var Data = new { destination_id = DestinationID, clear_other_waypoints = ClearWaypoints, add_to_beginning = AddToBeginning };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, null, Data);
        }

        /// <summary>Open Contract Window</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest OpenContract(int ContractID)
        {
            var Path = "/ui/openwindow/contract/";
            var Data = new { contract_id = ContractID };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, null, Data);
        }

        /// <summary>Open Information Window</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="TargetID">(Int32) Target ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest OpenInfo(int TargetID)
        {
            var Path = "/ui/openwindow/information/";
            var Data = new { target_id = TargetID };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, null, Data);
        }

        /// <summary>Open Market Details</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest OpenMarketDetails(int TypeID)
        {
            var Path = "/ui/openwindow/marketdetails/";
            var Data = new { type_id = TypeID };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, null, Data);
        }

        /// <summary>Open empty mail composer</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail()
        {
            return NewMail(string.Empty, string.Empty, new int[] { 0 }, 0, 0);
        }

        /// <summary>Open mail composer with filled body</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body)
        {
            return NewMail(Body, string.Empty, new int[] { 0 }, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body, string Subject)
        {
            return NewMail(Body, Subject, new int[] { 0 }, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject with one recipient</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipient">(Int32) Message Recipient Character ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body, string Subject, int Recipient)
        {
            return NewMail(Body, Subject, new int[] { Recipient }, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject, with one recipient and Corporation/Alliance group. 
        /// <para>If no individual recipient, set 0.</para></summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipient">(Int32) Message Recipient Character ID</param>
        /// <param name="CorpOrAllianceID">(Int32) Corporation/Alliance ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body, string Subject, int Recipient, int CorpOrAllianceID)
        {
            return NewMail(Body, Subject, new int[] { Recipient }, CorpOrAllianceID, 0);
        }

        /// <summary>Open mail composer with filled body and subject, with one recipient, Corporation/Alliance, and Mailing List. 
        /// <para>If no individual recipient, set 0.</para>
        /// <para>If no Corporation/Alliance recipient, set 0.</para></summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message body</param>
        /// <param name="Subject">(String) Message subject</param>
        /// <param name="Recipient">(Int32) Recipient Character ID</param>
        /// <param name="CorpOrAllianceID">(Int32) Corporation/Alliance ID</param>
        /// <param name="MailingListID">(Int32) Mailing List ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body, string Subject, int Recipient, int CorpOrAllianceID, int MailingListID)
        {
            return NewMail(Body, Subject, new int[] { Recipient }, CorpOrAllianceID, MailingListID);
        }

        /// <summary>Open mail composer with filled body and subject, with list of recipients</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipients">(Int32 List) Recipient Character IDs</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body, string Subject, IEnumerable<int> Recipients)
        {
            return NewMail(Body, Subject, Recipients, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject, with list of recipients and Corporation/Alliance ID</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipients">(Int32 List) Recipient Character IDs</param>
        /// <param name="CorpOrAllianceID">(Int32) Corporation/Alliance ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body, string Subject, IEnumerable<int> Recipients, int CorpOrAllianceID)
        {
            return NewMail(Body, Subject, Recipients, CorpOrAllianceID, 0);
        }

        /// <summary>Open mail composer with filled body and subject, with list of recipient, Corporation/Alliance, and Mailing List. 
        /// <para>If no individual recipient, set 0.</para>
        /// <para>If no Corporation/Alliance recipient, set 0.</para></summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipients">(Int32 List) Recipient Character IDs</param>
        /// <param name="CorpOrAllianceID">(Int32) Coporation/Alliance ID</param>
        /// <param name="MailingListID">(Int32) Mailing List ID</param>
        /// <returns>EsiRequest</returns>
        public EsiRequest NewMail(string Body, string Subject, IEnumerable<int> Recipients, int CorpOrAllianceID, int MailingListID)
        {
            var Path = "/ui/openwindow/newmail/";
            var Data = new
            {
                body = Body,
                subject = Subject,
                recipients = Recipients,
                to_corp_or_alliance_id = CorpOrAllianceID,
                to_mailing_list_id = MailingListID
            };
            return new EsiRequest(EasyObject, Path, EsiWebMethod.AuthPost, Data);
        }
    }
}
