using System;
using System.IO;
using System.IO.Pipes;
using System.Web;

namespace ESISharp.AuthRelay
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            if (string.IsNullOrWhiteSpace(args[0]))
                return;

            Uri uri;
            try
            {
                uri = new Uri(args[0]);
            }
            catch(UriFormatException)
            {
                return;
            }

            if (uri.Query == null)
                return;

            var query = HttpUtility.ParseQueryString(uri.Query);

            if (query["state"] == null)
                return;

            var client = new NamedPipeClientStream(query["state"]);
            var writer = new StreamWriter(client);

            try
            {
                client.Connect(10000);

                writer.WriteLine(args[0]);
                writer.Flush();

                client.WaitForPipeDrain();
                client.Close();
            }
            catch (TimeoutException)
            {
                client.Dispose();
            }
            catch (IOException)
            {
                client.Dispose();
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }
    }
}
