using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public class LabelGroup : Enumerable<Label>
    {
        public LabelGroup(string name, IEnumerable<Label> items)
        {
            Name = name;
            Items = items;
        }

        public string Name { get; }
        public override IEnumerator<Label> GetEnumerator() =>
            Items.GetEnumerator();

        IEnumerable<Label> Items { get; }
    }
}
