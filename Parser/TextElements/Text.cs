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

        public string TextOnPage 
        { 
            get
            {
                string text = string.Empty;

                foreach (IPage page in Pages)
                {
                    text += page;
                }

                return text;
            } 
        }
        public Text(IEnumerable<IPage> text)
        {
            Pages = text;
        }

        public int LineNumber(ILine line)
        {
            return Pages
                .Select((a, i) => (a.Lines.First().Words.First() == line.Words.First()) ? i : -1)
                .Max();
        }
    }
}
