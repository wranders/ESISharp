namespace ESISharp.Sso.Scopes
{
    public partial class Scope
    {
        public static class Mail
        {
            public static readonly Scope OrganizeMail = new Scope("esi-mail.organize_mail.v1");
            public static readonly Scope ReadMail = new Scope("esi-mail.read_mail.v1");
            public static readonly Scope SendMail = new Scope("esi-mail.send_mail.v1");
        }
    }
}
