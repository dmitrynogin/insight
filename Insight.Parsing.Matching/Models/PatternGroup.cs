using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Matching.Models
{
    public class PatternGroup : Enumerable<Pattern>
    {
        public PatternGroup(string name, IEnumerable<Pattern> patterns)
        {
            Name = name;
            Patterns = patterns;
        }

        public string Name { get; }
        public override IEnumerator<Pattern> GetEnumerator() =>
            Patterns.GetEnumerator();

        IEnumerable<Pattern> Patterns;
    }
}
