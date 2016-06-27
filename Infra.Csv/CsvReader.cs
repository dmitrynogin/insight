using Infra.Attributes;
using Infra.IO.Readers;
using Infra.IO.Readers.Tabular;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenReader = LumenWorks.Framework.IO.Csv.CsvReader;

namespace Infra.Csv
{
    [IoC]
    public class CsvReader : ICsvReader
    {
        public CsvReader(TextReader reader)
        {
            Parent = new LumenReader(reader, true);
        }

        public IEnumerable<string> Fields =>
            Parent.GetFieldHeaders();

        public Value this[int field] =>
            new Value(Parent[field]);

        public Value this[string field] =>
            new Value(Parent[field]);

        public void Dispose() =>
            Parent.Dispose();

        public bool Read() =>
            Parent.ReadNextRecord();

        LumenReader Parent { get; }
    }
}
