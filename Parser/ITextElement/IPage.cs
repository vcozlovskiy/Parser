using System.Collections.Generic;

namespace Parser.ITextElements
{
    interface IPage
    {
        IEnumerable<ILine> Lines { get; }
        public int WordsOnPage
        {
            get
            {
                int coutn = 0;

                foreach (ILine line in Lines)
                {
                    coutn += line.WordsInLine;
                }

                return coutn;
            }
        }
    }
}
