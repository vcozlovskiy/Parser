using Parser.ITextElements;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.TextElements
{
    class Page : IPage
    {
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

        public IEnumerable<ILine> Lines { get; }

        public Page(List<ILine> lines)
        {
            Lines = lines;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Line line in Lines)
            {
                stringBuilder.Append(line);
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}
