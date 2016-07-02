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
        public Document(string text, IStemmer stemmer, Dictionary dictionary)
            : this(text, text.StemText(stemmer), dictionary)
        {
        }

        public Document(string text, IList<Word> words, Dictionary dictionary)
            : this(text, words, dictionary.Vectorize(words))
        {
        }

        public Document(string text, IList<Word> words, IList<double> vector)
        {
            Text = text;
            Words = new ReadOnlyCollection<Word>(words);
            Vector = new ReadOnlyCollection<double>(vector);
        }

        public string Text { get; }
        public IReadOnlyList<Word> Words { get; }
        public IReadOnlyList<double> Vector { get; }
    }
}
