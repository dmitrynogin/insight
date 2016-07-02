using Infra.IO;
using Infra.IO.Models;
using Infra.MachineLearning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Classifiers.Models
{
    public class MachineGroup
    {
        public MachineGroup(FileName name, IModelFolder folder)
            : this(name,
                  folder.OpenText("labels.txt").ReadAllLines(), 
                  folder.OpenText("dictionary.txt").ReadAllLines(), 
                  folder
                    .Where(f => f.Extension == ".svm")
                    .ToDictionary(f => f.Name, f => folder.OpenSvm(f)))
        {
        }

        public MachineGroup(string name, IEnumerable<string> labels, IEnumerable<string> words, IDictionary<string, ISvm> svms)
        {
            Name = name;
            Labels = labels.ToList().AsReadOnly();
            Dictionary = new Dictionary(words);
            Svms = svms;
        }

        public string Name { get; }

        public IEnumerable<Label> Label(Document document)
        {
            var x = Dictionary.Vectorize(document);
            foreach (var kvp in Svms)
            {
                var c = kvp.Value.Classify(x);
                yield return new Label(Labels[c.Number], c.Score);
            }
        }
        
        IReadOnlyList<string> Labels { get; }
        Dictionary Dictionary { get; }
        IDictionary<string, ISvm> Svms { get; }
    }
}
