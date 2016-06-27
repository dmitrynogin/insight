using Infra.ComponentModel;
using Insight.Parsing.Matching.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Matching
{
    class GroupMatching : Enumerable<Label>
    {
        public GroupMatching(PatternGroup group, Document document, IStemmer stemmer)
        {
            Group = group;
            Document = document;
            Stemmer = stemmer;
            Labels = new ConcurrentDictionary<string, bool>();
            Captures = new ConcurrentDictionary<string, bool>();
        }

        public override IEnumerator<Label> GetEnumerator()
        {
            foreach (var label in Group
                .Select(g => g.Label)
                .Distinct())
                if (Label(label))
                    yield return new Label(label, 1);
        }

        bool Label(string name) =>
            Labels.GetOrAdd(name, n => Group
                .Where(p => p.Label == n)
                .Any(p => p.Test(Capture, Label)));

        bool Capture(string text) =>    
            new Capture(text, Stemmer).Test(Document);

        PatternGroup Group { get; }
        IStemmer Stemmer { get; }
        Document Document { get; }
        ConcurrentDictionary<string, bool> Labels { get; }
        ConcurrentDictionary<string, bool> Captures { get; }
    }
}
