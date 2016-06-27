using Infra.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing
{
    [IoC]
    public class Parser : IParser
    {
        public Parser(IStemmer stemmer, IEnumerable<ILabeler> labelers)
        {
            Stemmer = stemmer;
            Labelers = labelers;
        }

        public IEnumerable<LabelGroup> Parse(string text)
        {
            var document = new Document(text, Stemmer);
            return Labelers
                .SelectMany(l => l.Label(document));
        }

        IStemmer Stemmer { get; }
        IEnumerable<ILabeler> Labelers { get; }
    }
}
