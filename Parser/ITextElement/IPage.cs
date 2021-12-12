using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
