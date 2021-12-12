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

        public Task<IText> Parse(string path)
        {
            Task<string> rezult;

            using (StreamReader streamReader = new StreamReader(path))
            {
                rezult = streamReader.ReadToEndAsync();
            }

            throw new System.Exception();
        }
        public static List<ILine> WordsToLines(IEnumerable<string> words)
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

        public static List<IPage> LinesToPages(IEnumerable<ILine> lines)
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

        public async Task<string> ReadFileAsync(string filePath)
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
