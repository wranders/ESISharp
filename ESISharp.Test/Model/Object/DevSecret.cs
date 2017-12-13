namespace ESISharp.Test.Model.Object
{
    public class DevSecret
    {
        private string _ClientID;
        private string _SecretKey;

        public string ClientID { get => _ClientID; set => _ClientID = value; }
        public string SecretKey { get => _SecretKey; set => _SecretKey = value; }
    }
}
