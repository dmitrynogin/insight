using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public class Document : Enumerable<Word>
    {
        public Document(string text, IStemmer stemmer)
            : this(text, text.StemText(stemmer))
        {
        }

        public Document(string text, IEnumerable<Word> words)
        {
            Text = text;
            Words = words;
        }

        public string Text { get; }

        public override IEnumerator<Word> GetEnumerator() => 
            Words.GetEnumerator();

        IEnumerable<Word> Words { get; }
    }
}
