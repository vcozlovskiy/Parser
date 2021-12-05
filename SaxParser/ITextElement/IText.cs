using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.ITextElements
{
    interface IText
    {
        List<IPage> Pages { get; }
    }
}
