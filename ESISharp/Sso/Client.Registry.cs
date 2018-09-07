using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESISharp.Sso
{
    public class Registry
    {
        private readonly Client _Client;

        internal Registry(Client client) => _Client = client;

        internal void CreateKey(string proto, string command)
        {
            var protoRoot = Microsoft.Win32.Registry.CurrentUser
                .OpenSubKey("Software").OpenSubKey("Classes", true).CreateSubKey(proto);
            protoRoot.SetValue("", "URL:Eve Online SSO Protocol");
            protoRoot.SetValue("URL Protocol", "");

            var defaultIcon = protoRoot.CreateSubKey("DefaultIcon");
            defaultIcon.SetValue("", _Client.AuthorizerFileName + ".exe,1");

            var sh = protoRoot.CreateSubKey("Shell");
            var open = sh.CreateSubKey("Open");
            var comm = open.CreateSubKey("Command");
            comm.SetValue("", command);
        }

        public void EnsureKey()
        {
            var proto = _Client._CallbackProtocol;
            var comm = @"""" + @_Client.AuthorizerFilePath + @""" ""%1""";
            var protoRoot = Microsoft.Win32.Registry.CurrentUser
                .OpenSubKey("Software").OpenSubKey("Classes", true).CreateSubKey(proto);

            if (protoRoot == null)
                CreateKey(proto, comm);
            else
            {
                try
                {
                    RegistryKey defaultIconKey = protoRoot.OpenSubKey("DefaultIcon");
                    RegistryKey commKey = protoRoot.OpenSubKey("Shell").OpenSubKey("Open").OpenSubKey("Command");

                    if (defaultIconKey == null || commKey == null)
                    {
                        CreateKey(proto, comm);
                        return;
                    }

                    var protoRootValue = protoRoot.GetValue("") != null;
                    var defaultIconValue = defaultIconKey.GetValue("") != null;
                    var commValue = commKey.GetValue("") != null;

                    if (!protoRootValue && !defaultIconValue && !commValue)
                    {
                        CreateKey(proto, comm);
                        return;
                    }

                    if (commKey.GetValue("").ToString() != comm)
                        CreateKey(proto, comm);
                }
                catch (NullReferenceException)
                {
                    CreateKey(proto, comm);
                }
            }
        }
    }
}
