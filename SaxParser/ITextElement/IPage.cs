using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.ITextElements
{
    interface IPage
    {
        List<ILine> Lines { get; }
    }
}
