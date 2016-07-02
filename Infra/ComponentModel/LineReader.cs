using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
    public static class LineReader
    {
        public static IEnumerable<string> ReadAllLines(this TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
                yield return line;
        }
    }
}
