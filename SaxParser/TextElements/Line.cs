using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.ITextElements;

namespace Parser.TextElements
{
    class Line : ILine
    {
        public List<string> Words { get; }

        public Line(IEnumerable<string> words)
        {
            Words = words.ToList();
        }
    }
}
