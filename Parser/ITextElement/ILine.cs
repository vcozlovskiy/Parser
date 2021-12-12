using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.ITextElements
{
    interface ILine
    {
        IEnumerable<string> Words { get; }

        void Append(string word);

        public int WordsInLine { get { return Words.Count(); } }
    }
}
