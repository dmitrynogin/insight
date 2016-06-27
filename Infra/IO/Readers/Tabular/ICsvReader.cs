using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IO.Readers.Tabular
{
    public delegate ICsvReader CsvReaderFactory(TextReader reader);

    public interface ICsvReader : ITabularReader
    {
    }
}
