using Infra.IO;
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
        public Machine(MangledName mangledName, IEnumerable<string> labels, ISvm svm)
        {
            MangledName = mangledName;
            Labels = labels.ToList();
            Svm = svm;
        }

        public string Name => MangledName.Unmangled.Name;

        public IEnumerable<Label> Label(double[] input)
        {
            var labels = Svm
                .Classify(input)
                .Select(c => new Label(Labels[c.Number], c.Score));

            foreach (var filter in MangledName.Filters)
                if (filter.IsPercent)
                    labels = labels.Where(l => l.Score >= filter.Value / 100d);
                else
                    labels = labels.Take(filter.Value);

            return labels;
        }

        IReadOnlyList<string> Labels { get; }
        ISvm Svm { get; }
        MangledName MangledName { get; }
    }
}
