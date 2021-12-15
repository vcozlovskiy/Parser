using System;
using System.IO;
using System.Threading;
using Parser.TextElements;
using System.Linq;
using System.Threading.Tasks;
using Parser.StaticSearcher;
using Parser.ITextElements;
using System.Configuration;

namespace Parser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IParser f = new Parser();
            IText text = await f.Parse(ConfigurationManager.AppSettings["Path"]);

            Searcher s = new Searcher(text);
            s.ResultShow();
        }
    }
}
