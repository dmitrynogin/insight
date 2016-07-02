using Infra.Attributes;
using Infra.IO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Classifiers.Models
{
    [IoC]
    public class ClassifierModel : Enumerable<MachineGroup>, IClassifierModel
    {
        public ClassifierModel(IModelSelector selector, IModelStorage storage)
        {
            Folder = storage.Open(selector.Path);
        }

        public override IEnumerator<MachineGroup> GetEnumerator()
        {
            foreach (var fileName in Folder.Where(fn => fn.Extension == ".cls"))
                yield return new MachineGroup(fileName, Folder.OpenZip(fileName.Name));
        }

        IModelFolder Folder { get; }
    }
}
