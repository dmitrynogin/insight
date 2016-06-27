using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO.Readers.Tabular
{
    public class TabularReader : ICsvReader
    {
        public static readonly TabularReader Null = new TabularReader();
        
        TabularReader()
        {
        }

        public void Dispose() { }

        public IEnumerable<string> Fields =>
            Enumerable.Empty<string>();

        public Value this[int field]
        {
            get { throw new NotSupportedException(); }
        }

        public Value this[string field]
        {
            get { throw new NotSupportedException(); }
        }
        
        public bool Read() => false;
    }
}
