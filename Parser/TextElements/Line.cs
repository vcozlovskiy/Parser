using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.ITextElements;
using System.Configuration;


namespace Parser.TextElements
{
    class Line : ILine
    {
        public IEnumerable<string> Words { get; }


        public int WordsInLine { get { return Words.Count(); } }


        public Line(IEnumerable<string> words)
        {
            Words = words;
        }

        public Line(string word)
        {
            Words = new List<string>() { word };
        }

        public override string ToString()
        {
            StringBuilder line = new StringBuilder();
            foreach (string word in Words)
            {
                line.Append(word + " ");
            }

            return line.ToString();
        }

        public void Append(string word)
        {
            Words.Append(word);
        }
    }
}
