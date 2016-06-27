using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public interface IParser
    {
        IEnumerable<LabelGroup> Parse(string text);
    }
}
