using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public interface ILabeler
    {
        IEnumerable<LabelGroup> Label(Document document);
    }
}
