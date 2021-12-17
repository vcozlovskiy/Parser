using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Parser.ITextElements;

namespace Parser
{
    static class ResultSaver
    {
        public static void Save(string path, IEnumerable<string> text)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            foreach (string line in text)
            {
                File.AppendAllText(path, line + Environment.NewLine);
            }
        }
    }
}
