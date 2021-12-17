using System.Collections.Generic;

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
