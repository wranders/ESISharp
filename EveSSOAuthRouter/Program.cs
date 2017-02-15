using System.IO;
using System.IO.Pipes;
using System.Web;

namespace EveSSOAuthRouter
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || args[0].IndexOf("state=") < 0)
                return;

            var Query = HttpUtility.ParseQueryString(args[0]);
            NamedPipeClientStream Client = new NamedPipeClientStream(Query["state"]);
            StreamWriter Writer = new StreamWriter(Client);

            try
            {
                Client.Connect();

                Writer.WriteLine(args[0]);
                Writer.Flush();
                Client.WaitForPipeDrain();
                Client.Close();
            }
            catch (IOException)
            {
                Client.Dispose();
            }
        }
    }
}
