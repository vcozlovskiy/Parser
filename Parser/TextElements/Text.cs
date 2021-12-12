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
        public IEnumerable<IPage> Pages { get; }


        public Text(string Text)
        {
            string[] lines = Text.Split("\r\n");

            
        }
    }
}
