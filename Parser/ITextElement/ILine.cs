using System.Collections.Generic;
using System.Linq;

namespace Parser.ITextElements
{
    interface ILine
    {
        IEnumerable<string> Words { get; }

        void Append(string word);

        public int WordsInLine { get { return Words.Count(); } }
    }
}
