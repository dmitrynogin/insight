using Infra.Attributes;
using Infra.ComponentModel;
using Infra.IO;
using Infra.IO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Matching.Models
{
    [IoC]
    class MatcherModel : Enumerable<PatternGroup>, IMatcherModel
    {
        public MatcherModel(IModelSelector selector, IModelStorage storage)
        {
            Folder = storage.Open(selector.Path);
        }

        public override IEnumerator<PatternGroup> GetEnumerator()
        {
            foreach (var fileName in Folder.Where(fn => fn.Extension == ".pm"))
                yield return new PatternGroup(fileName.Name, Load(fileName));
        }

        public IEnumerable<Pattern> Load(FileName fileName)
        {
            using (var reader = Folder.OpenCsv(fileName))
                while (reader.Read())
                    yield return new Pattern(reader["Label"], reader["Pattern"]);
        }

        IModelFolder Folder { get; }
    }
}
