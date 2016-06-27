using Infra.Attributes;
using Insight.Parsing;
using Snowball;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Snowball
{
    [IoC]
    public class SnowballStemmer : IStemmer
    {
        Stemmer Stemmer { get; } = new EnglishStemmer();

        public string Stem(string word) =>
            Stemmer.Stem(word);
    }
}
