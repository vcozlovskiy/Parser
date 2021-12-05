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
        public List<IPage> Pages { get; }

        public Text(List<IPage> pages)
        {
            Pages = pages;
        }
    }
}
