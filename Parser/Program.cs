using System;
using System.IO;
using System.Threading;
using Parser.TextElements;
using System.Linq;
using System.Threading.Tasks;
using Parser.StaticSearcher;
using Parser.ITextElements;

namespace Parser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IParser f = new Parser();
            IText text = await f.Parse(@"C:\Users\kozlo\source\repos\Parser\Parser\Text.txt");

            Searcher s = new Searcher(text);

            int i = text.LineNumber(text.Pages.First().Lines.Last()) + 1;

            s.SortByAlphabet();
            s.WordsRepeats();
            s.WordsShow();
            s.FindWordInLines("are");
        }
    }
}
