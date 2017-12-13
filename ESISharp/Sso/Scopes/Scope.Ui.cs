namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Ui
        {
            public static readonly Scope OpenWindow = new Scope("esi-ui.open_window.v1");
            public static readonly Scope WriteWaypoint = new Scope("esi-ui.write_waypoint.v1");
        }
    }
}
