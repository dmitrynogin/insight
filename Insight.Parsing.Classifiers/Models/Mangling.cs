using Infra.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Insight.Parsing.Classifiers.Models
{
    public class MangledName : FileName
    {
        static Regex Pattern = new Regex(@"\[(.*?)\]", RegexOptions.Compiled);

        public MangledName(FileName fileName)
            : base(fileName)
        {
        }
        
        public FileName Unmangled =>
            Pattern.Replace(Name, string.Empty).Trim();

        public IEnumerable<Filter> Filters
        {
            get
            {
                foreach (Match m in Pattern.Matches(Name))
                    yield return new Filter(m.Value);
            }
        }
    }

    public class Filter
    {
        public Filter(string text)
        {
            Text = text.Trim(' ', '[', ']');
        }

        public int Value => int.Parse(Text.TrimEnd('%', ' '));
        public bool IsPercent => Text.EndsWith("%");

        string Text;
    }
}
