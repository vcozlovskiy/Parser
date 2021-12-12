using System;
using System.IO;
using System.Threading;
using Parser.TextElements;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parser.ITextElements;

namespace Parser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Parser f = new Parser();
            Environment.CurrentDirectory = @"C:\Users\kozlo\source\repos\Parser\Parser";
            string d = await f.ReadFileAsync("Text.txt");
            List<IPage> p = Parser.LinesToPages(Parser.WordsToLines(d.Split(" ")));

            foreach (IPage lin in p)
            {
                Console.WriteLine(lin.WordsOnPage);
            }
        }
    }
}
