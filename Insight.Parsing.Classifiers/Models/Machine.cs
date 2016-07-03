using Infra.MachineLearning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Classifiers.Models
{
    public class Machine
    {
        public Machine(string name, IEnumerable<string> labels, ISvm svm)
        {
            Name = name;
            Labels = labels.ToList();
            Svm = svm;
        }

        public string Name { get; }

        public IEnumerable<Label> Label(double[] input)
        {
            var c = Svm.Classify(input);
            yield return new Label(Labels[c.Number], c.Score);
        }
        
        IReadOnlyList<string> Labels { get; }
        ISvm Svm { get; }
    }
}
