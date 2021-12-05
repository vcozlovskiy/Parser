using Parser.ITextElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.TextElements
{
    class Page : IPage
    {
        public List<ILine> Lines { get; }

        public Page(List<ILine> lines)
        {
            Lines = lines;
        }
    }
}
