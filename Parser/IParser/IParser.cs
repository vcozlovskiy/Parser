using System.Threading.Tasks;
using Parser.ITextElements;

namespace Parser
{
    interface IParser
    {
        Task<IText> Parse(string path);
    }
}
