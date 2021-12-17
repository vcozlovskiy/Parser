using Parser.ITextElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.TextElements
{
    class Text : IText
    {

        public IEnumerable<IPage> Pages { get; }

        public string TextOnPage
        {
            get
            {
                string text = string.Empty;

                foreach (IPage page in Pages)
                {
                    text += page;
                }

                return text;
            }
        }
        public Text(IEnumerable<IPage> text)
        {
            Pages = text;
        }
        public List<ILine> GetAllWords()
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<ILine> wordILine = new List<ILine>();

            Pages.ToList().ForEach((x) => stringBuilder.Append(x.ToString()));

            List<string> words = stringBuilder.ToString().Split(' ', ',', '.', '\n',
                '\r', ':', ';', '(', ')', '?', '!', '“', '’').ToList();

            var wordsTrimd = words.Where(
                (word) => !string.IsNullOrEmpty(word) && !int.TryParse(word, out int g));

            wordILine.AddRange(wordsTrimd.Select(word => new Line(word)));

            return wordILine;
        }

        public int LineNumber(ILine line)
        {
            return Pages
                .Select((a, i) => (a.Lines.First().Words.First() == line.Words.First()) ? i : -1)
                .Max();
        }

    }
}
