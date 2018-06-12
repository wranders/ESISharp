using System;
using System.IO;
using System.IO.Pipes;
using System.Web;

namespace ESISharp.AuthRelay
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0].IndexOf("state=", StringComparison.InvariantCulture) < 0)
                return;

            var Query = HttpUtility.ParseQueryString(args[0]);
            NamedPipeClientStream Client = new NamedPipeClientStream(Query["state"]);
            StreamWriter Writer = new StreamWriter(Client);

            try
            {
                Client.Connect(10000);

                Writer.WriteLine(args[0]);
                Writer.Flush();

                Client.WaitForPipeDrain();
                Client.Close();
            }
            catch(TimeoutException)
            {
                Client.Dispose();
            }
            catch(IOException)
            {
                Client.Dispose();
            }
        }
    }
}
