using Parser.ITextElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parser.TextElements;

namespace Parser.StaticSearcher
{
    class Searcher
    {
        private List<ILine> _words;
        private IText _text;

        public Searcher(IText text)
        {
            this._text = text;

            _words = text.GetAllWords();
            var WordsList = _words.GroupBy((word) => word.Words.First())
                          .Select(word => new { Word = word.Key })
                          .ToList();

            _words = new List<ILine>();
            WordsList.ForEach((word) => _words.Add(new Line(word.Word)));

            SortByAlphabet();
        }

        private void SortByAlphabet()
        {
            IEnumerable<ILine> sortedWords = _words.OrderBy((word) => word.Words.First()).ToList();
            _words = sortedWords.ToList();
        }

        private int WordsRepeats(string seacheblyWord)
        {
            return _text.Pages
                .SelectMany(page => page.Lines)
                .SelectMany((line) => line.Words)
                .Where((word) => word == seacheblyWord)
                .Count();
        }

        private string FindWordInLines(string seacheblyWord)
        {
            Line seacheblyLine = new Line(seacheblyWord);
            StringBuilder stringBuilder = new StringBuilder();
            List<int> indexArray = new List<int>();

            int index = 0;
            foreach (IPage page in _text.Pages)
            {
                foreach (ILine line1 in page.Lines)
                {
                    index++;

                    if (line1.Words.Intersect(seacheblyLine.Words).Any())
                    {
                        indexArray.Add(index);
                    }
                }
            }

            var i = indexArray.GroupBy((index) => index).Select((s) => s.Key);

            foreach (var w in i)
            {
                stringBuilder.Append(w.ToString() + " ");
            }

            return stringBuilder.ToString();
        }

        public void GetWordsAndShow()
        {
            int index = 0;
            for (char letter = 'a'; letter < 'z'; letter++) 
            {
                var wordsByAlphavit = _words.Where((word) => word.Words.First().StartsWith(letter));

                if (wordsByAlphavit.Any())
                {
                    Console.WriteLine(letter.ToString().ToUpper() + ":");
                }

                foreach (ILine line in wordsByAlphavit)
                {
                    Console.WriteLine($"    {line} ..... {WordsRepeats(line.Words.First())}" +
                        $": {FindWordInLines(_words[index].Words.First())}");
                    index++;
                }
            }
        }

        public List<string> GetResult()
        {
            List<string> result = new List<string>();

            int index = 0;
            for (char letter = 'a'; letter < 'z'; letter++)
            {
                var wordsByAlphavit = _words.Where((word) => word.Words.First().StartsWith(letter));

                if (wordsByAlphavit.Any())
                {
                    result.Add(letter.ToString().ToUpper() + ":");
                }

                foreach (ILine line in wordsByAlphavit)
                {
                    result.Add($"    {line} ..... {WordsRepeats(line.Words.First())}" +
                        $": {FindWordInLines(_words[index].Words.First())}");
                    index++;
                }
            }

            return result;
        }
    }
}
