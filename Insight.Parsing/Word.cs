using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    public class Word : IEquatable<Word>
    {
        public static Word Any = new Word(null, null);

        public static Word Keyword(string text, IStemmer stemmer) =>
            text == "*" ? Any :
                text.StartsWith("'") && text.EndsWith("'") ?
                    new Word(text.Trim('\'').StemWord(stemmer).Nonstemmed, null) :
                    new Word(null, text.StemWord(stemmer).Stemmed);
        
        public Word(string nonstemmed, string stemmed)
        {
            Nonstemmed = nonstemmed;
            Stemmed = stemmed;
        }

        public override int GetHashCode() =>
            Nonstemmed?.GetHashCode() ^ Stemmed?.GetHashCode() ?? 1234;

        public override bool Equals(object obj) => Equals(obj as Word);

        public bool Equals(Word other) =>
            other != null &&
                (Nonstemmed == null || Nonstemmed == other.Nonstemmed) &&
                (Stemmed == null || Stemmed == other.Stemmed);
        
        public string Nonstemmed { get; }
        public string Stemmed { get; }
    }
}
