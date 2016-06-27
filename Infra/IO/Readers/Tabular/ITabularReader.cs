using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO.Readers.Tabular
{
    public interface ITabularReader : IDisposable
    {
        IEnumerable<string> Fields { get; }
        Value this[int field] { get; }
        Value this[string field] { get; }
        bool Read();
    }
}
