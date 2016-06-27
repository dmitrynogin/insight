using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public class Document
    {
        public Document(string text, IStemmer stemmer)
            : this(text, text.StemText(stemmer), new byte[0])
        {

        }

        public Document(string text, IList<Word> words, IList<byte> vector)
        {
            Text = text;
            Words = new ReadOnlyCollection<Word>(words);
            Vector = new ReadOnlyCollection<byte>(vector);
        }

        public string Text { get; }
        public IReadOnlyList<Word> Words { get; }
        public IReadOnlyList<byte> Vector { get; }
    }
}
