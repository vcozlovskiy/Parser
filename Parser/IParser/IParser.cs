using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parser.ITextElements;

namespace Parser
{
    interface IParser
    {
        Task<IText> Parse(string path);
    }
}
