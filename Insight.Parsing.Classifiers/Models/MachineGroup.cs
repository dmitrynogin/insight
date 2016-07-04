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
        public MachineGroup(IModelFolder folder)
            : this(                  
                  folder.OpenText("dic.txt").ReadAllLines(), 
                  folder
                    .Select(f => new MangledName(f))
                    .Where(f => f.Extension == ".svm")                    
                    .Select(f => new Machine(
                        f,
                        folder.OpenText(f.ChangeExtension(".txt")).ReadAllLines(), 
                        folder.OpenSvm(f))))
        {
        }

        public MachineGroup(IEnumerable<string> words, IEnumerable<Machine> machines)
        {
            Dictionary = new Dictionary(words);
            Machines = machines;
        }

        public IEnumerable<LabelGroup> Label(Document document)
        {
            var input = Dictionary.Vectorize(document);
            return Machines.Select(m => 
                new LabelGroup(m.Name, m.Label(input)));                
        }
        
        Dictionary Dictionary { get; }
        IEnumerable<Machine> Machines { get; }
    }
}
