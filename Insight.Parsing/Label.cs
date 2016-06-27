using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public class Label
    {
        public Label(string text, double score)
        {
            Text = text;
            Score = score;
        }

        public string Text { get; }
        public double Score { get; }
    }
}
