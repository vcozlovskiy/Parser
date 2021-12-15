using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.ITextElements
{
    interface IText
    {
        IEnumerable<IPage> Pages { get; }
        string TextOnPage { get; }

        public int LineNumber(ILine line);


        public List<ILine> GetAllWords();
    }
}
