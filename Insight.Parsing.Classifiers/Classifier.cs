using Infra.Attributes;
using Insight.Parsing.Classifiers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Classifiers
{
    [IoC]
    public class Classifier : ILabeler
    {
        public Classifier(IClassifierModel model)
        {
            Machines = model.ToArray();
        }

        public IEnumerable<LabelGroup> Label(Document document) =>
            Machines.SelectMany(g => g.Label(document));

        IEnumerable<MachineGroup> Machines { get; }
    }
}
