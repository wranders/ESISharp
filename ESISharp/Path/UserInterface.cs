using ESISharp.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string SetWaypoint(long DestinationID)
        {
            return SetWaypoint(DestinationID, false, false);
        }

        /// <summary>Add a waypoint to the current route.
        /// <para>If <paramref name="ClearWaypoints"/> is true, the current route will be cleared.</para></summary>
        /// <remarks> Requires SSO Authentication and "write_waypoint" scope</remarks>
        /// <param name="DestinationID">(Int64) Destination ID</param>
        /// <param name="ClearWaypoints">(Boolean) Clear Current Waypoints</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string SetWaypoint(long DestinationID, bool ClearWaypoints)
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
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string SetWaypoint(long DestinationID, bool ClearWaypoints, bool AddToBeginning)
        {
            return SetWaypointAsync(DestinationID, ClearWaypoints, AddToBeginning).Result;
        }

        /// <summary>Add a waypoint to the current route</summary>
        /// <remarks> Requires SSO Authentication and "write_waypoint" scope</remarks>
        /// <param name="DestinationID">(Int64) Destination ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> SetWaypointAsync(long DestinationID)
        {
            return await SetWaypointAsync(DestinationID, false, false).ConfigureAwait(false);
        }

        /// <summary>Add a waypoint to the current route.
        /// <para>If <paramref name="ClearWaypoints"/> is true, the current route will be cleared.</para></summary>
        /// <remarks> Requires SSO Authentication and "write_waypoint" scope</remarks>
        /// <param name="DestinationID">(Int64) Destination ID</param>
        /// <param name="ClearWaypoints">(Boolean) Clear Current Waypoints</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> SetWaypointAsync(long DestinationID, bool ClearWaypoints)
        {
            return await SetWaypointAsync(DestinationID, ClearWaypoints, false).ConfigureAwait(false);
        }

        /// <summary>Add a waypoint to the current route.
        /// <para>If <paramref name="ClearWaypoints"/> is true, the current route will be cleared.</para>
        /// <para>If <paramref name="AddToBeginning"/> is true, the specified waypoint will be prepended to the current route.</para></summary>
        /// <remarks> Requires SSO Authentication and "write_waypoint" scope</remarks>
        /// <param name="DestinationID">(Int64) Destination ID</param>
        /// <param name="ClearWaypoints">(Boolean) Clear Current Waypoints</param>
        /// <param name="AddToBeginning">(Boolean) Prepend waypoint to the current route</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> SetWaypointAsync(long DestinationID, bool ClearWaypoints, bool AddToBeginning)
        {
            var Path = "/ui/autopilot/waypoint/";
            var Data = new { destination_id = DestinationID, clear_other_waypoints = ClearWaypoints, add_to_beginning = AddToBeginning };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(null, Data).ConfigureAwait(false);
        }

        /// <summary>Open Contract Window</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string OpenContract(int ContractID)
        {
            return OpenContractAsync(ContractID).Result;
        }

        /// <summary>Open Contract Window</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="ContractID">(Int32) Contract ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> OpenContractAsync(int ContractID)
        {
            var Path = "/ui/openwindow/contract/";
            var Data = new { contract_id = ContractID };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(null, Data).ConfigureAwait(false);
        }

        /// <summary>Open Information Window</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="TargetID">(Int32) Target ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string OpenInfo(int TargetID)
        {
            return OpenInfoAsync(TargetID).Result;
        }

        /// <summary>Open Information Window</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="TargetID">(Int32) Target ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> OpenInfoAsync(int TargetID)
        {
            var Path = "/ui/openwindow/information/";
            var Data = new { target_id = TargetID };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(null, Data).ConfigureAwait(false);
        }

        /// <summary>Open Market Details</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string OpenMarketDetails(int TypeID)
        {
            return OpenMarketDetailsAsync(TypeID).Result;
        }

        /// <summary>Open Market Details</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="TypeID">(Int32) Type ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> OpenMarketDetailsAsync(int TypeID)
        {
            var Path = "/ui/openwindow/marketdetails/";
            var Data = new { type_id = TypeID };
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(null, Data).ConfigureAwait(false);
        }

        /// <summary>Open empty mail composer</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail()
        {
            return NewMail(string.Empty, string.Empty, new List<int>() { 0 }, 0, 0);
        }

        /// <summary>Open mail composer with filled body</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body)
        {
            return NewMail(Body, string.Empty, new List<int>() { 0 }, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body, string Subject)
        {
            return NewMail(Body, Subject, new List<int>() { 0 }, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject with one recipient</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipient">(Int32) Message Recipient Character ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body, string Subject, int Recipient)
        {
            return NewMail(Body, Subject, new List<int>() { Recipient }, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject, with one recipient and Corporation/Alliance group. 
        /// <para>If no individual recipient, set 0.</para></summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipient">(Int32) Message Recipient Character ID</param>
        /// <param name="CorpOrAllianceID">(Int32) Corporation/Alliance ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body, string Subject, int Recipient, int CorpOrAllianceID)
        {
            return NewMail(Body, Subject, new List<int>() { Recipient }, CorpOrAllianceID, 0);
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
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body, string Subject, int Recipient, int CorpOrAllianceID, int MailingListID)
        {
            return NewMail(Body, Subject, new List<int>() { Recipient }, CorpOrAllianceID, MailingListID);
        }

        /// <summary>Open mail composer with filled body and subject, with list of recipients</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipients">(Int32 List) Recipient Character IDs</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body, string Subject, IEnumerable<int> Recipients)
        {
            return NewMail(Body, Subject, Recipients, 0, 0);
        }

        /// <summary>Open mail composer with filled body and subject, with list of recipients and Corporation/Alliance ID</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipients">(Int32 List) Recipient Character IDs</param>
        /// <param name="CorpOrAllianceID">(Int32) Corporation/Alliance ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body, string Subject, IEnumerable<int> Recipients, int CorpOrAllianceID)
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
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public string NewMail(string Body, string Subject, IEnumerable<int> Recipients, int CorpOrAllianceID, int MailingListID)
        {
            return NewMailAsync(Body, Subject, Recipients, CorpOrAllianceID, MailingListID).Result;
        }

        /// <summary>Open empty mail composer</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync()
        {
            return await NewMailAsync(string.Empty, string.Empty, new List<int>() { 0 }, 0, 0).ConfigureAwait(false);
        }

        /// <summary>Open mail composer with filled body</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body)
        {
            return await NewMailAsync(Body, string.Empty, new List<int>() { 0 }, 0, 0).ConfigureAwait(false);
        }

        /// <summary>Open mail composer with filled body and subject</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body, string Subject)
        {
            return await NewMailAsync(Body, Subject, new List<int>() { 0 }, 0, 0).ConfigureAwait(false);
        }

        /// <summary>Open mail composer with filled body and subject with one recipient</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipient">(Int32) Message Recipient Character ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body, string Subject, int Recipient)
        {
            return await NewMailAsync(Body, Subject, new List<int>() { Recipient }, 0, 0).ConfigureAwait(false);
        }

        /// <summary>Open mail composer with filled body and subject, with one recipient and Corporation/Alliance group. 
        /// <para>If no individual recipient, set 0.</para></summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipient">(Int32) Message Recipient Character ID</param>
        /// <param name="CorpOrAllianceID">(Int32) Corporation/Alliance ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body, string Subject, int Recipient, int CorpOrAllianceID)
        {
            return await NewMailAsync(Body, Subject, new List<int>() { Recipient }, CorpOrAllianceID, 0).ConfigureAwait(false);
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
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body, string Subject, int Recipient, int CorpOrAllianceID, int MailingListID)
        {
            return await NewMailAsync(Body, Subject, new List<int>() { Recipient }, CorpOrAllianceID, MailingListID).ConfigureAwait(false);
        }

        /// <summary>Open mail composer with filled body and subject, with list of recipients</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipients">(Int32 List) Recipient Character IDs</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body, string Subject, IEnumerable<int> Recipients)
        {
            return await NewMailAsync(Body, Subject, Recipients, 0, 0).ConfigureAwait(false);
        }

        /// <summary>Open mail composer with filled body and subject, with list of recipients and Corporation/Alliance ID</summary>
        /// <remarks> Requires SSO Authentication and "open_window" scope</remarks>
        /// <param name="Body">(String) Message Body</param>
        /// <param name="Subject">(String) Message Subject</param>
        /// <param name="Recipients">(Int32 List) Recipient Character IDs</param>
        /// <param name="CorpOrAllianceID">(Int32) Corporation/Alliance ID</param>
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body, string Subject, IEnumerable<int> Recipients, int CorpOrAllianceID)
        {
            return await NewMailAsync(Body, Subject, Recipients, CorpOrAllianceID, 0).ConfigureAwait(false);
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
        /// <returns>Normally nothing, error if one was encountered.</returns>
        public async Task<string> NewMailAsync(string Body, string Subject, IEnumerable<int> Recipients, int CorpOrAllianceID, int MailingListID)
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
            var EsiAuthRequest = new EsiAuthRequest(EasyObject, Path);
            return await EsiAuthRequest.PostAsync(Data).ConfigureAwait(false);
        }
    }
}
