using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Matching.Models
{
    public class Pattern
    {
        public Pattern(string label, string text)
        {
            Label = label;
            Expression = text.Compile();
        }

        public string Label { get; }
        public bool Test(Predicate<string> capture, Predicate<string> label) =>
            Expression(capture, label);

        ExpressionDelegate Expression { get; }
    }
}
