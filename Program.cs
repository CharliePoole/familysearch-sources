using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static int Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            if (args.Length != 1)
            {
                Console.WriteLine("Usage: FS-SOURCE <PersonId>");
                return 1;
            }

            var personId = args[0];
            var sources = GetSources(personId);
            if (sources.Count == 0)
            {
                Console.WriteLine("No sources were found.");
                return 0;
            }

            Console.WriteLine("Sources:");

            foreach (string source in sources)
                Console.WriteLine($"* {source}");

            return 0;
        }

        private static List<string> GetSources(string personId)
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine(
                    client.DownloadString($"https://familysearch.org/platform/tree/persons/{personId}"));
            }

            var sources = new List<string>();

            sources.Add("Here is one source");
            sources.Add("Here is another source");

            return sources;
        }
    }
}
