using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insight.Parsing.Classifiers
{
    public abstract class Classifier : ILabeler
    {
        public Classifier()
        {

        }

        public IEnumerable<LabelGroup> Label(Document document)
        {
            throw new NotImplementedException();
        }
    }
}
