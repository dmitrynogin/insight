using Infra.Attributes;
using Infra.ComponentModel;
using Infra.IO;
using Infra.IO.Models;
using Infra.IO.Readers.Tabular;
using Insight.Parsing.Matching.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Matching
{
    [IoC]
    public class Matcher : ILabeler
    {
        public Matcher(IMatcherModel model, IStemmer stemmer)
        {
            Groups = model.ToArray();
            Stemmer = stemmer;
        }

        public IEnumerable<LabelGroup> Label(Document document)
        {
            foreach (var group in Groups)
                yield return new LabelGroup(
                    group.Name, 
                    new GroupMatching(group, document, Stemmer));
        }

        IEnumerable<PatternGroup> Groups { get; }
        IStemmer Stemmer { get; }
    }
}
