using Parser.ITextElements;
using Parser.TextElements;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System;
using System.Configuration;

namespace Parser
{
    class Parser : IParser
    {
        private static int WordsInLine { get; }
               = int.Parse(ConfigurationManager.AppSettings.Get("NumerOfWordInLine"));

        private static int WordsOnPage { get; } 
               = int.Parse(ConfigurationManager.AppSettings.Get("NumberOfWordsOnPage"));

        public async Task<IText> Parse(string path)
        {
            string d = await ReadFileAsync(path);
            List<IPage> pages = Parser.LinesToPages(Parser.WordsToLines(d.Split(" ")));

            return new Text(pages);
        }
        private static List<ILine> WordsToLines(IEnumerable<string> words)
        {
            List<ILine> lines = new List<ILine>();

            for (int indexWord = 0; indexWord < words.Count(); indexWord += WordsInLine)
            {
                if (WordsInLine + indexWord > words.Count())
                {
                    lines.Add(new Line(words.ToList().GetRange(indexWord, words.Count() - indexWord)));
                    break;
                }
                lines.Add(new Line(words.ToList().GetRange(indexWord, WordsInLine)));
            }

            return lines;
        }

        private static List<IPage> LinesToPages(IEnumerable<ILine> lines)
        {
            List<IPage> Pages = new List<IPage>();
            List<ILine> linesList = lines.ToList();

            for (int indexLine = 0; indexLine < linesList.Count;
                indexLine += WordsOnPage / WordsInLine)
            {
                if (linesList.Count - indexLine < WordsOnPage / WordsInLine)
                {
                    Pages.Add(new Page(linesList.GetRange(indexLine, linesList.Count - indexLine)));
                    break;
                }

                Pages.Add(new Page(linesList.GetRange(indexLine, WordsOnPage / WordsInLine)));
            }

            return Pages;
        }

        private static async Task<string> ReadFileAsync(string filePath)
        {
            return await Task.Run(() => {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    return File.ReadAllText(filePath);
                }
            });

        }
    }
}
