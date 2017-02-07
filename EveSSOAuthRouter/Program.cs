using System.IO;
using System.IO.Pipes;

namespace EveSSOAuthRouter
{
    static class Program
    {
        static void Main(string[] args)
        {
            NamedPipeClientStream Client = new NamedPipeClientStream("ESISharpAuth");
            StreamWriter Writer = new StreamWriter(Client);

            try
            {
                Client.Connect();

                Writer.WriteLine(args[0]);
                Writer.Flush();
                Client.WaitForPipeDrain();
                Client.Close();
            }
            catch(IOException)
            {
                Client.Dispose();
            }
        }
    }
}
